using System;
using System.Data.SqlServerCe;
using System.IO;
using fBarcode.Fichema;
using fBarcode.Utils;
using fBarcode.UI.Dialogs;
using fBarcode.Logging.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using Tables = fBarcode.Utils.Constants.WarehouseTables;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            InitializeDatabase();
            BuildTables();
        }

        internal static List<Worker> GetWorkers()
        {
            var workers = new List<Worker>();
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"SELECT * FROM {Tables.WorkerTable}", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var worker = new Worker((string)reader["Name"], (Guid)reader["Id"], (DateTime)reader["TimeStamp"]);
                        workers.Add(worker);
                    }
                }
            }
            return workers;
        }

        /// <summary>
        /// Sets the list of workers in the database.
        /// </summary>
        /// <param name="workers">The list of workers to set.</param>
        public static void SetWorkers(List<Worker> workers)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var deleteCommand = new SqlCeCommand($"DELETE FROM {Tables.WorkerTable}", connection, transaction);
                        deleteCommand.ExecuteNonQuery();

                        foreach (Worker worker in workers)
                        {
                            var insertCommand = new SqlCeCommand($"INSERT INTO {Tables.WorkerTable} (Id, TimeStamp, Name) VALUES (@Id, @TimeStamp, @Name)", connection, transaction);
                            insertCommand.Parameters.Add(new SqlCeParameter("@Id", SqlDbType.UniqueIdentifier) { Value = worker.Id });
							insertCommand.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = worker.TimeStampCreation });
							insertCommand.Parameters.Add(new SqlCeParameter("@Name", SqlDbType.NVarChar) { Value = worker.Name });
                            insertCommand.ExecuteNonQuery();
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

        internal static List<Job> GetJobs()
        {
            var jobs = new List<Job>();
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"SELECT * FROM {Tables.JobTable}", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var job = new Job((string)reader["Name"], (Guid)reader["Id"], (int)reader["DurationInSeconds"], (DateTime)reader["TimeStamp"]);
                        jobs.Add(job);
                    }
                }
            }
            return jobs;
        }

        public static void SetJobs(List<Job> jobs)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var deleteCommand = new SqlCeCommand($"DELETE FROM {Tables.JobTable}", connection, transaction);
                        deleteCommand.ExecuteNonQuery();

                        foreach (Job job in jobs)
                        {
                            var insertCommand = new SqlCeCommand($"INSERT INTO {Tables.JobTable} (Id, TimeStamp, Name, DurationInSeconds) VALUES (@Id, @TimeStamp, @Name, @DurationInSeconds)", connection, transaction);
                            insertCommand.Parameters.Add(new SqlCeParameter("@Id", SqlDbType.UniqueIdentifier) { Value = job.Id });
							insertCommand.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = job.TimeStampCreation });
							insertCommand.Parameters.Add(new SqlCeParameter("@Name", SqlDbType.NVarChar) { Value = job.Name });
                            insertCommand.Parameters.Add(new SqlCeParameter("@DurationInSeconds", SqlDbType.Int) { Value = job.DurationInSeconds });
                            insertCommand.ExecuteNonQuery();
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

        internal static void LogParcel(FinishedParcel finishedParcel)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"INSERT INTO {Tables.ParcelTable} (Id, TimeStamp, WorkerId, OrderNumber) VALUES (@Id,@TimeStamp, @WorkerId, @OrderNumber)", connection);
                command.Parameters.Add(new SqlCeParameter("@Id", SqlDbType.UniqueIdentifier) {Value = finishedParcel.Id});
                command.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = finishedParcel.TimeStampCreation });
                command.Parameters.Add(new SqlCeParameter("@WorkerId", SqlDbType.UniqueIdentifier) { Value = finishedParcel.WorkerId });
                command.Parameters.Add(new SqlCeParameter("@OrderNumber", SqlDbType.NVarChar) { Value = finishedParcel.OrderNumber });
                command.ExecuteNonQuery();
            }
        }

        internal static List<FinishedParcel> GetFinishedParcels(DateTime startInterval = default, DateTime endInterval = default)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var sqlQuery = $"SELECT * FROM {Tables.ParcelTable}";

                if (startInterval != default || endInterval != default)
                {
                    sqlQuery += " WHERE";
                    if (startInterval != default) sqlQuery += " TimeStamp >= @StartDate";
                    if (startInterval != default && endInterval != default) sqlQuery += " AND";
                    if (endInterval != default) sqlQuery += " TimeStamp <= @EndDate";
                }

                var command = new SqlCeCommand(sqlQuery, connection);

                if (startInterval != default) command.Parameters.AddWithValue("@StartDate", startInterval);
                if (endInterval != default) command.Parameters.AddWithValue("@EndDate", endInterval);

                var parcels = new List<FinishedParcel>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var parcel = new FinishedParcel((Guid)reader["Id"], (string)reader["OrderNumber"], (Guid)reader["WorkerId"], (DateTime)reader["TimeStamp"]);
                        parcels.Add(parcel);
                    }
                }
                return parcels;
            }
        }

		internal static void LogActivity(Activity activity)
		{
			using (var connection = new SqlCeConnection(dbConnectionString))
			{
				connection.Open();
				var command = new SqlCeCommand($"INSERT INTO {Tables.ActivityTable} (Id ,TimeStamp, JobId, WorkerId, JobCount, Duration, Earning, OrderNumber) VALUES (@Id, @TimeStamp, @JobId, @WorkerId, @JobCount, @Duration, @Earning, @OrderNumber)", connection);
				command.Parameters.Add(new SqlCeParameter("@Id", SqlDbType.UniqueIdentifier) { Value = activity.Id });
				command.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = activity.TimeStampCreation });
				command.Parameters.Add(new SqlCeParameter("@JobId", SqlDbType.UniqueIdentifier) { Value = activity.JobId });
				command.Parameters.Add(new SqlCeParameter("@WorkerId", SqlDbType.UniqueIdentifier) { Value = activity.WorkerId });
				command.Parameters.Add(new SqlCeParameter("@JobCount", SqlDbType.Int) { Value = activity.JobCount });
				command.Parameters.Add(new SqlCeParameter("@Duration", SqlDbType.Int) { Value = activity.Duration });
				command.Parameters.Add(new SqlCeParameter("@Earning", SqlDbType.Decimal) { Value = activity.Earning });

				if (activity.OrderNumber != null)
					command.Parameters.Add(new SqlCeParameter("@OrderNumber", SqlDbType.NVarChar) { Value = activity.OrderNumber });
				else
					command.Parameters.Add(new SqlCeParameter("@OrderNumber", SqlDbType.NVarChar) { Value = DBNull.Value });
				command.ExecuteNonQuery();
			}
		}


		internal static List<Activity> GetPastActivities(DateTime startInterval = default, DateTime endInterval = default)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var sqlQuery = $"SELECT * FROM {Tables.ActivityTable}";

                if (startInterval != default || endInterval != default)
                {
                    sqlQuery += " WHERE";
                    if (startInterval != default) sqlQuery += " [TimeStamp] >= @StartDate";
                    if (startInterval != default && endInterval != default) sqlQuery += " AND";
                    if (endInterval != default) sqlQuery += " [TimeStamp] <= @EndDate";
                }

                var command = new SqlCeCommand(sqlQuery, connection);

                if (startInterval != default) command.Parameters.AddWithValue("@StartDate", startInterval);
                if (endInterval != default) command.Parameters.AddWithValue("@EndDate", endInterval);

                var activities = new List<Activity>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var activity = new Activity((Guid)reader["Id"], (Guid)reader["JobId"], (Guid)reader["WorkerId"], (int)reader["JobCount"], (int)reader["Duration"], (Decimal) reader["Earning"], (DateTime)reader["TimeStamp"], reader["OrderNumber"] as string);
                        activities.Add(activity);
                    }
                }
                return activities;
            }
        }

        internal static Dictionary<string,string> GetAdminSettings()
        {
             Dictionary<string, string> settings = new Dictionary<string, string>();

            using (SqlCeConnection connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                using (SqlCeCommand command = new SqlCeCommand("SELECT * FROM AdminSettings", connection))
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader[0].ToString();
                        string value = reader[1].ToString();
                        settings[key] = value;
                    }
                }
            }
            return settings;
        }

		internal static void SetAdminSettings(Dictionary<string, string> newSettings)
		{
			using (SqlCeConnection connection = new SqlCeConnection(dbConnectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						using (SqlCeCommand insertCommand = new SqlCeCommand("INSERT INTO AdminSettings ([Key], [Value]) VALUES (@Key, @Value)", connection, transaction))
						using (SqlCeCommand updateCommand = new SqlCeCommand("UPDATE AdminSettings SET [Value] = @Value WHERE [Key] = @Key", connection, transaction))
						{
							insertCommand.Parameters.Add(new SqlCeParameter("@Key", SqlDbType.NVarChar));
							insertCommand.Parameters.Add(new SqlCeParameter("@Value", SqlDbType.NVarChar));
							updateCommand.Parameters.Add(new SqlCeParameter("@Key", SqlDbType.NVarChar));
							updateCommand.Parameters.Add(new SqlCeParameter("@Value", SqlDbType.NVarChar));

							foreach (var kvp in newSettings)
							{
								updateCommand.Parameters["@Key"].Value = kvp.Key;
								updateCommand.Parameters["@Value"].Value = kvp.Value;
								int rowsUpdated = updateCommand.ExecuteNonQuery();

								if (rowsUpdated == 0) // Key doesn't exist, insert a new row
								{
									insertCommand.Parameters["@Key"].Value = kvp.Key;
									insertCommand.Parameters["@Value"].Value = kvp.Value;
									insertCommand.ExecuteNonQuery();
								}
							}
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


		public static void DeleteRecords(Guid[] ids, string table)
        {
            string deleteQuery = $"DELETE FROM {table} WHERE Id = @Id";
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
				connection.Open();
                foreach(Guid id in ids)
                {
                    SqlCeCommand command = new SqlCeCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void ClearOldRecords()
        {
            DialogService.ShowMessage("Vymazání starých záznamů", "Všechny záznamy zásilek a činností starší než dva roky budou exportovány a poté vymazány pro zvýšení efektivity aplikace.");
            // Get old parcels
            var oldParcels = GetFinishedParcels(DateTime.UnixEpoch, DateTime.Now.AddYears(-2)).ToArray();
            var oldParcelIds = oldParcels.Select(parcel => parcel.Id).ToArray();
            // Get old activities
            var oldActivities = GetPastActivities(DateTime.UnixEpoch, DateTime.Now.AddYears(-2)).ToArray();
            var oldActivityIds = oldActivities.Select(activity => activity.Id).ToArray();
            
            CsvService.Export.WriteFinishedParcels(oldParcels);
            CsvService.Export.WriteActivities(oldActivities);
            DeleteRecords(oldParcelIds, Tables.ParcelTable);
            DeleteRecords(oldActivityIds, Tables.ActivityTable);
        }
        private static void InitializeDatabase()
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
            dbConnectionString = $"Data Source={dbPath};Password={dbPassword};";

            if (TestDatabaseConnection() == false)
            {
                DialogService.ShowError("Připojení ke skladové databázi selhalo",
                    "Připojení k databázi skladu selhalo. Restartujte aplikaci nebo kontaktujte technickou podporu.");
                Application.Exit();
            }
        }

        private static void SetupDatabase()
        {
            string password;
            string dirPath;
            string setupDialogTitle = "Nastavení lokální databáze";

            File.Delete(Constants.DotfilePath);

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogService.ShowMessage(setupDialogTitle, "Je potřeba nastavit lokální databázi. Zvolte složku pro novou nebo již existující databázi");
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                folderBrowserDialog.Description = "Zvolte složku pro databázi";

                while (true)
                {
                    DialogResult result = folderBrowserDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        dirPath = folderBrowserDialog.SelectedPath;
                        break;
                    }
                }
            }

            dbPath = Path.Combine(dirPath, Constants.WarehouseDatabaseFileName);

            if (File.Exists(dbPath))
            {
                DialogService.ShowMessage(setupDialogTitle, "Ve zvolené složce byla nalezena již existující databáze. Zadejte heslo k databázi, nebo databázi odstraňte a tuto aplikaci restartujte.");
                password = GetDatabasePassword();
                dbConnectionString = $"Data Source={dbPath};Password={password};";

                if (TestDatabaseConnection() == false)
                {
                    DialogService.ShowError(setupDialogTitle, "Připojení s daným heslem k databázi se nezdařilo. Restartujte aplikaci a zkuste to znovu, nebo vytvořte novou databázi.");
                    System.Environment.Exit(1);
                }
            }
            else
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
                        dbConnectionString = $"Data Source={dbPath};Password={password};";
                        using (SqlCeEngine engine = new SqlCeEngine(dbConnectionString))
                        {
                            engine.CreateDatabase();
                        }

                        if (TestDatabaseConnection() == false)
                        {
                            DialogService.ShowMessage(setupDialogTitle, "Vytvoření nové databáze selhalo. Zkuste to znovu nebo kontaktujte technickou podporu.");
                            System.Environment.Exit(1);
                        }
                        break;
                    }
                }
            }
            File.WriteAllText(Path.Combine(dirPath, "warehouseDB_README.txt"), "warehouseDB.sdf obsahuje data aplikace pro tisk štítků a správu mezd ve skladu.");
            string[] dotfilePayload = new string[] { dbPath, CryptoHelper.GenerateSHA256Hash(password) };
            File.WriteAllLines(Constants.DotfilePath, dotfilePayload);

            DialogService.ShowMessage(setupDialogTitle, "Nastavení databáze bylo úspěšně dokončeno, restartujte aplikaci a zadejte heslo.");
            Application.Exit();
        }

        private static string GetDatabasePassword(string hash = null)
        {
            WarehousePasswordDialog dialog = new WarehousePasswordDialog();
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
                            }
                            else
                            {
                                return password;
                            }
                        }
                        else
                        {
                            return password;
                        }
                    }
                }
            }
        }
        private static bool TestDatabaseConnection()
        {
            try
            {
                using (var connection = new SqlCeConnection(dbConnectionString))
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

        private static void BuildTables()
        {
            string[] tableCommands = new string[]
            {
                $@"CREATE TABLE {Tables.WorkerTable} (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    TimeStamp DATETIME,
                    Name NVARCHAR(255)
                )",
                @$"CREATE TABLE {Tables.JobTable} (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    TimeStamp DATETIME,
                    Name NVARCHAR(255),
                    DurationInSeconds INT
                )",
                @$"CREATE TABLE {Tables.ActivityTable} (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    TimeStamp DATETIME,
                    JobId UNIQUEIDENTIFIER,
                    WorkerId UNIQUEIDENTIFIER,
					JobCount INT,
                    Duration INT,
                    Earning DECIMAL,
                    OrderNumber NVARCHAR(255)
                )",
                @$"CREATE TABLE {Tables.ParcelTable} (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    TimeStamp DATETIME,
                    WorkerId UNIQUEIDENTIFIER,
                    OrderNumber NVARCHAR(255)
                )",
                @$"CREATE TABLE {Tables.AdminSettingsTable} (
                    [Key] NVARCHAR(255) PRIMARY KEY,
                    Value NVARCHAR(255)
                )"
            };
            string[] tableNames = new string[]
            {
                Tables.WorkerTable, Tables.JobTable, Tables.ActivityTable, Tables.ParcelTable, Tables.AdminSettingsTable
            };
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                for(int i = 0; i < tableCommands.Length; i++)
                {
                    if (!TableExists(tableNames[i]))
                    {
                        var c = new SqlCeCommand(tableCommands[i], connection);
                        c.ExecuteNonQuery();
                    }
                }
            }
        }
        private static bool TableExists(string tableName)
        {
            using (SqlCeConnection connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                using (SqlCeCommand command = new SqlCeCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'", connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}