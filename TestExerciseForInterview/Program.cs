using System;
using TestExerciseForInterview.Classes;

namespace TestExerciseForInterview
{
    public class Program
    {
        static void Main(string[] args)
        {
            Connection.Conn();

            string fullName; DateTime birthday; string gender;

            if (args[0] == null)
            {
                Console.WriteLine("Приведите аргумент командной строки");
            }

            switch (args[0])
            {
                case "1":
                    CreateTableQuery.CreateTable();
                    break;

                case "2":
                    Console.WriteLine("Введите ФИО.");
                    fullName = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Введите дату рождения в формате: день.месяц.год.");
                    birthday = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Введите пол.");
                    gender = Convert.ToString(Console.ReadLine());

                    CreateEntryQuery.EntryQuery(fullName,birthday,gender);
                    break;

                case "3":
                    UniqueValuesQuery.UniqueValues();
                    break;

                case "4":
                    AutocompleteRequests.Million();
                    AutocompleteRequests.HundredMen();
                    break;

                case "5":
                    SelectFromTable.Select();
                    break;

                default: Console.WriteLine("Такого варианта нет.");
                    break;

                case "exit":
                    break;
            }
        }
    }
}
