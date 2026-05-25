using System;
using fBarcode.Logging;
using fBarcode.Utils;
using fBarcode.UI.Dialogs;
using fBarcode.Fichema;
using System.Windows.Forms;
using fBarcode.Logging.Models;
using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CsvHelper.Configuration.Attributes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Text;

namespace fBarcode.UI
{
	public partial class MainForm : Form
	{
		private const string CustomManualActivityText = "Zadat jinou činnost";
		List<KeyValuePair<Guid, string>> WorkerReference = new();
		private List<ActivityTemplateOption> ManualActivityTemplateReference = new();
		private bool manualActivityInputUpdating;
		private bool manualActivityStartTouched;

		public MainForm()
		{
			InitializeComponent();
			Setup();
		}

		public void Setup()
		{
			AdminSettings.Initialize();
			WarehouseManager.Setup();
			WarehouseManager.CheckIntegrity();
			UpdateWorkerOptions(WarehouseManager.GetWorkerNames());
			UpdateManualActivityTemplateOptions(WarehouseManager.GetManualActivityTemplateJobs());
			WarehouseManager.SetActiveWorker(WorkerReference[0].Key);
			chooseProfileBox.SelectedIndex = 0;
			InitializeManualActivityInputs();
			UpdateManagerTextFields();
			Focus();
		}

		private void UpdateWorkerOptions(List<KeyValuePair<Guid, string>> workerOptions)
		{
			WorkerReference = workerOptions;
			chooseProfileBox.Items.Clear();
			chooseProfileBox.Items.AddRange(WorkerReference.Select(kvp => kvp.Value).ToArray());
		}

		private void UpdateManualActivityTemplateOptions(List<Job> jobs)
		{
			ManualActivityTemplateReference = new List<ActivityTemplateOption>
			{
				ActivityTemplateOption.Custom()
			};
			ManualActivityTemplateReference.AddRange(jobs.Select(ActivityTemplateOption.FromJob));

			manualActivityTemplateBox.Items.Clear();
			manualActivityTemplateBox.Items.AddRange(ManualActivityTemplateReference.ToArray());
			manualActivityTemplateBox.SelectedIndex = 0;
		}

		private void createParcelButton_Click(object sender, EventArgs e)
		{
			StartParcel();
		}

		private void StartParcel()
		{
			string orderNumber = orderNumberInputBox.Text.Trim();
			(byte[],string) label;
			if (WarehouseManager.CheckParcelFinished(orderNumber))
			{
				ParcelCompletedDialog popup = new();
				DialogResult result = popup.ShowDialog();
				if (result == DialogResult.No || result == DialogResult.Cancel)
				{
					EndCurrentParcel();
					return;
				}
			}
			ParcelPreferences parcelPreferences = new ParcelPreferences(multiParcelCheckBox.Checked, eveningParcelCheckBox.Checked, saveBarcodeCheckBox.Checked, confirmParcelCheckBox.Checked);
			Parcel parcel;
			try
			{
				createParcelButton.Enabled = false;
				orderNumberInputBox.Enabled = false;
				parcelProgressLabel.Text = "Vytvářím novou zásilku z databáze faktur";
				parcel = Parcel.createParcel(orderNumber, parcelPreferences);
				parcelProgressBar.PerformStep();
				ShowParcelInfo(parcel);
				if (parcelPreferences.UserConfirmParcel)
				{
					ConfirmParcelDialog popup = new();
					DialogResult result = popup.ShowDialog();
					if (result == DialogResult.No || result == DialogResult.Cancel)
					{
						EndCurrentParcel();
						return;
					}
				}
				parcelProgressLabel.Text = "Vytvářím požadavek na API";
				label = parcel.GetLabel();
				parcelProgressBar.PerformStep();
			}
			catch (OperationCanceledException)
			{
				EndCurrentParcel();
				return;
			}
			catch (Exception ex)
			{
				DialogService.ShowError("Chyba při zpracování objednávky", ex.Message);
				EndCurrentParcel();
				return;
			}
			if (parcelPreferences.SaveCourierLabel)
			{
				PrintingService.SaveCourierLabel(label.Item1);
				parcelProgressLabel.Text = "Ukládám štítek na disk";
			}
			else
			{
				PrintingService.PrintCourierLabel(label.Item1);
				parcelProgressLabel.Text = "Posílám štítek k tisku";
			}
			parcelProgressBar.PerformStep();
			parcelProgressLabel.Text = "Ukládám informace o zpracované zásilce do databáze";
			WarehouseManager.TrackAndTrace.Log(parcel, label.Item2);
			LogParcel(parcel);
			parcelProgressBar.PerformStep();
			parcelProgressLabel.Text = "Zásilka zpracována";
			EndCurrentParcel();
		}

		private void LogParcel(Parcel parcel)
		{
			Job parcelJob = parcel switch
			{
				CzechPostParcel _ => WarehouseManager.ParcelJobs.CzechPostParcel,
				DpdParcel _ => WarehouseManager.ParcelJobs.DpdParcel,
				GlsParcel _ => WarehouseManager.ParcelJobs.GlsParcel,
				ZasilkovnaParcel _ => WarehouseManager.ParcelJobs.ZasilkovnaParcel,
				PplParcel _ => WarehouseManager.ParcelJobs.PplParcel,
				_ => null
			};
			int jobCount = parcel.MultiParcelCount == 0 ? 1 : parcel.MultiParcelCount;
			int customDuration = parcel.CalculateDurationSeconds();
			WarehouseManager.AddActivity(new Activity(parcelJob, WarehouseManager.ActiveWorker, jobCount, customDuration, parcel.OrderNumber));
			WarehouseManager.AddParcel(parcel);
			UpdateManagerTextFields();
		}
		private void EndCurrentParcel()
		{
			eveningParcelCheckBox.Checked = false;
			multiParcelCheckBox.Checked = false;
			orderNumberInputBox.Enabled = true;
			orderNumberInputBox.Text = string.Empty;
			parcelProgressBar.Value = 0;
			orderNumberInputBox.Focus();
		}
		private void ShowParcelInfo(Parcel parcel)
		{
			//var sb = new StringBuilder();
			//sb.AppendLine($"Číslo faktury: {parcel.OrderNumber}\r");
			//sb.AppendLine($"Variabilní symbol: {parcel.VariableSymbol}\r");
			//sb.AppendLine($"Dopravce: {parcel.CourierName}\r");
			//sb.AppendLine($"Hmotnost: {parcel.Weight.ToString("0.000")} kg\r");
			//sb.AppendLine($"Cena: {parcel.Price.ToString($"F{2}")} Kč\r");
			//sb.AppendLine($"Jméno příjemce: {parcel.recipient.FirstName} {parcel.recipient.LastName}\r");
			//if (parcel.isParcelShop)
			//{
			//	sb.AppendLine($"ID ParcelShopu: ");
			//	if (parcel is DpdParcel)
			//		sb.Append($"{(DpdParcel)parcel.P}");
			//}
			parcelInfoBox.Multiline = true;
			parcelInfoBox.Text = $"Číslo faktury: {parcel.OrderNumber}\r\n" +
				$"Variabilní symbol: {parcel.VariableSymbol}\r\n" +
				$"Dopravce: {parcel.CourierName}\r\n" +
				$"Hmotnost: {parcel.Weight} kg\r\n" +
				$"Cena: {parcel.Price.ToString($"F{2}")} Kč\r\n" +
				$"Jméno příjemce: {parcel.recipient.FirstName} {parcel.recipient.LastName}\r\n" +
				$"Adresa: {parcel.recipient.Street} {parcel.recipient.HouseNumber}, {parcel.recipient.City}\r\n" +
				$"Telefon: {parcel.recipient.PhoneNumber}\r\n";
		}

		private void orderNumberInputBox_TextChanged(object sender, EventArgs e)
		{
			if (orderNumberInputBox.Text.Length > 1 && long.TryParse(orderNumberInputBox.Text, out _))
				createParcelButton.Enabled = true;
			else
				createParcelButton.Enabled = false;
			if (orderNumberInputBox.Text.Length == 9)
				StartParcel();
		}

		private void importButton_Click(object sender, EventArgs e)
		{
			var form = new ImportForm();
			form.ImportComplete += ImportForm_ImportComplete;
			form.Show();
		}

		private void ImportForm_ImportComplete(object sender, EventArgs e)
		{
			Setup();
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			var form = new ExportForm();
			form.ItemsDeleted += ImportForm_ImportComplete;
			form.Show();
		}

		private void addActivityButton_Click(object sender, EventArgs e)
		{
			ActivityTemplateOption selectedTemplate = GetSelectedManualActivityTemplate();
			string description = selectedTemplate.IsCustom ? manualActivityDescriptionInputBox.Text.Trim() : selectedTemplate.Job.Name;
			if (string.IsNullOrWhiteSpace(description))
			{
				DialogService.ShowError("Ruční činnost", "Popis práce musí být vyplněný.");
				return;
			}

			if (!int.TryParse(manualActivityDurationInputBox.Text, out int durationMinutes) || durationMinutes <= 0)
			{
				DialogService.ShowError("Ruční činnost", "Minutáž musí být kladné celé číslo.");
				return;
			}

			DateTime durationFrom = GetManualActivityStart();
			DateTime durationTo = durationFrom.AddMinutes(durationMinutes);
			if (durationTo > DateTime.Now)
			{
				DialogService.ShowError("Ruční činnost", "Činnost nesmí končit v budoucnosti.");
				return;
			}

			if (selectedTemplate.IsCustom)
			{
				WarehouseManager.AddManualActivity(description, durationFrom, durationMinutes);
			}
			else
			{
				if (!int.TryParse(manualActivityCountInputBox.Text, out int jobCount) || jobCount <= 0)
				{
					DialogService.ShowError("Ruční činnost", "Počet musí být kladné celé číslo.");
					return;
				}

				WarehouseManager.AddManualActivity(selectedTemplate.Job, jobCount, description, durationFrom, durationMinutes);
			}

			ResetManualActivityInputs();
			UpdateManagerTextFields();
		}
		private void UpdateManagerTextFields()
		{
			overviewBox.Text = WarehouseManager.GenerateOverviewText();
			activityLogBox.Text = WarehouseManager.GenerateLogText();
		}

		private void chooseProfileBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			WarehouseManager.SetActiveWorker(WorkerReference[chooseProfileBox.SelectedIndex].Key);
			UpdateManagerTextFields();
		}

		private void manualActivityDurationInputBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void manualActivityDurationInputBox_TextChanged(object sender, EventArgs e)
		{
			if (manualActivityInputUpdating)
			{
				UpdateManualActivityEndPreview();
				return;
			}

			int maxLength = 4;
			if (IsCustomManualActivitySelected() && manualActivityDurationInputBox.Text.Length > maxLength)
			{
				manualActivityDurationInputBox.Text = manualActivityDurationInputBox.Text.Substring(0, maxLength);
				manualActivityDurationInputBox.SelectionStart = maxLength;
			}

			if (!manualActivityStartTouched && int.TryParse(manualActivityDurationInputBox.Text, out int durationMinutes) && durationMinutes > 0)
				SetManualActivityStart(DateTime.Now.AddMinutes(-durationMinutes), false);

			UpdateManualActivityEndPreview();
		}

		private void manualActivityCountInputBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void manualActivityCountInputBox_TextChanged(object sender, EventArgs e)
		{
			if (manualActivityInputUpdating)
				return;

			if (IsCustomManualActivitySelected())
			{
				SetManualActivityCount("1");
				return;
			}

			if (manualActivityCountInputBox.Text.Length > 3)
			{
				manualActivityCountInputBox.Text = manualActivityCountInputBox.Text.Substring(0, 3);
				manualActivityCountInputBox.SelectionStart = 3;
			}

			UpdateSelectedJobDurationFromCount();
		}

		private void manualActivityTemplateBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (manualActivityInputUpdating)
				return;

			ApplySelectedManualActivityTemplate();
		}

		private void manualActivityTemplateBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			if (e.Index < 0)
				return;

			var item = (ActivityTemplateOption)manualActivityTemplateBox.Items[e.Index];
			using var font = item.IsCustom ? new System.Drawing.Font(e.Font, System.Drawing.FontStyle.Bold) : new System.Drawing.Font(e.Font, System.Drawing.FontStyle.Regular);
			TextRenderer.DrawText(e.Graphics, item.ToString(), font, e.Bounds, e.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
			e.DrawFocusRectangle();
		}

		private void manualActivityDatePicker_ValueChanged(object sender, EventArgs e)
		{
			if (!manualActivityInputUpdating)
				manualActivityStartTouched = true;
			UpdateManualActivityEndPreview();
		}

		private void manualActivityStartTimePicker_ValueChanged(object sender, EventArgs e)
		{
			if (!manualActivityInputUpdating)
				manualActivityStartTouched = true;
			UpdateManualActivityEndPreview();
		}

		private void InitializeManualActivityInputs()
		{
			manualActivityDatePicker.Value = DateTime.Today;
			ApplySelectedManualActivityTemplate();
			SetManualActivityStart(DateTime.Now, false);
			UpdateManualActivityEndPreview();
		}

		private void ResetManualActivityInputs()
		{
			manualActivityInputUpdating = true;
			manualActivityTemplateBox.SelectedIndex = 0;
			manualActivityInputUpdating = false;
			ApplySelectedManualActivityTemplate();
			manualActivityStartTouched = false;
			manualActivityDatePicker.Value = DateTime.Today;
			SetManualActivityStart(DateTime.Now, false);
			UpdateManualActivityEndPreview();
			manualActivityDescriptionInputBox.Focus();
		}

		private DateTime GetManualActivityStart()
		{
			DateTime date = manualActivityDatePicker.Value.Date;
			TimeSpan time = manualActivityStartTimePicker.Value.TimeOfDay;
			return date.Add(time);
		}

		private void SetManualActivityStart(DateTime value, bool markTouched)
		{
			manualActivityInputUpdating = true;
			manualActivityDatePicker.Value = value.Date;
			manualActivityStartTimePicker.Value = value;
			manualActivityInputUpdating = false;
			manualActivityStartTouched = markTouched;
		}

		private void UpdateManualActivityEndPreview()
		{
			if (!int.TryParse(manualActivityDurationInputBox.Text, out int durationMinutes) || durationMinutes <= 0)
			{
				manualActivityEndPreviewLabel.Text = "Konec: --:--";
				return;
			}

			DateTime durationTo = GetManualActivityStart().AddMinutes(durationMinutes);
			manualActivityEndPreviewLabel.Text = $"Konec: {durationTo:dd.MM. HH:mm}";
		}

		private void ApplySelectedManualActivityTemplate()
		{
			ActivityTemplateOption selectedTemplate = GetSelectedManualActivityTemplate();
			manualActivityInputUpdating = true;

			if (selectedTemplate.IsCustom)
			{
				manualActivityDescriptionInputBox.ReadOnly = false;
				manualActivityDescriptionInputBox.BackColor = System.Drawing.Color.White;
				manualActivityDescriptionInputBox.Text = string.Empty;
				manualActivityDurationInputBox.ReadOnly = false;
				manualActivityDurationInputBox.BackColor = System.Drawing.Color.White;
				manualActivityDurationInputBox.Text = string.Empty;
				manualActivityCountInputBox.Enabled = false;
				manualActivityCountInputBox.Text = "1";
			}
			else
			{
				manualActivityDescriptionInputBox.ReadOnly = true;
				manualActivityDescriptionInputBox.BackColor = System.Drawing.Color.WhiteSmoke;
				manualActivityDescriptionInputBox.Text = selectedTemplate.Job.Name;
				manualActivityDurationInputBox.ReadOnly = true;
				manualActivityDurationInputBox.BackColor = System.Drawing.Color.WhiteSmoke;
				manualActivityCountInputBox.Enabled = true;
				manualActivityCountInputBox.Text = "1";
				manualActivityDurationInputBox.Text = selectedTemplate.DurationMinutes.ToString();
				SetManualActivityStart(DateTime.Now.AddMinutes(-selectedTemplate.DurationMinutes), false);
			}

			manualActivityInputUpdating = false;
			UpdateManualActivityEndPreview();
		}

		private void UpdateSelectedJobDurationFromCount()
		{
			ActivityTemplateOption selectedTemplate = GetSelectedManualActivityTemplate();
			if (selectedTemplate.IsCustom)
				return;
			if (!int.TryParse(manualActivityCountInputBox.Text, out int jobCount) || jobCount <= 0)
			{
				manualActivityDurationInputBox.Text = string.Empty;
				UpdateManualActivityEndPreview();
				return;
			}

			int durationMinutes = selectedTemplate.DurationMinutes * jobCount;
			manualActivityInputUpdating = true;
			manualActivityDurationInputBox.Text = durationMinutes.ToString();
			SetManualActivityStart(DateTime.Now.AddMinutes(-durationMinutes), false);
			manualActivityInputUpdating = false;
			UpdateManualActivityEndPreview();
		}

		private ActivityTemplateOption GetSelectedManualActivityTemplate()
		{
			return manualActivityTemplateBox.SelectedItem as ActivityTemplateOption ?? ManualActivityTemplateReference.First();
		}

		private bool IsCustomManualActivitySelected()
		{
			return GetSelectedManualActivityTemplate().IsCustom;
		}

		private void SetManualActivityCount(string value)
		{
			manualActivityInputUpdating = true;
			manualActivityCountInputBox.Text = value;
			manualActivityInputUpdating = false;
		}

		private void orderNumberInputBox_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void searchParcelsButton_Click(object sender, EventArgs e)
		{
			var dialog = new SearchParcelDialog();
			dialog.ShowDialog();
		}

		private void penalizationButton_Click(object sender, EventArgs e)
		{
			var dialog = new WarehousePasswordDialog("Zadejte heslo pro administraci penalizací");
			dialog.ShowDialog();
			if (dialog.DialogResult == DialogResult.OK)
			{
				if (CryptoHelper.GenerateSHA256Hash(dialog.input) == AdminSettings.Misc.PenalizationPasswordHash)
				{
					PenalizationForm form = new PenalizationForm();
					form.Show();
					form.Focus();
					form.PenalizationFinished += PenalizationForm_PenalizationFinished;
				}
				else
					DialogService.ShowError("Penalizace", "Špatně zadané heslo.");
			}
		}
		private void PenalizationForm_PenalizationFinished(object sender, EventArgs e)
		{
			UpdateManagerTextFields();
		}

		private sealed class ActivityTemplateOption
		{
			private ActivityTemplateOption(Job job)
			{
				Job = job;
			}

			public Job Job { get; }
			public bool IsCustom => Job == null;
			public int DurationMinutes => Job == null ? 0 : Job.DurationInSeconds / 60;

			public static ActivityTemplateOption Custom()
			{
				return new ActivityTemplateOption(null);
			}

			public static ActivityTemplateOption FromJob(Job job)
			{
				return new ActivityTemplateOption(job);
			}

			public override string ToString()
			{
				return IsCustom ? CustomManualActivityText : $"{Job.Name} ({DurationMinutes} min)";
			}
		}
	}
}
