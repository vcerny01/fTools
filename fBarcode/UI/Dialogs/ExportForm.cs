using fBarcode.Logging;
using fBarcode.Utils;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tables = fBarcode.Utils.Constants.WarehouseTables;
using System.Windows.Forms;
using fBarcode.Logging.Models;

namespace fBarcode.UI.Dialogs
{
	public partial class ExportForm : Form
	{
		public Dictionary<string, Constants.DateSpan> reportOptions;
		public EventHandler ItemsDeleted;
		public ExportForm()
		{
			InitializeComponent();
			reportOptions = new()
			{
				{ "Den", Constants.DateSpan.Day },
				{ "Týden", Constants.DateSpan.Week },
				{ "Měsíc", Constants.DateSpan.Month },
				{ "Rok", Constants.DateSpan.Year }
			};
			reportTimeIntervalChooser.Items.AddRange(reportOptions.Keys.ToArray());
		}

		private void createReportButton_Click(object sender, EventArgs e)
		{
			Constants.DateSpan span = reportOptions[(string)reportTimeIntervalChooser.SelectedItem];
			CsvService.Export.WriteReport(span);
		}

		private void workersExportButton_Click(object sender, EventArgs e)
		{
			CsvService.Export.WriteWorkers(WarehouseManager.Workers.ToArray());
		}

		private void jobsExportButton_Click(object sender, EventArgs e)
		{
			CsvService.Export.WriteJobs(WarehouseManager.Jobs.Where(job => job.Id != WarehouseManager.PenalizationJob.Id).ToArray());
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
				string typeString = inputArray[0];
				Type type;
				switch (typeString)
				{
					case "W":
						type = typeof(Worker);
						break;
					case "J":
						type = typeof(Job);
						break;
					case "A":
						type = typeof(Activity);
						break;
					case "P":
						type = typeof(FinishedParcel);
						break;
					default:
						type = null;
						break;
				}
				if (type != null)
				{
					try
					{
						WarehouseManager.DeleteItems(type, inputArray.Skip(1).ToArray().Select(Guid.Parse).ToArray());
						ItemsDeleted.Invoke(this, EventArgs.Empty);
					}
					catch (Exception)
					{
						DialogService.ShowError("Vadný příkaz", "Příkaz pro vymazání nemohl být proveden. 1");
					}
				}
				else
					DialogService.ShowError("Vadný příkaz", "Příkaz pro vymazání nemohl být proveden. 2");
			}
		}
	}
}
