using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fBarcode.Logging;
using fBarcode.Utils;
using fBarcode.Fichema;
using System.Windows.Forms;

namespace fBarcode.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void createParcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Parcel parcel = Parcel.createParcel(orderNumberInputBox.Text);
            } catch (Exception ex)
            {
                DialogService.ShowError("Chyba při zpracování objednávky", ex.Message);
            }
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