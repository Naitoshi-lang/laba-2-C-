using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1. Проверка email-адреса или номера телефона");
            Console.WriteLine("2. Поиск всех дат в формате dd.MM.yyyy");
            Console.WriteLine("3. Замена всех цифр в тексте на *");
            Console.WriteLine("4. Разбиение строки по запятым, точкам или пробелам");
            Console.WriteLine("5. Выход");

            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckEmailOrPhone();
                    break;
                case "2":
                    FindDates();
                    break;
                case "3":
                    ReplaceDigits();
                    break;
                case "4":
                    SplitString();
                    break;
                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    // 1. Проверка email-адреса или номера телефона
    static void CheckEmailOrPhone()
    {
        Console.WriteLine("Выберите тип для проверки (email/phone):");
        string type = Console.ReadLine().ToLower();

        Console.Write("Введите строку для проверки: ");
        string input = Console.ReadLine();

        if (type == "email")
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (Regex.IsMatch(input, emailPattern))
            {
                Console.WriteLine("Email-адрес корректный.");
            }
            else
            {
                Console.WriteLine("Email-адрес некорректный.");
            }
        }
        else if (type == "phone")
        {
            string phonePattern = @"^(\+?\d{1,3})?[-.\s]?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$"; // Более гибкий шаблон для разных форматов телефонов
            if (Regex.IsMatch(input, phonePattern))
            {
                Console.WriteLine("Номер телефона корректный.");
            }
            else
            {
                Console.WriteLine("Номер телефона некорректный.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный тип. Выберите 'email' или 'phone'.");
        }
    }

    // 2. Поиск всех дат в формате dd.MM.yyyy
    static void FindDates()
    {
        Console.Write("Введите текст для поиска дат: ");
        string input = Console.ReadLine();

        string datePattern = @"\b(\d{2})\.(\d{2})\.(\d{4})\b";
        MatchCollection matches = Regex.Matches(input, datePattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Найденные даты:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("Даты в формате dd.MM.yyyy не найдены.");
        }
    }

    // 3. Замена всех цифр в тексте на *
    static void ReplaceDigits()
    {
        Console.Write("Введите текст для замены цифр: ");
        string input = Console.ReadLine();

        string replacedText = Regex.Replace(input, @"\d", "*");

        Console.WriteLine("Текст с замененными цифрами:");
        Console.WriteLine(replacedText);
    }

    // 4. Разбиение строки по запятым, точкам или пробелам
    static void SplitString()
    {
        Console.Write("Введите строку для разбиения: ");
        string input = Console.ReadLine();

        string[] parts = Regex.Split(input, @"[,.\s]+"); // Разбиваем по запятым, точкам и пробелам (одному или нескольким)

        Console.WriteLine("Разбитая строка:");
        foreach (string part in parts)
        {
            Console.WriteLine(part);
        }
    }
}
