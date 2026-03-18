using fBarcode.Logging;
using fBarcode.Utils;
using System;
using System.Windows.Forms;
using System.Linq;

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
			var workers = CsvService.Import.LoadWorkers();
			if (workers == null) return;
			WarehouseManager.SetWorkers(workers);
			CloseForm();
		}

		private void jobsImportButton_Click(object sender, EventArgs e)
		{
			var jobs = CsvService.Import.LoadJobs();
			if (jobs == null) return;
			WarehouseManager.SetJobs(jobs);
			CloseForm();
		}

		private void activitiesImportButton_Click(object sender, EventArgs e)
		{
			var activities = CsvService.Import.LoadActivities();
			if (activities == null) return;
			WarehouseManager.AddActivities(activities);
			CloseForm();
		}

		private void finishedParcelsImportButton_Click(object sender, EventArgs e)
		{
			var parcels = CsvService.Import.LoadParcels();
			if (parcels == null) return;
			WarehouseManager.AddFinishedParcels(parcels);
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
