using fBarcode.Logging;
using fBarcode.Utils;
using System;
using System.Windows.Forms;

namespace fBarcode.UI.Dialogs
{
	public partial class ImportForm : Form
	{
		public EventHandler ImportComplete;
		public ImportForm()
		{
			InitializeComponent();
		}

		private void workersImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.SetWorkers(CsvService.Import.LoadWorkers());
			CloseForm();
		}

		private void jobsImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.SetJobs(CsvService.Import.LoadJobs());
			CloseForm();
		}

		private void activitiesImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.AddActivities(CsvService.Import.LoadActivities());
			CloseForm();
		}

		private void finishedParcelsImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.AddFinishedParcels(CsvService.Import.LoadParcels());
			CloseForm();
		}

		private void settingsImportButton_Click(object sender, EventArgs e)
		{
			AdminSettings.Set();
			CloseForm();
		}

		private void CloseForm()
		{
			ImportComplete?.Invoke(this, EventArgs.Empty);
			Close();
		}
	}
}
