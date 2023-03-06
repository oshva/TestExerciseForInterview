using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TestExerciseForInterview.Classes
{
    public class Connection
    {
        public static void Conn()
        {
            //Подключение к бд + проверка. Строка подключения находится в App.Config.
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            try
            {
                Console.WriteLine("Подключение к бд...");
                sqlConnection.Open();
                Console.WriteLine("Подключение успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            sqlConnection.Close();
        }
    }
}
