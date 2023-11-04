using fBarcode.Logging;
using fBarcode.Logging.Models;
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
	public partial class PenalizationForm : Form
	{
		private Worker chosenWorker = WarehouseManager.ActiveWorker;
		public EventHandler PenalizationFinished;
		public PenalizationForm()
		{
			InitializeComponent();
			activeWorkerLabel.Text = $"Zvolený zaměstnanec: {chosenWorker.Name}";
			penalizatioinRateLabel.Text = $"Sazba za penalizaci: {WarehouseManager.PenalizationJob.DurationInSeconds / 60} min";
		}

		private void penalizationCountInputBox_TextChanged(object sender, EventArgs e)
		{
			int maxLength = 2;
			if (penalizationCountInputBox.Text.Length > maxLength)
			{
				penalizationCountInputBox.Text = penalizationCountInputBox.Text.Substring(0, maxLength);
				penalizationCountInputBox.SelectionStart = maxLength;
			}
		}

		private void penalizationCountInputBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}

		private void searchParcelButton_Click(object sender, EventArgs e)
		{
			if (penalizationCountInputBox.Text == string.Empty)
				penalizationCountInputBox.Text = "1";
			int count = int.Parse(penalizationCountInputBox.Text.Trim());
			WarehouseManager.AddActivity(new Activity(WarehouseManager.PenalizationJob, chosenWorker, count));
			PenalizationFinished.Invoke(this, EventArgs.Empty);
			Close();
		}
	}
}
