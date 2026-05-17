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
		List<KeyValuePair<Guid, string>> WorkerReference = new();
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
			string description = manualActivityDescriptionInputBox.Text.Trim();
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

			WarehouseManager.AddManualActivity(description, durationFrom, durationMinutes);
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
			int maxLength = 3;
			if (manualActivityDurationInputBox.Text.Length > maxLength)
			{
				manualActivityDurationInputBox.Text = manualActivityDurationInputBox.Text.Substring(0, maxLength);
				manualActivityDurationInputBox.SelectionStart = maxLength;
			}

			if (!manualActivityStartTouched && int.TryParse(manualActivityDurationInputBox.Text, out int durationMinutes) && durationMinutes > 0)
				SetManualActivityStart(DateTime.Now.AddMinutes(-durationMinutes), false);

			UpdateManualActivityEndPreview();
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
			SetManualActivityStart(DateTime.Now, false);
			UpdateManualActivityEndPreview();
		}

		private void ResetManualActivityInputs()
		{
			manualActivityDescriptionInputBox.Text = string.Empty;
			manualActivityDurationInputBox.Text = string.Empty;
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
	}
}
