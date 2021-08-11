using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using static System.Console;


namespace ConsoleApp1
{
    class Program
    {
        class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            Person
            p1 = new Person("Name1", 33),
            p2 = new Person("Name2", 43);
            // Name1;33
            // Name2;44
            var text = $"{p1.Name};{p1.Age}\n{p2.Name};{p2.Age}";
            WriteLine(text);
            string[] rows = text.Split('\n');
            // Person[] persons = new Person[rows.Length];
            List<Person> persons = new List<Person>();
            foreach (string row in rows)
            {
                string[] _rows = row.Split(';');
                Person person = new Person(_rows[0], int.Parse(_rows[1]));   //System.Convert
                persons.Add(person);
                /*foreach (string _row in _rows)
                    WriteLine($"Имя сотрудника: {_row}");
                    WriteLine($"Возраст сотрудника: {_row}");
                }*/

                WriteLine($"Сотрудник: {row}");
            }


            // Передать данные:
            // 1. Сериализация (конвертация данных в байты или в текст)
            // 2. Отправляем байты/текст в поток
            // Получить данные:
            // 1. Получаем байты/текст
            // 2. Десериализация (конвертация из байтов или текста в данные) //var Example = new StreamExample();
            //Example.Run(); ReadKey();
        }
    }
}

