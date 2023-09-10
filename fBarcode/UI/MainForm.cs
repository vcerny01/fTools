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
			parcelProgressBar.Step = 25;
			chooseProfileBox.Items.Add("Jan Novák");
		}

		private void createParcelButton_Click(object sender, EventArgs e)
		{
			ParcelPreferences parcelPreferences = new ParcelPreferences(multiParcelCheckBox.Checked, eveningParcelCheckBox.Checked, saveBarcodeCheckBox.Checked, confirmParcelCheckBox.Checked);
			Parcel parcel;
			try
			{
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
			}
			catch (Exception ex)
			{
				DialogService.ShowError("Chyba při zpracování objednávky", ex.Message);
				EndCurrentParcel();
				return;
			}
            if (parcelPreferences.SaveCourierLabel)
            {
                PrintingService.saveCourierLabel(parcel.GetLabel(), Constants.DefaultPdfPath);
				parcelProgressLabel.Text = "Ukládám štítek na disk";
            }
            else
            {
                PrintingService.printCourierLabel(parcel.GetLabel());
				parcelProgressLabel.Text = "Posílám štítek k tisku";
            }
			parcelProgressBar.PerformStep();
			parcelProgressLabel.Text = "Ukládám informace o zpracované zásilce do databáze";
			try
			{
				LogParcel(parcel);
			} catch (Exception ex)
			{
				DialogService.ShowError("Chyba při zapisování zpracované zásilky do databáze", ex.Message);
			} finally
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
			parcelInfoBox.Text = $"Číslo faktury: {parcel.OrderNumber}" +
				$"Variabilní symbol: {parcel.VariableSymbol}" +
				$"Dopravce: {parcel.CourierName}" +
				$"Hmotnost: {parcel.Weight}" +
				$"Cena: {parcel.Price}" +
				$"Jméno příjemce: {parcel.recipient.FirstName} {parcel.recipient.LastName}" +
				$"Adresa: {parcel.recipient.Street} {parcel.recipient.HouseNumber}, {parcel.recipient.City}" +
				$"Telefon: {parcel.recipient.PhoneNumber}";
		}

		private void orderNumberInputBox_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(orderNumberInputBox.Text, out _))
			{
				createParcelButton.Enabled = true;
			}
		}
    }
}