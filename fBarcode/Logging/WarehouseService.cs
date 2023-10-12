using System;
using System.IO;
using System.Data.SQLite;
using fBarcode.Fichema;
using fBarcode.Utils;
using fBarcode.UI.Dialogs;
using fBarcode.Logging.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using Tables = fBarcode.Utils.Constants.WarehouseTables;
using DbType = System.Data.DbType;
using System.Text;

namespace fBarcode.Logging
{
	internal static class WarehouseService
	{
		private static string dbPath;
		private static string dbPasswordHash;
		private static string dbConnectionString;

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

        internal static List<Worker> GetWorkers()
		{
			var workers = new List<Worker>();
			var command = new SQLiteCommand($"SELECT * FROM {Tables.WorkerTable}");
			using (var reader = ExecuteReaderCommand(command))
			{
				while(reader.Read())
				{
					var worker = new Worker((string)reader["Name"], (Guid)reader["Id"], (DateTime)reader["TimeStamp"]);
					workers.Add(worker);
				}
			}
			return workers;
		}
		public static void SetWorkers(List<Worker> workers)
		{
			List<SQLiteCommand> commands = new List<SQLiteCommand>();
			commands.Add(new SQLiteCommand($"DELETE FROM {Tables.WorkerTable}"));
			foreach (Worker worker in workers)
			{
				var command = new SQLiteCommand($"INSERT INTO {Tables.WorkerTable} (TimeStamp, Id, Name) VALUES (@TimeStamp, @Id, @Name)");
                command.Parameters.Add(new SQLiteParameter("@TimeStamp", DbType.DateTime) { Value =  worker.TimeStampCreation});
                command.Parameters.Add(new SQLiteParameter("@Id", DbType.Guid) { Value = worker.Id });
                command.Parameters.Add(new SQLiteParameter("@Name", DbType.String) { Value = worker.Name });
            }
            ExecuteVoidCommands(commands.ToArray());
        }
		internal static List<Job> GetJobs()
		{
            var jobs = new List<Job>();
            var command = new SQLiteCommand($"SELECT * FROM {Tables.JobTable}");
            using (var reader = ExecuteReaderCommand(command))
            {
                while (reader.Read())
                {
                    var job = new Job((string)reader["Name"], (Guid)reader["Id"], (int)reader["Valuation"], (DateTime)reader["TimeStamp"]);
                    jobs.Add(job);
                }
            }
            return jobs;
        }
		public static void SetJobs(List<Job> jobs)
		{
            List<SQLiteCommand> commands = new List<SQLiteCommand>();
            commands.Add(new SQLiteCommand($"DELETE FROM {Tables.JobTable}"));
            foreach (Job job in jobs)
            {
                var command = new SQLiteCommand($"INSERT INTO {Tables.JobTable} (TimeStamp, Id, Name, Valuation) VALUES (@TimeStamp, @Id, @Name, @Valuation)");
                command.Parameters.Add(new SQLiteParameter("@TimeStamp", DbType.DateTime) { Value = job.TimeStampCreation });
                command.Parameters.Add(new SQLiteParameter("@Id", DbType.Guid) { Value = job.Id });
                command.Parameters.Add(new SQLiteParameter("@Name", DbType.String) { Value = job.Name });
                command.Parameters.Add(new SQLiteParameter("@Valuation", DbType.Int32) { Value = job.Valuation });
            }
            ExecuteVoidCommands(commands.ToArray());
        }
        internal static void LogParcel(Parcel parcel, Worker worker)
		{
			var command = new SQLiteCommand($"INSERT INTO {Tables.ParcelTable} (TimeStamp, WorkerId, OrderNumber) VALUES  (@TimeStamp, @WorkerId, @OrderNumber)");
            command.Parameters.Add(new SQLiteParameter("@TimeStamp", DbType.DateTime) { Value = DateTime.Now });
			command.Parameters.Add(new SQLiteParameter("@WorkerId", DbType.Guid) { Value = worker.Id });
			command.Parameters.Add(new SQLiteParameter("@OrderNumber", DbType.String) { Value = parcel.OrderNumber });
			ExecuteVoidCommands(new SQLiteCommand[] { command });
        }
		// Since parcel and activity tables are created new for each year, GetFinishedParcels(), and GetPastActivities() both return all objects from the current year
		internal static List<FinishedParcel> GetFinishedParcels()
		{
			var command = new SQLiteCommand($"SELECT * FROM {Tables.ParcelTable}");
			var parcels = new List<FinishedParcel>();
			using (var reader = ExecuteReaderCommand(command))
			{
				while (reader.Read())
				{
					var parcel = new FinishedParcel((DateTime)reader["TimeStamp"], (Guid)reader["Id"], (string)reader["OrderNumber"]);
					parcels.Add(parcel);
				}
			}
			return parcels;
		}

		internal static void LogActivity(Activity activity)
		{
            var command = new SQLiteCommand($"INSERT INTO {Tables.ParcelTable} (TimeStamp, JobId, WorkerId, Duration, Earning, OrderNumber) VALUES  (@TimeStamp, @JobId, @WorkerId, @Duration, @Earning, @OrderNumber)");
			command.Parameters.Add(new SQLiteParameter("@TimeStamp", DbType.DateTime) { Value = activity.TimeStampCreation });
            command.Parameters.Add(new SQLiteParameter("@JobId", DbType.Guid) { Value = activity.JobId });
            command.Parameters.Add(new SQLiteParameter("@WorkerId", DbType.Guid) { Value = activity.WorkerId });
            command.Parameters.Add(new SQLiteParameter("@Duration", DbType.Int32) { Value = activity.Duration });
			command.Parameters.Add(new SQLiteParameter("@Earning", DbType.Decimal) { Value = activity.Earning });
            command.Parameters.Add(new SQLiteParameter("@OrderNumber", DbType.String) { Value = activity.OrderNumber });

        }
        internal static List<Activity> GetPastActivities()
		{
			var command = new SQLiteCommand($"SELECT * FROM {Tables.ActivityTable}");
			var activities = new List<Activity>();
			using (var reader = ExecuteReaderCommand(command))
			{
				while (reader.Read())
				{
					var activity = new Activity((Guid)reader["JobId"], (Guid)reader["WorkerId"], (int)reader["Duration"], (decimal)reader["Duration"], (DateTime)reader["TimeStamp"], Convert.IsDBNull(reader["OrderNumber"]) ? null : (string)reader["orderNumber"]);
					activities.Add(activity);
				}
			}
			return activities;
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
			string[] dotfilePayload = new string[] { dbPath, CryptoHelper.GenerateSHA256Hash(password) };
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
							string calculatedHash = CryptoHelper.GenerateSHA256Hash(password);
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
				using (var connection = new SQLiteConnection(dbConnectionString))
				{
					connection.Open();
					connection.Close();
                    return true;

                }
            }
			catch (Exception)
			{
				return false;
			}
		}
        private static void ExecuteVoidCommands(SQLiteCommand[] commands)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbConnectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (SQLiteCommand command in commands)
                        {
                            command.Connection = connection;
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        DialogService.ShowError("Operace na databázi se nepovedla", ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
		private static SQLiteDataReader ExecuteReaderCommand(SQLiteCommand command)
		{
			using (SQLiteConnection connection = new SQLiteConnection(dbConnectionString))
			{
				connection.Open();
				using (SQLiteTransaction transaction = connection.BeginTransaction())
				{
					try
					{
						command.Connection = connection;
						command.Transaction = transaction;
						return command.ExecuteReader();
					}
                    catch (Exception ex)
                    {
                        DialogService.ShowError("Operace na databázi se nepovedla", ex.Message);
                        transaction.Rollback();
						return null;
                    }
                }
			}
		}
    }
}