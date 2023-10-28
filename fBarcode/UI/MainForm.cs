using System;
using fBarcode.Logging;
using fBarcode.Utils;
using fBarcode.UI.Dialogs;
using fBarcode.Fichema;
using System.Windows.Forms;

namespace fBarcode.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			AdminSettings.Initialize();
			WarehouseManager.CheckIntegrity();
			parcelProgressBar.Step = 25;
			chooseProfileBox.Items.Add("Jan Novák");
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
			try
			{
				LogParcel(parcel);
			}
			catch (Exception ex)
			{
				DialogService.ShowError("Chyba při zapisování zpracované zásilky do databáze", ex.Message);
			}
			finally

			{
				parcelProgressBar.PerformStep();
				parcelProgressLabel.Text = "Zásilka zpracována";
				EndCurrentParcel();
			}
		}

		private void LogParcel(Parcel parcel)
		{

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
			{
				createParcelButton.Enabled = true;
			}
		}

		private void importButton_Click(object sender, EventArgs e)
		{
			var form = new ImportForm();
			form.Show();
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			var form = new ExportForm();
			form.Show();
		}

		private void addActivityButton_Click(object sender, EventArgs e)
		{
			// ADD ACTIVITY
		}  
	}
}