using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace TestExerciseForInterview.Classes
{
    public class AutocompleteRequests
    {
        //myApp 4: Автоматическое заполнение.

        private static Random gen = new Random();

        //Массивы
        private static string[] names = File.ReadAllLines(@"../../Data/names.txt");
        private static string[] surnames = File.ReadAllLines(@"../../Data/surnames.txt");
        private static string[] gender = File.ReadAllLines(@"../../Data/genders.txt");

        //Генерация случайной даты рождения.
        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            DateTime end = new DateTime(2007, 1, 1);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

        //SQL запрос на 1.000.000 строк.
        public static void Million()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();

            for (int i = 0; i < 1000001; i++)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append($"INSERT INTO Test (fullName, birthday, gender) " +
                                  $"VALUES (N'{surnames[gen.Next(0, surnames.Length)] + names[gen.Next(0, names.Length)]}', " +
                                  $"N'{RandomDay()}', N'{gender[gen.Next(0,gender.Length)]}')");

                string million = strBuilder.ToString();
                using (SqlCommand cmd = new SqlCommand(million, sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Запись {i} добавлена!");
                }
                strBuilder.Clear();
            }
            sqlConnection.Close();
            Console.WriteLine("\n Записи добавлены! \n");
        }

        //SQL запрос на 100.000 строк.
        public static void HundredMen()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            sqlConnection.Open();
            List<string> surnamesOnF = new List<string>();

            for(int i = 0; i < surnames.Length; i++)
            {
                if (surnames[i].StartsWith("F")) { surnamesOnF.Add(surnames[i]); }
            }

            for(int i = 0; i < 101; i++)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append($"INSERT INTO Test (fullName, birthday, gender) " +
                                  $"VALUES (N'{surnamesOnF[gen.Next(0, surnamesOnF.Count)] + names[gen.Next(0, names.Length)]}', N'{RandomDay()}', N'male')");

                string hundredMen = strBuilder.ToString();
                using (SqlCommand cmd = new SqlCommand(hundredMen, sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Запись {i} добавлена!");
                }
                strBuilder.Clear();
            }
            Console.WriteLine($"\n Записи добавлены!");
            sqlConnection.Close();
        }
    }
}
