using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace TestExerciseForInterview.Classes
{
    public class SelectFromTable
    {
        //myApp 5: Выборка из таблицы.
        public static void Select()
        {
            //Таймер
            Stopwatch stopwatch = new Stopwatch();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("SELECT fullName, gender FROM Test2 where fullName LIKE 'F%' AND gender = 'male'");

            string select = strBuilder.ToString();

            stopwatch.Start();
            using (SqlCommand cmd = new SqlCommand(select, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ФИО: {reader[0]} \tПол: {reader[1]}");
                }
            }
            stopwatch.Stop();

            sqlConnection.Close();
            strBuilder.Clear();

            Console.WriteLine($"\nНа выполнение операции потрачено {(float)stopwatch.ElapsedMilliseconds / 1000} секунд.\n");

        }
    }
}
