using System.Linq;

namespace Task_13
{
    class PhoneBook
    {
        private Dictionary<string, string> phoneNumbers = new();
        public void Add(string name, string phoneNumber)
        {
            if (phoneNumbers.ContainsKey(name))
            {
                Console.WriteLine("Запис з iменем '{0}' вже iснує.", name);
            }
            else
            {
                phoneNumbers.Add(name, phoneNumber);
                Console.WriteLine("Запис з iменем '{0}' та номером телефону '{1}' доданий до телефонної книги.", name, phoneNumber);
            }
        }

        public void Update(string name, string newPhoneNumber)
        {
            if (phoneNumbers.ContainsKey(name))
            {
                phoneNumbers[name] = newPhoneNumber;
                Console.WriteLine("Запис з iменем '{0}' оновлено, новий номер телефону: '{1}'.", name, newPhoneNumber);
            }
            else
            {
                Console.WriteLine("Запис з iменем '{0}' не знайдено.", name);
            }
        }

        public void Remove(string name)
        {
            if (phoneNumbers.ContainsKey(name))
            {
                phoneNumbers.Remove(name);
                Console.WriteLine("Запис з iменем '{0}' видалено з телефонної книги.", name);
            }
            else
            {
                Console.WriteLine("Запис з iменем '{0}' не знайдено.", name);
            }
        }

        public void Search(string name)
        {
            if (phoneNumbers.ContainsKey(name))
            {
                Console.WriteLine("Номер телефону для запису з iменем '{0}': {1}", name, phoneNumbers[name]);
            }
            else
            {
                Console.WriteLine("Запис з iменем '{0}' не знайдено.", name);
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task_1
            List<string> list = new() { "banana", "apple", "cherry", "orange", "pear", "peach", "grape", "kiwi", "aineapple", "pineapple" };
            int max = 0;
            foreach (string s in list)
            {
                if(s.Length > max)
                {
                    max = s.Length;
                }
            }
            string longestWord = "";
            foreach (string word in list)
            {
                if (word.Length == max && (longestWord == "" || word.CompareTo(longestWord) < 0))
                {
                    longestWord = word;
                }
            }


            Console.WriteLine("Task 1:\n" + "Найдовше слово у списку: " + longestWord + "\n\nTask 2: ");
            #endregion

            #region Task_2

            PhoneBook phoneBook = new PhoneBook();

            phoneBook.Add("John Doe", "555-1234");
            phoneBook.Add("Jane Smith", "555-5678");
            phoneBook.Add("Bob Johnson", "555-2468");

            phoneBook.Update("Jane Smith", "555-4321");

            phoneBook.Search("John Doe");
            phoneBook.Remove("Bob Johnson");
            phoneBook.Search("Alice Brown");
            #endregion

        }
    }
}