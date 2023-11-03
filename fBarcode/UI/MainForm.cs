using System;
using fBarcode.Logging;
using fBarcode.Utils;
using fBarcode.UI.Dialogs;
using fBarcode.Fichema;
using System.Windows.Forms;
using fBarcode.Logging.Models;
using Microsoft.VisualBasic.Logging;

namespace fBarcode.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			AdminSettings.Initialize();
			WarehouseManager.CheckIntegrity();
			UpdateWorkerOptions(WarehouseManager.GetWorkerNames());
			UpdateJobOptions(WarehouseManager.GetJobNames());
			Focus();
		}

		public void UpdateWorkerOptions(string[] workerNames)
		{
			chooseProfileBox.Items.Clear();
			chooseProfileBox.Items.AddRange(workerNames);
		}
		public void UpdateJobOptions(string[] jobNames)
		{
			chooseJobBox.Items.Clear();
			chooseJobBox.Items.AddRange(jobNames);
		}

		private void createParcelButton_Click(object sender, EventArgs e)
		{
			ParcelPreferences parcelPreferences = new ParcelPreferences(multiParcelCheckBox.Checked, eveningParcelCheckBox.Checked, saveBarcodeCheckBox.Checked, confirmParcelCheckBox.Checked);
			Parcel parcel;
			//try
			//{
			createParcelButton.Enabled = false;
			orderNumberInputBox.Enabled = false;
			parcelProgressLabel.Text = "Vytvářím novou zásilku z databáze faktur";
			parcel = Parcel.createParcel(orderNumberInputBox.Text, parcelPreferences);
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
			var label = parcel.GetLabel();
			parcelProgressBar.PerformStep();
			//}
			//catch (Exception ex)
			//{
			//	DialogService.ShowError("Chyba při zpracování objednávky", ex.Message);
			//	EndCurrentParcel();
			//	return;
			//}
			if (parcelPreferences.SaveCourierLabel)
			{
				PrintingService.saveCourierLabel(label, Constants.DefaultPdfPath);
				parcelProgressLabel.Text = "Ukládám štítek na disk";
			}
			else
			{
				PrintingService.printCourierLabel(label);
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
			orderNumberInputBox.Enabled = true;
			parcelInfoBox.Text = "";
			parcelProgressBar.Value = 0;
		}
		private void ShowParcelInfo(Parcel parcel)
		{
			parcelInfoBox.Multiline = true;
			parcelInfoBox.Text = $"Číslo faktury: {parcel.OrderNumber}\r\n" +
				$"Variabilní symbol: {parcel.VariableSymbol}\r\n" +
				$"Dopravce: {parcel.CourierName}\r\n" +
				$"Hmotnost: {parcel.Weight}\r\n" +
				$"Cena: {parcel.Price}\r\n" +
				$"Jméno příjemce: {parcel.recipient.FirstName} {parcel.recipient.LastName}\r\n" +
				$"Adresa: {parcel.recipient.Street} {parcel.recipient.HouseNumber}, {parcel.recipient.City}\r\n" +
				$"Telefon: {parcel.recipient.PhoneNumber}\r\n";
		}

		private void orderNumberInputBox_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(orderNumberInputBox.Text, out _))
				createParcelButton.Enabled = true;
		}

		private void importButton_Click(object sender, EventArgs e)
		{
			var form = new ImportForm();
			form.Show();
			UpdateWorkerOptions(WarehouseManager.GetWorkerNames());
			UpdateJobOptions(WarehouseManager.GetJobNames());
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			var form = new ExportForm();
			form.Show();
		}

		private void addActivityButton_Click(object sender, EventArgs e)
		{
			int count = int.Parse(activityCountInputBox.Text);
			activityCountInputBox.Text = "";
			WarehouseManager.AddActivity(new Activity(WarehouseManager.ActiveJob, WarehouseManager.ActiveWorker, count));
			UpdateManagerTextFields();
		}
		private void UpdateManagerTextFields()
		{
			overviewBox.Text = WarehouseManager.GenerateOverviewText();
			activityLogBox.Text = WarehouseManager.GenerateLogText();
		}
	}
}