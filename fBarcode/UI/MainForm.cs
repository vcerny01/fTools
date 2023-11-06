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

namespace fBarcode.UI
{
	public partial class MainForm : Form
	{
		List<KeyValuePair<Guid, string>> WorkerReference = new();
		List<KeyValuePair<Guid, string>> JobReference = new();
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
			UpdateJobOptions(WarehouseManager.GetJobNames());
			WarehouseManager.SetActiveWorker(WorkerReference[0].Key);
			WarehouseManager.SetActiveJob(JobReference[0].Key);
			chooseProfileBox.SelectedIndex = 0;
			chooseJobBox.SelectedIndex = 0;
			activityCountInputBox.Text = "1";
			UpdateManagerTextFields();
			Focus();
		}

		private void UpdateWorkerOptions(List<KeyValuePair<Guid, string>> workerOptions)
		{
			WorkerReference = workerOptions;
			chooseProfileBox.Items.Clear();
			chooseProfileBox.Items.AddRange(WorkerReference.Select(kvp => kvp.Value).ToArray());
		}
		private void UpdateJobOptions(List<KeyValuePair<Guid, string>> jobOptions)
		{
			JobReference = jobOptions;
			chooseJobBox.Items.Clear();
			chooseJobBox.Items.AddRange(JobReference.Select(kvp => kvp.Value).ToArray());
		}

		private void createParcelButton_Click(object sender, EventArgs e)
		{
			StartParcel();
		}

		private void StartParcel()
		{
			string orderNumber = orderNumberInputBox.Text.Trim();
			byte[] label;
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
			catch (Exception ex)
			{
				DialogService.ShowError("Chyba při zpracování objednávky", ex.Message);
				EndCurrentParcel();
				return;
			}
			if (parcelPreferences.SaveCourierLabel)
			{
				PrintingService.SaveCourierLabel(label);
				parcelProgressLabel.Text = "Ukládám štítek na disk";
			}
			else
			{
				PrintingService.PrintCourierLabel(label);
				parcelProgressLabel.Text = "Posílám štítek k tisku";
			}
			parcelProgressBar.PerformStep();
			parcelProgressLabel.Text = "Ukládám informace o zpracované zásilce do databáze";
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
				_ => null
			};
			WarehouseManager.AddActivity(new Activity(parcelJob, WarehouseManager.ActiveWorker, 1, parcel.OrderNumber));
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
			if (activityCountInputBox.Text == string.Empty)
				activityCountInputBox.Text = "1";
			int count = int.Parse(activityCountInputBox.Text);
			activityCountInputBox.Text = "";
			WarehouseManager.AddActivity(new Activity(WarehouseManager.ActiveJob, WarehouseManager.ActiveWorker, count));
			activityCountInputBox.Text = "1";
			UpdateManagerTextFields();
		}
		private void UpdateManagerTextFields()
		{
			overviewBox.Text = WarehouseManager.GenerateOverviewText();
			activityLogBox.Text = WarehouseManager.GenerateLogText();
		}

		private void chooseJobBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			WarehouseManager.SetActiveJob(JobReference[chooseJobBox.SelectedIndex].Key);
			UpdateManagerTextFields();
		}

		private void chooseProfileBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			WarehouseManager.SetActiveWorker(WorkerReference[chooseProfileBox.SelectedIndex].Key);
			UpdateManagerTextFields();
		}

		private void activityCountInputBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void activityCountInputBox_TextChanged(object sender, EventArgs e)
		{
			int maxLength = 3;
			if (activityCountInputBox.Text.Length > maxLength)
			{
				activityCountInputBox.Text = activityCountInputBox.Text.Substring(0, maxLength);
				activityCountInputBox.SelectionStart = maxLength;
			}
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