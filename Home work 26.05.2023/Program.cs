using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace Home_work_26._05._2023
{
    internal class Program
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;
        static public bool Connect(string fileName)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + fileName + ";Version=3; FailIfMissing=False");
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
                return false;
            }
        }

        static Employer InputEmployerInBase(YoungEmployer empl)//метод внесение пользователем данных в базу с консоли
        {
      
            command.CommandText = "INSERT INTO Employer (name,surname, birthDate, job_title) VALUES (:name, :surname, :birthDate,:job_title)";
            Console.WriteLine("Заполните данные для приема сотрудника на работу:\n");
            Console.WriteLine("Имя сотрудника\n");
            string _name = Console.ReadLine();
            empl.Name = _name;
            command.Parameters.AddWithValue("name", _name);
            Console.WriteLine("\nФамилия сотрудника\n");
            string _surname = Console.ReadLine();
            empl.Surname = _surname;    
            command.Parameters.AddWithValue("surname", _surname);
                Console.WriteLine("\nДата рождения сотрудника:  \n");
                try
                {
                    Console.Write("Введите месяц  в формате ММ: ");
                    int month = int.Parse(Console.ReadLine());
                    Console.Write("Введите день в формате ДД: ");
                    int day = int.Parse(Console.ReadLine());
                    Console.Write("Введите год в формате ГГГГ: ");
                    int year = int.Parse(Console.ReadLine());
                    DateTime _birthDate = new DateTime(year, month, day);

                    empl.BirthDate = _birthDate;
                    command.Parameters.AddWithValue("birthDate", _birthDate);
                }
                catch
                {
                    Console.WriteLine("Дата рождения вводится цифрой, попробуйте ещё");
                }

            Console.WriteLine("\nДолжность сотрудника\n");
            string _job_title = Console.ReadLine();
            empl.Job_title = _job_title;
            command.Parameters.AddWithValue("job_title", _job_title);
            command.ExecuteNonQuery();
            Console.WriteLine("Данные успешно записаны!");
            return new YoungEmployer();
        }
        static void PrintBase()
        {
            command.CommandText = "SELECT * FROM Employer";
            DataTable data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(data);
            Console.WriteLine($"Прочитано {data.Rows.Count} записей из таблицы БД");
            foreach (DataRow row in data.Rows)
            {
                Console.WriteLine($"id = {row.Field<int>("id")} name = {row.Field<string>("name")} surname = {row.Field<string>("surname")}" +
                    $" birthDate = {row.Field<string>("birthDate")} job_title = {row.Field<string>("job_title")}");
            }

        }
        static void Main(string[] args)
        {
            if (Connect("EmployerBase.sqlite"))
            {
                Console.WriteLine("Подключение...");
                command = new SQLiteCommand(connection)
                {
                    CommandText = "CREATE TABLE IF NOT EXISTS [Employer]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE," +
                    " [name] TEXT,[surname] TEXT, [birthDate] TEXT, [job_title] TEXT);"
                };
                command.ExecuteNonQuery();
                Console.WriteLine("Таблица создана");
            }
            YoungEmployer staff002 = new YoungEmployer();
            InputEmployerInBase(staff002);
            staff002.PrintWorkTime();
            PrintBase();
            YoungEmployer staff003 = new YoungEmployer();
            InputEmployerInBase(staff003);
            staff003.PrintWorkTime();
            PrintBase();


        }
    }

}