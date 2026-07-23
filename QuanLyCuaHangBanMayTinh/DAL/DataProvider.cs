using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DataProvider
    {
        private readonly string _connectionString;

        public DataProvider()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ql_storecomputer"].ConnectionString;
        }

        // Thực thi câu truy vấn trả về kết quả (SELECT)
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Thực thi câu lệnh không trả về kết quả (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rowsAffected = 0;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        // Thực thi câu truy vấn trả về một giá trị đơn (thường là kết quả của COUNT, SUM, v.v.)
        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    result = command.ExecuteScalar();
                }
            }

            return result;
        }
    }
}
