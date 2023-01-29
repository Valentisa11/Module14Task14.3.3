using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module14Task14._3._3;
internal class Program
{
    static void Main(string[] args)
    {
        // создаём пустой список с типом данных Contact
        var phoneBook = new List<Contact>();

        // добавляем контакты
        phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
        phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

        // сортировка телефонной книги
        var sortPhoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName);

        ConsoleKeyInfo key = new ConsoleKeyInfo();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("--------------------------------------------------------------------");

            var page = key.KeyChar;
            switch (key.KeyChar)
            {
                case '1':
                    ConsoleView(sortPhoneBook.Take(2).ToList());
                    break;
                case '2':
                    ConsoleView(sortPhoneBook.Skip(2).Take(2).ToList());
                    break;
                case '3':
                    ConsoleView(sortPhoneBook.Skip(4).Take(2).ToList());
                    break;
                default:
                    ConsoleView(sortPhoneBook.Take(2).ToList());
                    page = '1';
                    break;
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Страница " + page);

            Console.Write("\nВведите номер страницы: ");
            key = Console.ReadKey();
            
        }
    }

    // вывод телефонной книги в консоль
    public static void ConsoleView(List<Contact> contacts)
    {
        foreach (Contact contact in contacts)
        {
            Console.WriteLine(" " + contact.Name + " " + contact.LastName + " - телефон " + contact.PhoneNumber + ", email " + contact.Email);
        }
    }
}

