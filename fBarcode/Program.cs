using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using fBarcode.Logging;
using fBarcode.UI;
using fBarcode.Utils;

namespace fBarcode
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		// I could at least pretend that I exit safely
		public static void SafelyExit()
		{
			// TO DO
		}
	}
}
