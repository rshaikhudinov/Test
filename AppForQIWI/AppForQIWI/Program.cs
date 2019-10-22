using AppForQIWI.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AppForQIWI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                MyQueue<Person> persons = new MyQueue<Person>();
                Console.WriteLine("Tекст в формате 'n phone1 phone2 ... phoneN'");
                Console.WriteLine("где n - количество номеров из очереди для вывода и 0 ≤ n ≤ m");
                Console.WriteLine("phone1 - phoneN - номера телефонов");
                Console.WriteLine("разделителем является пробел.");
                Console.WriteLine("Введите текст:");

                //уникальный идентификатор id через счетчик
                dynamic nextId = 0;
                
                string inputText = Console.ReadLine();
                string[] words = inputText.Trim().Split(new char[] { ' ' });
                int outputAmount = int.Parse(words[0]);
                string numbers = inputText.Trim().Substring(words[0].Length).Trim();
                words = numbers.Split(new char[] { ' ' });
                Console.WriteLine("Полная очередь:");
                foreach (string number in words)
                {
                    /* Id автоинкремент
                    persons.Enqueue(new Person() { Id = nextId++, PhoneNumber = number });
                    Console.WriteLine($"Id {nextId - 1} и номер {number}");*/
                    // Id Guid
                    Person per = new Person() { Id = Guid.NewGuid(), PhoneNumber = number };
                    persons.Enqueue(per);
                    Console.WriteLine($"Id {per.Id} и номер {per.PhoneNumber}");
                }
                Console.WriteLine("Номера для вывода:");
                for (int i = 0; i < outputAmount; i++)
                {
                    Console.Write($"{words[i]} ");
                }
                Console.WriteLine("");
                Console.WriteLine($"Размер очереди = {persons.Size()}");
                if (persons.IsEmpty()) Console.WriteLine("Пустая очередь.");
                else Console.WriteLine("Очередь не пустая.");
                Person p = persons.Dequeue();
                Console.WriteLine($"Первый элемент очереди = {p.Id} {p.PhoneNumber}");
                Console.WriteLine($"Размер очереди = {persons.Size()}");
                if (persons.IsEmpty()) Console.WriteLine("Пустая очередь.");
                else {
                    foreach (Person n in persons)
                    {
                        Console.WriteLine($"Id {n.Id} и номер {n.PhoneNumber}");
                    }
                }
                //Сортировка
                persons.Sort("PhoneNumber");
                Console.WriteLine("После сортировки");
                if (persons.IsEmpty()) Console.WriteLine("Пустая очередь.");
                else
                {
                    foreach (Person n in persons)
                    {
                        Console.WriteLine($"Id {n.Id} и номер {n.PhoneNumber}");
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
