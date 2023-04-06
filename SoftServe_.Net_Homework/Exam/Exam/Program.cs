using System;
using System.Diagnostics;
using System.Threading;
using static Exam.Program;


namespace Exam
{
    #region Enum
    public enum Names
    {
        Ezra = 1,
        Noah = 2,
        Isaac = 3,
        Levi = 4,
        Saul = 5,
        Eli = 6,
        Rachel = 7,
        Sarah = 8,
        Miriam = 9,
        Abigail = 10,
        Hannah = 11,
        Esther = 12


    }
    public enum Surnames
    {
        Cohen = 1,
        Levi = 2,
        Goldstein = 3,
        Friedman = 4,
        Kaplan = 5,
        Rosenberg = 6,
        Grossman = 7,
        Weiss = 8


    }

    #endregion

    #region interface
    public interface IEditor
    {
        void Edit();
    }
    #endregion

    internal partial class Program
    {
        static void Main(string[] args)
        {
            Hairdresser hairdressers = new Hairdresser();
            MainMenu(ref hairdressers);
        }

        public static void MainMenu(ref Hairdresser hairdresser)
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\tWelcome to our Beauty Salon Management System!");

            Console.ResetColor();
            WaitForKeypress();

            Console.Clear();
            hairdresser.AddPerson();
            hairdresser.AddService();
            hairdresser.AddProduct();

            int process = 1;
            while (process != 0)
            {
                process = hairdresserInterface(ref hairdresser);
            }
          
        }

        public static int ShowMenu(ref Hairdresser hairdressers)
        {
            Console.Clear();
            Console.WriteLine("\t\tMenu");
            Console.WriteLine("Show Persons list \t-1");
            Console.WriteLine("Show Services list \t-2");
            Console.WriteLine("Show Products list \t-3");
            Console.WriteLine("Show Orders list \t-4");
            Console.WriteLine("Go back \t- 0");

            Console.Write("\n\n\n\tYour choice:");
            int variant = int.Parse(Console.ReadLine());
            switch (variant)
            {
                case 0: return 0;
                case 1:
                    Console.Clear();
                    hairdressers.ShowPerson();
                    WaitForKeypress();
                    break;
                case 2:
                    Console.Clear();
                    hairdressers.ShowService();
                    WaitForKeypress();
                    break;
                case 3:
                    Console.Clear();
                    hairdressers.ShowProduct();
                    WaitForKeypress();
                    break;
                case 4:
                    Console.Clear();
                    hairdressers.ShowOrder();
                    WaitForKeypress();
                    break;
                default:
                    Console.WriteLine("Incorrect!");
                    WaitForKeypress();
                    break;
            }
            return 1;
        }

        public static int hairdresserInterface(ref Hairdresser hairdressers)
        {
            Console.Clear();
            Console.WriteLine("\t\tMain Menu");
            Console.WriteLine("Open list of object collections \t- 1");
            Console.WriteLine("Add an item \t\t\t- 2");
            Console.WriteLine("Edit an item \t\t\t- 3");
            Console.WriteLine("Remove an item \t\t\t- 4");
            Console.WriteLine("Process an order \t\t- 5");
            Console.WriteLine("Exit \t\t\t\t- 0");

            Console.Write("\n\n\n\tYour choice:");
            int choice = int.Parse(Console.ReadLine());
            int process = 1;
            switch (choice)
            {
                case 0:
                    return 0;
                case 1:
                    while (process != 0)
                    {
                        process = ShowMenu(ref hairdressers);
                    }
                    break;
                case 2:
                    while (process != 0)
                    {
                        process = Adding(ref hairdressers);
                    }
                    break;
                case 3:
                    while (process != 0)
                    {
                        process = EditMethod(ref hairdressers);
                    }
                    break;
                case 4:
                    while (process != 0)
                    {
                        process = Remover(ref hairdressers);
                    }
                    break;
                case 5:
                    while (process != 0)
                    {
                        hairdressers.ShowOrder();
                        Console.Write("\n\n\n\tYour choice (order number):");
                        int number = int.Parse(Console.ReadLine()) - 1;
                        hairdressers.Orders[number].Work();
                        hairdressers.Orders.RemoveAt(number);
                        Console.Clear();
                    }
                    break;
                default:
                    break;
            }

            return 1;
        }

        public static int Index()
        {
            Console.Write("Enter the number of the object you want to modify:");

            return int.Parse(Console.ReadLine()) - 1;
        }

        public static int Adding(ref Hairdresser hairdressers)
        {
            Console.Clear();

            Console.WriteLine("\t\tMenu");
            Console.WriteLine("Add - Person - 1");
            Console.WriteLine("Add - Service - 2");
            Console.WriteLine("Add - Product - 3");
            Console.WriteLine("Add - Order - 4");
            Console.WriteLine("Back - 0");
            Console.Write("\n\n\n\tYour choice:");
            int variant = int.Parse(Console.ReadLine());
            switch (variant)
            {
                case 0: return 0;
                case 1:
                    hairdressers.ShowPerson();
                    hairdressers.AddPerson();
                    break;
                case 2:
                    hairdressers.ShowService();
                    hairdressers.AddService();
                    break;
                case 3:
                    hairdressers.ShowProduct();
                    hairdressers.AddProduct();
                    break;
                case 4:
                    hairdressers.ShowOrder();
                    hairdressers.AddOrder();
                    break;

                default:
                    break;
            }

            return 1;

        }
        public static int Remover(ref Hairdresser hairdressers)
        {
            Console.Clear();

            Console.WriteLine("\t\tMenu");
            Console.WriteLine("Delete - Person - 1");
            Console.WriteLine("Delete - Service - 2");
            Console.WriteLine("Delete - Product - 3");
            Console.WriteLine("Delete - Order - 4");
            Console.WriteLine("Back - 0");
            Console.Write("\n\n\n\tYour choice:");
            int variant = int.Parse(Console.ReadLine());
            switch (variant)
            {
                case 0: return 0;
                case 1:
                    hairdressers.RemovePerson();
                    break;
                case 2:
                    hairdressers.RemoveService();
                    break;
                case 3:
                    hairdressers.RemoveProduct();
                    break;
                case 4:
                    hairdressers.RemoveOrder();
                    break;

                default:
                    break;
            }

            return 1;

        }
        public static int EditMethod(ref Hairdresser hairdressers)
        {
            Console.Clear();

            Console.WriteLine("\t\tMenu");
            Console.WriteLine("Edit - Person - 1");
            Console.WriteLine("Edit - Service - 2");
            Console.WriteLine("Edit - Product - 3");
            Console.WriteLine("Back - 0");
            Console.Write("\n\n\n\tYour choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0: return 0;
                case 1:
                    hairdressers.ShowPerson();
                    hairdressers.Persons[Index()].Edit();
                    break;
                case 2:
                    hairdressers.ShowService();
                    hairdressers.Services[Index()].Edit();
                    break;
                case 3:
                    hairdressers.ShowProduct();
                    hairdressers.Products[Index()].Edit();
                    break;

                default:
                    break;
            }

            return 1;

        }
        public static void WaitForKeypress()
        {
            Console.WriteLine("\n\nTo continue, press any key...");
            Console.ReadKey();
        }

    }
}