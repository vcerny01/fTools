using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fBarcode.UI.Dialogs
{
	public partial class WarehousePasswordDialog : Form
	{
		public string input;
		public WarehousePasswordDialog(string caption = "Zadejte heslo ke skladové databázi")
		{
			InitializeComponent();
			this.Text = caption;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			input = textBox1.Text;
			textBox1.Text = null;
		}
	}
}
