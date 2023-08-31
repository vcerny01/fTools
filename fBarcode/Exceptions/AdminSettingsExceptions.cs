using System;
using System.Collections.Generic;
using System.IO;
using fBarcode.Utils;

namespace fBarcode.Exceptions
{
	public class AdminSettingsNotFoundException : Exception
	{
		public override string Message { get; }
		public AdminSettingsNotFoundException(string settingsPath)
		{
			string settingsTemplate = "";
				foreach(string key in Constants.requiredAdminSettingsKeys)
				{
					settingsTemplate += $"{key};DOPLŇTE";
				}
			File.WriteAllText(settingsPath, settingsTemplate);
			Message = $"Byl vytvořen soubor {settingsPath}, doplňte pole nastavení.";
		}
	}
	
	public class AdminSettingsIncompleteException : Exception
	{
		public override string Message { get; }
		public AdminSettingsIncompleteException (HashSet<string> expectedKeys)
		{
			Message = "Doplňte následující chybějící pole v nastavneí:\n";
			foreach (string key in expectedKeys)
			{
				Message += key + "\n";
			} 
		}
	}
}