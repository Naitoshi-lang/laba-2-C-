using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) // Бесконечный цикл для отображения меню и выполнения операций
            {
                // Вывод меню на экран
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Проверка email-адреса или номера телефона");
                Console.WriteLine("2. Поиск всех дат в формате dd.MM.yyyy");
                Console.WriteLine("3. Замена всех цифр в тексте на *");
                Console.WriteLine("4. Разбиение строки по запятым, точкам или пробелам");
                Console.WriteLine("5. Выход");

                Console.Write("Ваш выбор: "); // Запрос выбора операции у пользователя
                string choice = Console.ReadLine(); // Считывание выбора пользователя

                // Обработка выбора пользователя с помощью оператора switch
                switch (choice)
                {
                    case "1":
                        CheckEmailOrPhone(); // Вызов метода для проверки email или телефона
                        break;
                    case "2":
                        FindDates(); // Вызов метода для поиска дат
                        break;
                    case "3":
                        ReplaceDigits(); // Вызов метода для замены цифр
                        break;
                    case "4":
                        SplitString(); // Вызов метода для разбиения строки
                        break;
                    case "5":
                        Console.WriteLine("Выход из программы..."); // Сообщение о выходе
                        return; // Завершение работы программы
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте еще раз."); // Сообщение об ошибке ввода
                        break;
                }
            }
        }

        // Метод для проверки email-адреса или номера телефона
        static void CheckEmailOrPhone()
        {
            Console.WriteLine("Выберите, что проверять:");
            Console.WriteLine("1. Email-адрес");
            Console.WriteLine("2. Номер телефона");

            Console.Write("Ваш выбор: "); // Запрос выбора типа проверки
            string choice = Console.ReadLine(); // Считывание выбора типа проверки

            Console.Write("Введите строку для проверки: "); // Запрос строки для проверки
            string input = Console.ReadLine(); // Считывание строки для проверки

            // Обработка выбора типа проверки
            switch (choice)
            {
                case "1":
                    // Регулярное выражение для проверки email-адреса
                    string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // string используется для хранения последовательности символов
                    if (Regex.IsMatch(input, emailPattern)) // Проверка соответствия строки email-адресу
                    {
                        Console.WriteLine("Введенная строка является корректным email-адресом."); // Сообщение об успехе
                    }
                    else
                    {
                        Console.WriteLine("Введенная строка не является корректным email-адресом."); // Сообщение о неудаче
                    }
                    break;
                case "2":
                    // Регулярное выражение для проверки номера телефона (российский формат)
                    string phonePattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
                    if (Regex.IsMatch(input, phonePattern)) // Проверка соответствия строки номеру телефона
                    {
                        Console.WriteLine("Введенная строка является корректным номером телефона."); // Сообщение об успехе
                    }
                    else
                    {
                        Console.WriteLine("Введенная строка не является корректным номером телефона."); // Сообщение о неудаче
                    }
                    break;
                default:
                    Console.WriteLine("Неверный ввод."); // Сообщение об ошибке ввода
                    break;
            }
        }

        // Метод для поиска всех дат в формате dd.MM.yyyy
        static void FindDates()
        {
            Console.Write("Введите строку для поиска дат: "); // Запрос строки для поиска дат
            string input = Console.ReadLine(); // Считывание строки для поиска дат

            // Регулярное выражение для поиска дат в формате dd.MM.yyyy
            string datePattern = @"\d{2}\.\d{2}\.\d{4}";
            MatchCollection matches = Regex.Matches(input, datePattern); // Поиск всех совпадений с шаблоном даты

            if (matches.Count > 0) // Если найдены даты
            {
                Console.WriteLine("Найденные даты:");
                foreach (Match match in matches) // Перебор всех найденных дат
                {
                    Console.WriteLine(match.Value); // Вывод каждой найденной даты
                }
            }
            else
            {
                Console.WriteLine("Даты не найдены."); // Сообщение, если даты не найдены
            }
        }

        // Метод для замены всех цифр в тексте на *
        static void ReplaceDigits()
        {
            Console.Write("Введите строку для замены цифр: "); // Запрос строки для замены цифр
            string input = Console.ReadLine(); // Считывание строки для замены цифр

            // Заменяем все цифры на символ "*"
            string replacedText = Regex.Replace(input, @"\d", "*"); // Замена всех цифр на "*"
            Console.WriteLine("Текст с замененными цифрами:");
            Console.WriteLine(replacedText); // Вывод текста с замененными цифрами
        }

        // Метод для разбиения строки по запятым, точкам или пробелам
        static void SplitString()
        {
            Console.Write("Введите строку для разбиения: "); // Запрос строки для разбиения
            string input = Console.ReadLine(); // Считывание строки для разбиения

            // Разбиваем строку по запятым, точкам или пробелам
            string[] parts = input.Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries); // Разбиение строки

            Console.WriteLine("Разбитая строка:");
            foreach (string part in parts) // Перебор всех частей строки
            {
                Console.WriteLine(part); // Вывод каждой части строки
            }
        }
    }
}
