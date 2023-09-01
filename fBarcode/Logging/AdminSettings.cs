using CsvHelper;
using fBarcode.Utils;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using fBarcode.Exceptions;
using System;
using System.Windows.Forms;

namespace fBarcode.Logging
{
	public static class AdminSettings
	{
		private static List<Setting> _settings;
		private static string _settingsPath = Constants.adminSettingsPath;

		static AdminSettings()
		{
			try 
			{
				_settings = GetSettings();
				ValidateSettings();
			}
			catch (Exception e)
			{
				DialogService.ShowError("Chyba při načítání nastavení", e.Message);
				Application.Exit();
			} 
		}
		public static string GetSettingValue(string key)
		{
			foreach (Setting setting in _settings)
			{
				if (key == setting.SettingKey)
				{
					return setting.SettingValue;
				}
			}
			return null;
		}
		private static List<Setting> GetSettings()
		{
			if (!File.Exists(_settingsPath))
			{
				throw new AdminSettingsNotFoundException(_settingsPath);
			}
			using var reader = new StreamReader(_settingsPath);
			using var csv = new CsvReader(reader, Constants.csvConfig);
			return csv.GetRecords<Setting>().ToList();
		}
		private static void ValidateSettings()
		{
			HashSet<string> settingKeys = new HashSet<string>();
			HashSet<string> expectedKeys =  new HashSet<string>(Constants.requiredAdminSettingsKeys);
			foreach (Setting setting in _settings)
			{
				settingKeys.Add(setting.SettingKey); 
			}
			expectedKeys.ExceptWith(settingKeys);
			if (expectedKeys.Count != 0)
			{
				throw new AdminSettingsIncompleteException(expectedKeys);
			}
		}
		private class Setting
		{
			public string SettingKey { get; private set;}
			public string SettingValue { get; private set; }
			public Setting(string key, string value)
			{
				SettingKey = key;
				SettingValue = value;
			}
		}
	}
}


