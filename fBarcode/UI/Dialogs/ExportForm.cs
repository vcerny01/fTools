using fBarcode.Logging;
using fBarcode.Utils;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tables = fBarcode.Utils.Constants.WarehouseTables;
using System.Windows.Forms;

namespace fBarcode.UI.Dialogs
{
	public partial class ExportForm : Form
	{
		public ExportForm()
		{
			InitializeComponent();
		}

		private void createReportButton_Click(object sender, EventArgs e)
		{

		}

		private void workersExportButton_Click(object sender, EventArgs e)
		{
			CsvService.Export.WriteWorkers(WarehouseManager.Workers.ToArray());
		}

		private void jobsExportButton_Click(object sender, EventArgs e)
		{
			CsvService.Export.WriteJobs(WarehouseManager.Jobs.ToArray());
		}

		private void activitiesExportButton_Click(object sender, EventArgs e)
		{
			CsvService.Export.WriteActivities(WarehouseService.GetPastActivities().ToArray());
		}

		private void finishedParcelsExportButton_Click(object sender, EventArgs e)
		{
			CsvService.Export.WriteFinishedParcels(WarehouseService.GetFinishedParcels().ToArray());
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			string input = deleteInputBox.Text;
			deleteInputBox.Text = "";
			if (input == "old")
			{
				WarehouseService.ClearOldRecords();
			}
			else
			{
				string[] inputArray = input.Split(",");
				string table = inputArray[0];
				string[] tables = new string[] { Tables.WorkerTable, Tables.JobTable, Tables.ParcelTable, Tables.ActivityTable };
				if (tables.Contains(table))
				{
					try
					{
						WarehouseService.DeleteRecords(inputArray.Skip(1).ToArray().Select(Guid.Parse).ToArray(), table);
					}
					catch (Exception)
					{
						DialogService.ShowError("Vadný příkaz", "Příkaz pro vymazání nemohl být proveden.");
					}
				}
			}
		}
	}
}
