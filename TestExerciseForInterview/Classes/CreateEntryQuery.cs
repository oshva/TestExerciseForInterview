using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace TestExerciseForInterview.Classes
{
    public class CreateEntryQuery : Program
    {
        //myApp 2: Создание записи.

        //private static string fullName { get; set; }
        //private static DateTime birthday { get; set; }
        //private static string gender { get; set; }  
        public static void EntryQuery(string fullName, DateTime birthday, string gender)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"INSERT INTO Test (fullName, birthday, gender)" +
                                        $"VALUES (N'{fullName}', N'{birthday}', N'{gender}')");

            string entryQuery = strBuilder.ToString();

            using (SqlCommand cmd = new SqlCommand(entryQuery, sqlConnection))
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Запись добавлена!");
                sqlConnection.Close();
            }

            strBuilder.Clear();
        }
    }
}
