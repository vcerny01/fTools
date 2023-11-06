using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using fBarcode.Logging;

namespace fBarcode.Utils
{
	public static class PrintingService
	{
		private static string PrinterName = AdminSettings.Misc.PrinterName;
		private static string SumatraPath = AdminSettings.Misc.SumatraPath;

		public static void PrintCourierLabel(byte[] rawPdf)
		{
			string pdfPath = Path.Combine(Path.GetTempPath(), "CourierLabel.pdf");
			File.WriteAllBytes(pdfPath, rawPdf);
			using (Process sumatra = new Process())
			{
				sumatra.StartInfo.FileName = SumatraPath;
				sumatra.StartInfo.Arguments = "-print-to " + '"' + PrinterName + '"' + " \"" + pdfPath + "\"" + " -print-settings \"portrait\"" + " -exit-on-print";
				sumatra.Start();
				sumatra.WaitForExit();
			}
		}
		public static void SaveCourierLabel(byte[] rawPdf)
		{
			string pdfPath;
			using (var saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				saveFileDialog.Title = "Zvolte lokaci pro uložení PDF štítku";
				saveFileDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
				while(true)
				{
					DialogResult result = saveFileDialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						pdfPath = saveFileDialog.FileName;
						break;
					}
				}
			}
			File.WriteAllBytes(pdfPath, rawPdf);
		}
	}
}