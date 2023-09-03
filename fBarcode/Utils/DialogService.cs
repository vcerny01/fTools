using System;
using System.Windows.Forms;
using fBarcode;

namespace fBarcode.Utils
{
	public static class DialogService
	{
		public static void ShowMessage (string title, string message)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		public static void ShowError(string title, string message)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}