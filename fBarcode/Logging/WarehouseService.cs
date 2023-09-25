using System;
using System.IO;
using System.Data.SQLite;
using fBarcode.Fichema;
using fBarcode.Utils;
using fBarcode.UI.Dialogs;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;

namespace fBarcode.Logging
{
	public static class WarehouseService
	{
		private static string dbPath;
		private static string dbPasswordHash;
		private static string dbConnectionString;
		private static string passwordHash = "";

		static WarehouseService()
		{
			try
			{
				string[] dotfileContent = File.ReadAllLines(Constants.DotfilePath);
				dbPath = dotfileContent[0];
				dbPasswordHash = dotfileContent[1];
				if (!Path.IsPathRooted(dbPath) || string.IsNullOrWhiteSpace(dbPasswordHash) || string.IsNullOrWhiteSpace(dbPasswordHash))
					SetupDatabase();
			}
			catch (Exception)
			{
				SetupDatabase();
			}
			string dbPassword = GetDatabasePassword(dbPasswordHash);
            dbConnectionString = $"Data Source={dbPath};Version=3;Password={dbPassword};";
			if (TestDatabaseConnection() == false)
			{
				DialogService.ShowError("Připojení ke skladové databázi selhalo", $"Připojení k databázi skladu selhalo. Restartujte aplikaci nebo kontaktujte technickou podporu.");
				System.Windows.Forms.Application.Exit();
			}
		}

        public static List<Worker> GetWorkers()
		{

		}
		public static void SetWorkers(List<Worker> workers)
		{

		}
		public static List<Job> GetJobs()
		{

		}
		public static void SetJobs(List<Job> jobs)
		{

		}
		public static void LogParcel(Parcel parcel, Worker worker)
		{

		}
		public static void LogActivity(Job job, int value)
		{

		}
		private static void SetupDatabase()
		{
			string password;
			string dirPath;
			string setupDialogTitle = "Nastavení lokální databáze";
			File.Delete(Constants.DotfilePath);
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				DialogService.ShowMessage(setupDialogTitle, "Je potřeba nastavit lokální databázi. Zvolíte složku pro novou nebo již existující databázi");
				folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
				folderBrowserDialog.Description = "Zvolte složku pro databázi";
				while(true)
				{
					DialogResult result = folderBrowserDialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						dirPath = folderBrowserDialog.SelectedPath;
						break;
					}
				}
			}
			dbPath = Path.Join(dirPath, Constants.WarehouseDatabaseFileName);
			if (File.Exists(dbPath))
			{
				DialogService.ShowMessage(setupDialogTitle, "Ve zvolené složce byla nalezena již existující databáze. Zadejte heslo k databázi, nebo databázi odstraňte a tuto aplikaci restartujte.");
				password = GetDatabasePassword();
				dbConnectionString = $"Data Source={dbPath};Version=3;Password={password};";
				if (TestDatabaseConnection() == false)
				{
					DialogService.ShowError(setupDialogTitle, "Připojení s daným heslem k databázi se nezdařilo. Restartujte aplikaci a zkuste to znovu, nebo vytvořte novou databázi.");
					Application.Exit();
				}
			} else
			{
				while (true)
				{
					DialogService.ShowMessage(setupDialogTitle, "Zadejte nové heslo.");
					string password1 = GetDatabasePassword();
					DialogService.ShowMessage(setupDialogTitle, "Zadejte heslo znovu.");
					string password2 = GetDatabasePassword();
					if (password1 == password2)
					{
						password = password1;
						if (TestDatabaseConnection() == false)
						{
							DialogService.ShowMessage(setupDialogTitle, "Vytvoření nové databáze selhalo. Zkuste to znovu nebo kontaktujte technickou podporu.");
							Application.Exit();
						}
						break;
					}
				}
			}
			File.WriteAllText(Path.Join(dirPath, "warehouseDB_README.txt"), "warehouseDB.sqlite obsahuje data aplikace ");
			string[] dotfilePayload = new string[] { dbPath, GetPasswordSHA256Hash(password) };
			File.WriteAllLines(Constants.DotfilePath, dotfilePayload);
			DialogService.ShowMessage(setupDialogTitle, "Nastavení databáze bylo úspěšně dokončeno, restartujte aplikaci a zadejte heslo.");
			Application.Exit();
			// Prompt to load CSV configs
		}
		private static string GetDatabasePassword(string hash = null)
		{
			WarehousePasswordDialog dialog = new();
			while (true)
			{
				dialog.ShowDialog();
				if (dialog.DialogResult == DialogResult.OK)
				{
					string password = dialog.input;
					if (!string.IsNullOrWhiteSpace(password))
					{
						if (hash != null)
						{
							string calculatedHash = GetPasswordSHA256Hash(password);
							if (hash != calculatedHash)
							{
								DialogService.ShowError("Neplatné heslo", "Špatně zadané heslo, zkuste to znovu.");
								continue;
							} else
							{
								return password;
							}
						} else
						{
							return password;
						}
					}
				}
			}
		}
		private static bool TestDatabaseConnection() // Also creates new database if at given path in dbConnectionString it doesn't exist
		{
			try
			{
				var connection = new SQLiteConnection(dbConnectionString);
				connection.Open();
				connection.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		private static string GetPasswordSHA256Hash(string password)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				// Compute the hash from the password string
				byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
				byte[] hashBytes = sha256.ComputeHash(passwordBytes);

				// Convert the byte array to a hexadecimal string
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					builder.Append(hashBytes[i].ToString("x2"));
				}

				return builder.ToString();
			}
		}
	}
}