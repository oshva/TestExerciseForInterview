using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TestExerciseForInterview.Classes
{
    public class UniqueValuesQuery
    {
        //myApp 3: Вывод строк.
        public static void UniqueValues()
        {

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("SELECT DISTINCT fullName, birthday, g.age, g.gender FROM Test2 c " +
                              "inner join (SELECT id, DATEDIFF(year,birthday,getDate()) AS age, gender FROM Test2) AS g " +
                              "ON c.id = g.id ORDER BY fullName");

            string uniqueQuery = strBuilder.ToString();

            //Вывод уникальных строк + сортировка.
            using (SqlCommand cmd = new SqlCommand(uniqueQuery, sqlConnection))
            {
                sqlConnection.Open();
                //cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime birthday = Convert.ToDateTime(reader[1]);
                    Console.WriteLine($"ФИО: {reader[0]}. \tДень рождения: {birthday.ToString("d")}. \tВозраст: {reader[2]} \tПол: {reader[3]}");
                }
                Console.WriteLine("\nУникальные значения выведены и отсортированы.\n");
                sqlConnection.Close();
            }
            strBuilder.Clear();
        }
    }
}
