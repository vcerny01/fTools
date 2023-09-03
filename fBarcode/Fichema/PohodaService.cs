using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using fBarcode.Logging;
using fBarcode.Utils;
using System.Collections;

namespace fBarcode.Fichema
{
	public static class PohodaService
	{
		private static string databaseName = AdminSettings.GetSettingValue("Pohoda.databaseName");
		private static string tableName = AdminSettings.GetSettingValue("Pohoda.tableName");
        private static string hasOrderQuery = $"USE {databaseName}; SELECT COUNT(*) FROM {tableName} WHERE Cislo=@orderNumber";
		private static string getOrderDataQuery = $"USE {databaseName}; SELECT * FROM {tableName} WHERE Cislo=@orderNumber";

        static PohodaService()
		{
			SqlConnection pohodaConnection = new(Constants.pohodaConnectionString);
			try
			{
				pohodaConnection.Open();
			} catch (Exception e)
			{
				DialogService.ShowError("Připojení k databázi selhalo.", e.Message);
				Application.Exit();
			} finally {
				pohodaConnection.Close();
			}
		}
		public static bool hasOrder(string orderNumber)
		{
			using (SqlConnection pohodaConnection = new SqlConnection(Constants.pohodaConnectionString))
			{
				using (SqlCommand command = new(hasOrderQuery, pohodaConnection))
				{
					pohodaConnection.Open();
					command.Parameters.AddWithValue("@orderNumber", orderNumber);
					MessageBox.Show(command.CommandText);
					int count = Convert.ToInt32(command.ExecuteScalar());
					return count > 0;
				}
			}
		}
		public static Dictionary<string, object> GetOrderData(string orderNumber)
		{
			Dictionary<string, object> orderData = new Dictionary<string, object>();
			using (SqlConnection pohodaConnection = new SqlConnection(Constants.pohodaConnectionString))
			{
				using (SqlCommand command = new(getOrderDataQuery, pohodaConnection))
				{
					pohodaConnection.Open();
					command.Parameters.AddWithValue("@orderNumber", orderNumber);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
							{
								orderData.Add(reader.GetName(i), reader[i]);
							}
						}
					}
				}
			}
            return orderData;
        }
    }
}