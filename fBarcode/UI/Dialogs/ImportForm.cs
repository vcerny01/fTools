using fBarcode.Logging;
using fBarcode.Utils;
using System;
using System.Windows.Forms;

namespace fBarcode.UI.Dialogs
{
	public partial class ImportForm : Form
	{
		public ImportForm()
		{
			InitializeComponent();
		}

		private void workersImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.SetWorkers(CsvService.Import.LoadWorkers());
			Close();
		}

		private void jobsImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.SetWorkers(CsvService.Import.LoadWorkers());
			Close();
		}

		private void activitiesImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.AddActivities(CsvService.Import.LoadActivities());
			Close();
		}

		private void finishedParcelsImportButton_Click(object sender, EventArgs e)
		{
			WarehouseManager.AddFinishedParcels(CsvService.Import.LoadParcels());
			Close();
		}

		private void settingsImportButton_Click(object sender, EventArgs e)
		{
			AdminSettings.
		}
	}
}
