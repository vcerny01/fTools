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
                var transaction = connection.BeginTransaction();

                try
                {
                    var deleteCommand = new SqlCeCommand($"DELETE FROM {Tables.WorkerTable}", connection, transaction);
                    deleteCommand.ExecuteNonQuery();

                    foreach (Worker worker in workers)
                    {
                        var insertCommand = new SqlCeCommand($"INSERT INTO {Tables.WorkerTable} (TimeStamp, Id, Name) VALUES (@TimeStamp, @Id, @Name)", connection, transaction);
                        insertCommand.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = worker.TimeStampCreation });
                        insertCommand.Parameters.Add(new SqlCeParameter("@Id", SqlDbType.UniqueIdentifier) { Value = worker.Id });
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
                        var job = new Job((string)reader["Name"], (Guid)reader["Id"], (int)reader["Valuation"], (DateTime)reader["TimeStamp"]);
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
                var transaction = connection.BeginTransaction();

                try
                {
                    var deleteCommand = new SqlCeCommand($"DELETE FROM {Tables.JobTable}", connection, transaction);
                    deleteCommand.ExecuteNonQuery();

                    foreach (Job job in jobs)
                    {
                        var insertCommand = new SqlCeCommand($"INSERT INTO {Tables.JobTable} (TimeStamp, Id, Name, Valuation) VALUES (@TimeStamp, @Id, @Name, @Valuation)", connection, transaction);
                        insertCommand.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = job.TimeStampCreation });
                        insertCommand.Parameters.Add(new SqlCeParameter("@Id", SqlDbType.UniqueIdentifier) { Value = job.Id });
                        insertCommand.Parameters.Add(new SqlCeParameter("@Name", SqlDbType.NVarChar) { Value = job.Name });
                        insertCommand.Parameters.Add(new SqlCeParameter("@Valuation", SqlDbType.Int) { Value = job.Valuation });
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

        public static void DeleteRecord(Guid id, Tables table)
        {
            // Implementation for deleting a record from the specified table in the database
        }

        internal static void LogParcel(Parcel parcel, Worker worker)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"INSERT INTO {Tables.ParcelTable} (TimeStamp, WorkerId, OrderNumber) VALUES (@TimeStamp, @WorkerId, @OrderNumber)", connection);
                command.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = DateTime.Now });
                command.Parameters.Add(new SqlCeParameter("@WorkerId", SqlDbType.UniqueIdentifier) { Value = worker.Id });
                command.Parameters.Add(new SqlCeParameter("@OrderNumber", SqlDbType.NVarChar) { Value = parcel.OrderNumber });
                command.ExecuteNonQuery();
            }
        }

        internal static List<FinishedParcel> GetFinishedParcels()
        {
            var parcels = new List<FinishedParcel>();
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"SELECT * FROM {Tables.ParcelTable}", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var parcel = new FinishedParcel((DateTime)reader["TimeStamp"], (Guid)reader["Id"], (string)reader["OrderNumber"]);
                        parcels.Add(parcel);
                    }
                }
            }
            return parcels;
        }

        internal static void LogActivity(Activity activity)
        {
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"INSERT INTO {Tables.ActivityTable} (TimeStamp, JobId, WorkerId, Duration, Earning, OrderNumber) VALUES (@TimeStamp, @JobId, @WorkerId, @Duration, @Earning, @OrderNumber)", connection);
                command.Parameters.Add(new SqlCeParameter("@TimeStamp", SqlDbType.DateTime) { Value = activity.TimeStampCreation });
                command.Parameters.Add(new SqlCeParameter("@JobId", SqlDbType.UniqueIdentifier) { Value = activity.JobId });
                command.Parameters.Add(new SqlCeParameter("@WorkerId", SqlDbType.UniqueIdentifier) { Value = activity.WorkerId });
                command.Parameters.Add(new SqlCeParameter("@Duration", SqlDbType.Int) { Value = activity.Duration });
                command.Parameters.Add(new SqlCeParameter("@Earning", SqlDbType.Decimal) { Value = activity.Earning });
                command.Parameters.Add(new SqlCeParameter("@OrderNumber", SqlDbType.NVarChar) { Value = activity.OrderNumber });
                command.ExecuteNonQuery();
            }
        }

        internal static List<Activity> GetPastActivities()
        {
            var activities = new List<Activity>();
            using (var connection = new SqlCeConnection(dbConnectionString))
            {
                connection.Open();
                var command = new SqlCeCommand($"SELECT * FROM {Tables.ActivityTable}", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var activity = new Activity((Guid)reader["JobId"], (Guid)reader["WorkerId"], (int)reader["Duration"], (decimal)reader["Duration"], (DateTime)reader["TimeStamp"], Convert.IsDBNull(reader["OrderNumber"]) ? null : (string)reader["orderNumber"]);
                        activities.Add(activity);
                    }
                }
            }
            return activities;
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
                DialogService.ShowMessage(setupDialogTitle, "Je potřeba nastavit lokální databázi. Zvolíte složku pro novou nebo již existující databázi");
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
                    TimeStampCreation DATETIME,
                    Name NVARCHAR(255)
                )",
                @$"CREATE TABLE {Tables.JobTable} (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    TimeStamp DATETIME,
                    Name NVARCHAR(255),
                    Valuation INT
                )",
                @$"CREATE TABLE {Tables.ActivityTable} (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    TimeStamp DATETIME,
                    JobId UNIQUEIDENTIFIER,
                    WorkerId UNIQUEIDENTIFIER,
                    Duration INT,
                    Earning DECIMAL,
                    OrderNumber NVARCHAR(255)
                )",
                @$"CREATE TABLE {Tables.ParcelTable} (
                    TimeStamp DATETIME,
                    WorkerId UNIQUEIDENTIFIER,
                    OrderNumber NVARCHAR(255)
                )"
            };
            string[] tableNames = new string[]
            {
                Tables.WorkerTable, Tables.JobTable, Tables.ActivityTable, Tables.ParcelTable
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