﻿using System;
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
	}
}
