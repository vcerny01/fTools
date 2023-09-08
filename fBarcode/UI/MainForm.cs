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
			chooseProfileBox.Items.Add("Jan Novák");
		}

		private void createParcelButton_Click(object sender, EventArgs e)
		{
			ParcelPreferences parcelPreferences = new ParcelPreferences(multiParcelCheckBox.Checked, eveningParcelCheckBox.Checked, saveBarcodeCheckBox.Checked, confirmParcelCheckBox.Checked);
			try
			{
				createParcelButton.Enabled = false;
				orderNumberInputBox.Enabled = false;
				Parcel parcel = Parcel.createParcel(orderNumberInputBox.Text, parcelPreferences);
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
			}
			catch (Exception ex)
			{
				DialogService.ShowError("Chyba při zpracování objednávky", ex.Message);
				return;
			}
		}

		private void EndCurrentParcel()
		{
			orderNumberInputBox.Enabled = true;
			parcelInfoBox.Text = "";
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