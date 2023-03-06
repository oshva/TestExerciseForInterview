using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace TestExerciseForInterview.Classes
{
    public class CreateTableQuery : Program
    {
        //myApp 1: Создание таблицы.
        public static void CreateTable()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("CREATE TABLE Test (id int identity, fullName varchar(50), birthday date, gender char(8))");

            string tableQuery = strBuilder.ToString();

            using (SqlCommand cmd = new SqlCommand(tableQuery, sqlConnection))
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Таблица создана!");
                sqlConnection.Close();
            }

            strBuilder.Clear();
        }
    }
}
