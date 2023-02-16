using System.Data;
using System.Data.SqlClient;

namespace DemoImportTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (SqlConnection connection = new SqlConnection())
            //{
            //    connection.ConnectionString = @"DATA SOURCE=10.60.0.34\SQL2019DEV; INITIAL CATALOG=Demo;INTEGRATED SECURITY=True";

            //    using(SqlCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = "CSP_AddContacts";
            //        command.CommandType = CommandType.StoredProcedure;

            //        DataTable dataTable = new DataTable();
            //        dataTable.Columns.Add("LastName", typeof(string));
            //        dataTable.Columns.Add("FirstName", typeof(string));
            //        dataTable.Columns.Add("BirthDate", typeof(DateTime));

            //        dataTable.Rows.Add("Person", "Michael", new DateTime(1981, 1, 1));
            //        dataTable.Rows.Add("Fonda", "Jane", new DateTime(1940, 1, 1));

            //        command.Parameters.AddWithValue("Contacts", dataTable);

            //        connection.Open();
            //        using (SqlDataReader dataReader = command.ExecuteReader())
            //        {
            //            while(dataReader.Read()) {
            //                Console.WriteLine(dataReader["Id"]);
            //            }
            //        }
            //    }
            //}

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"DATA SOURCE=10.60.0.34\SQL2019DEV; INITIAL CATALOG=Demo;INTEGRATED SECURITY=True";

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CSP_AddContact";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter() { ParameterName = "Id", Value = -1, Direction = ParameterDirection.InputOutput });
                    command.Parameters.AddWithValue("BirthDate", new DateTime(1970,1,1));

                    connection.Open();
                    command.ExecuteNonQuery();

                    Console.WriteLine(command.Parameters["Id"].Value);
                }
            }
        }
    }
}