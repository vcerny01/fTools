using System;
using System.Windows.Forms;

namespace fBarcode.UI.Dialogs
{
	public partial class MultiParcelDialog : Form
	{
		public string input;
		public MultiParcelDialog()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			input = textBox1.Text;
			textBox1.Text = null;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void MultiParcelDialog_Load(object sender, EventArgs e)
		{

		}
	}
}
