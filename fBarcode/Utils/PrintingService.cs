using System.Drawing.Printing;
using System.IO;
using fBarcode.Logging;
using Spire.Pdf;

namespace fBarcode.Utils
{
	public static class PrintingService
	{
		static string printerName = AdminSettings.GetSettingValue("printerName");

		public static void printCourierLabel(byte[] rawPdf)
		{
			using (PdfDocument doc = new(rawPdf))
			{
				doc.PrintSettings.PrinterName = printerName;
                doc.PrintSettings.PrintController = new StandardPrintController();
                doc.PrintSettings.PaperSize = new PaperSize("A6", 105, 148);
				doc.Print();
			}
        }
        public static void saveCourierLabel(byte[] rawPdf, string path)
		{
			File.WriteAllBytes(path, rawPdf);
		}
		
	}
}

