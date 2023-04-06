using System;
using System.Diagnostics;
using System.Globalization;
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

    internal class Program
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
                    hairdressers.ShowPerson();
                    hairdressers.RemovePerson();
                    break;
                case 2:
                    hairdressers.ShowService();
                    hairdressers.RemoveService();
                    break;
                case 3:
                    hairdressers.ShowProduct();
                    hairdressers.RemoveProduct();
                    break;
                case 4:
                    hairdressers.ShowOrder();
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

        #region hairdresser
        public class Hairdresser
        {

            public string Name { get; set; } = "Anna";

            public List<Person> Persons { get; set; } = new List<Person>();

            public List<Product> Products { get; set; } = new List<Product>();

            public List<Service> Services { get; set; } = new List<Service>();

            public List<Order> Orders { get; set; } = new List<Order>();

            public Hairdresser()
            {
                SeedMasters();
                SeedClients();
            }
            private void SeedMasters()
            {
                Master master1 = new Master(3) { Name = "John Smith" };
                Master master2 = new Master(4) { Name = "Jane Doe" };
                Master master3 = new Master(5) { Name = "Mark Johnson" };
                Persons.Add(master1);
                Persons.Add(master2);
                Persons.Add(master3);
            }
            private void SeedClients()
            {
                Client client1 = new Client(3250);
                Client client2 = new Client(5645);
                Client client3 = new Client(2500);
                Persons.Add(client1);
                Persons.Add(client2);
                Persons.Add(client3);
            }
            public void ShowItems<T>(List<T> items, Action<T> printMethod)
            {
                Console.WriteLine($"\nList elements type {typeof(T).Name}:");
                int i = 1;
                foreach (T item in items)
                {
                    Console.Write($"№{i}\t|");
                    printMethod(item);
                    i++;
                }
            }

            #region Person
            public void ShowPerson() { ShowItems(Persons, p => p.PrintInfo()); }
            public delegate void PersonAddedEventHandler(object sender, EventArgs e);

            public event PersonAddedEventHandler PersonAdded;

            public void AddPerson()
            {
                Console.Clear();
                ShowPerson();
                Console.WriteLine("\nChoose whom you want to add:");
                Console.WriteLine("\nIf you want to add a Master - (1)");
                Console.Write("If you want to add a Client - (2)\n");
                Console.Write("Your choice: ");

                int b = int.Parse(Console.ReadLine());
                if (b == 1)
                {
                    Console.Write("Enter professional experience from 1 to 5:  ");
                    int rank = int.Parse(Console.ReadLine());
                    Master master = new Master(rank);
                    Persons.Add(master);
                }
                else if (b == 2)
                {
                    Console.WriteLine("Enter amount of money:");
                    int money = int.Parse(Console.ReadLine());
                    Client client = new Client(money);
                    Persons.Add(client);
                }
                Console.Clear();

                Console.WriteLine("Do you want to add? Enter 'y' (if not, enter anything)");

                bool Check = (Console.ReadLine()) == "y" ? true : false;
                Console.Clear();
                if (Check)
                {
                    AddPerson();
                }

                OnPersonAdded(EventArgs.Empty);
            }

            protected virtual void OnPersonAdded(EventArgs e)
            {
                PersonAdded?.Invoke(this, e);
            }
            public void RemovePerson()
            {
                ShowPerson();
                Console.WriteLine("Select who you want to delete");
                Console.Write($"Enter the number:");
                int idRemovePerson = int.Parse(Console.ReadLine()) - 1;
                Persons.RemoveAt(idRemovePerson);
                Console.Clear();
            }

            #endregion

            #region Product

            public void ShowProduct() { ShowItems(Products, p => p.PrintInfo()); }

            public delegate void ProductAddedEventHandler(object sender, EventArgs e);
            public event ProductAddedEventHandler ProductAdded;

            public void AddProduct()
            {
                Console.Clear();

                ShowProduct();
                Console.WriteLine("Enter the new name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the new price:");
                int price = int.Parse(Console.ReadLine());
                Product product = new Product(name, price);
                Products.Add(product);
                Console.Clear();

                Console.WriteLine("Do you want add? Enter  'y' (otherwise, enter anything)");
                bool Check = (Console.ReadLine()) == "y" ? true : false;
                Console.Clear();
                if (Check)
                {
                    AddProduct();
                }

                ProductAdded?.Invoke(this, EventArgs.Empty);
            }

            public void RemoveProduct()
            {
                ShowProduct();
                Console.WriteLine("Choose what you want to delete");
                Console.Write($"Enter the number:");
                int idRemoveProduct = int.Parse(Console.ReadLine()) - 1;
                Products.RemoveAt(idRemoveProduct);
                Console.Clear();
            }
            #endregion

            #region Service

            public void ShowService() { ShowItems(Services, p => p.PrintInfo()); }
            public void AddService()
            {
                Console.WriteLine("\nSelect the service you want to add:");
                Console.Write("\n1. Haircut\n2. Coloring\n3. Manicure\n4. CosmeticProcedure\nEnter your choice (1-4): ");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter the price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Enter the type: ");
                string type = Console.ReadLine();

                switch (choice)
                {
                    case 1:
                        Haircut haircut = new Haircut(type, price);
                        Services.Add(haircut);
                        break;
                    case 2:
                        Coloring coloring = new Coloring(type, price);
                        Services.Add(coloring);
                        break;
                    case 3:
                        Console.Write("Enter additional services: ");
                        string additionalServices = Console.ReadLine();
                        Manicure manicure = new Manicure(type, price, additionalServices);
                        Services.Add(manicure);
                        break;
                    case 4:
                        Console.Write("Enter the duration (in minutes): ");
                        int duration = int.Parse(Console.ReadLine());
                        CosmeticProcedure cosmeticProcedure = new CosmeticProcedure(type, price, duration);
                        Services.Add(cosmeticProcedure);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.Clear();

                Console.Write("Do you want to add another service? Enter 'y' ( Otherwise, enter anything else):  ");
                bool continueAdding = (Console.ReadLine() == "y");
                Console.Clear();
                if (continueAdding)
                {
                    AddService();
                }
            }
            public void RemoveService()
            {
                ShowService();
                Console.WriteLine("Choose what you want to delete:");
                Console.Write("Enter the number:");
                int idRemoveService = int.Parse(Console.ReadLine()) - 1;
                Services.RemoveAt(idRemoveService);
                Console.Clear();
            }
            #endregion

            #region Order
            public void ShowOrder() { ShowItems(Orders, p => p.PrintInfo()); }
            public void AddOrder()
            {
                Console.Clear();
                ShowOrder();

               
                Console.WriteLine("Select a client from the list of all people (enter the corresponding number):");
                ShowPerson();
                int clientIndex;
                while (!int.TryParse(Console.ReadLine(), out clientIndex) || clientIndex < 1 || clientIndex > Persons.Count || !(Persons[clientIndex - 1] is Client))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number corresponding to a client:");
                }

                Client client = (Client)Persons[clientIndex - 1];

                Console.WriteLine("Select a service from the list of all services (enter the corresponding number):");
                ShowService();
                int serviceIndex;
                while (!int.TryParse(Console.ReadLine(), out serviceIndex) || serviceIndex < 1 || serviceIndex > Services.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number corresponding to a service:");
                }

                Service service = Services[serviceIndex - 1];

             
                DateTime date;
                Console.WriteLine("Enter the date (format: dd/MM/yyyy):");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Invalid input. Please enter a valid date in the correct format (dd/MM/yyyy):");
                }

         
                Console.WriteLine("Select a master from the list of all people (enter the corresponding number):");
                ShowPerson();
                int masterIndex;
                while (!int.TryParse(Console.ReadLine(), out masterIndex) || masterIndex < 1 || masterIndex > Persons.Count || !(Persons[masterIndex - 1] is Master))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number corresponding to a master:");
                }

                Master master = (Master)Persons[masterIndex - 1];

                Order order = new Order(client, service, date, master);
                Orders.Add(order);

                Console.Clear();

                Console.WriteLine("Do you want to add order? Enter 'y' (if not, enter anything)");
                bool check = (Console.ReadLine()) == "y" ? true : false;
                Console.Clear();
                if (check)
                {
                    AddOrder();
                }
            }
            public void RemoveOrder()
            {
                ShowOrder();
                Console.WriteLine("Choose what you want to remove");
                Console.Write($"Enter the number:");
                int idRemoveOrder = int.Parse(Console.ReadLine()) - 1;
                Orders.RemoveAt(idRemoveOrder);
                Console.Clear();
            }

            #endregion

        }

        public class Order
        {
            public Client Client { get; set; }
            public Service Service { get; set; }
            public DateTime Date { get; set; }
            public Master Performer { get; set; }

            public Order(Client client, Service service, DateTime date, Master performer)
            {
                Client = client;
                Service = service;
                Date = date;
                Performer = performer;
            }

            public void Work()
            {
                Client.Money -= Service.Price * Performer.Rank;
            }
            public void PrintInfo()
            {
                Console.WriteLine("| {0,-20} | {1,-20} | {2,-12} | {3,-20} |", "Client", "Service", "Date", "Performer");
                Console.WriteLine("| {0,-20} | {1,-20} | {2,-12} | {3,-20} |", $"{Client.Name} {Client.Surname}", Service.Name, Date.ToString("dd/MM/yyyy"), $"{Performer.Name} {Performer.Surname}");
            }


        }

        #endregion

        #region services
        public abstract class Service : IEditor
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Type { get; set; }
            public Service(string name, int price, string type)
            {
                Name = name;
                Price = price;
                Type = type;
            }

            public virtual void PrintInfo()
            {
                Console.WriteLine($"{Name}: {Price} UAH");
            }
            public virtual void Edit()
            {
                Console.WriteLine($"Editing {Name}");
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    this.Name = newName;
                }
                Console.Write("\nEnter new price: ");
                string newPriceStr = Console.ReadLine();
                int newPrice;
                if (int.TryParse(newPriceStr, out newPrice))
                {
                    this.Price = newPrice;
                }
            }


        }

        class Haircut : Service
        {
            public Haircut(string type, int price) : base("Haircut", price, type) { }

            public override void PrintInfo()
            {
                Console.WriteLine($"{Name} ({Type}): {Price} UAH");
            }

            public override void Edit()
            {
                base.Edit();
                Console.Write("\nEnter new type:");
                this.Type = Console.ReadLine();
            }
        }
        class Coloring : Service
        {
            public Coloring(string type, int price) : base("Hair Coloring", price, type) { }

            public override void PrintInfo()
            {
                Console.WriteLine($"{Name} ({Type}): {Price} UAH");
            }

            public override void Edit()
            {
                base.Edit();
                Console.Write("\nEnter new type:");
                this.Type = Console.ReadLine();
            }
        }
        class Manicure : Service
        {
            public string AdditionalServices { get; set; }

            public Manicure(string type, int price, string additionalServices) : base("Manicure", price, type)
            {
                AdditionalServices = additionalServices;
            }

            public override void PrintInfo()
            {
                Console.WriteLine($"{Name} ({Type}): {Price} UAH, Additional services: {AdditionalServices}");
            }

            public override void Edit()
            {
                base.Edit();
                Console.Write("\nEnter new type:");
                this.Type = Console.ReadLine();
                Console.Write("\nEnter additional services:");
                this.AdditionalServices = Console.ReadLine();
            }

        }
        class CosmeticProcedure : Service
        {
            public int Duration { get; set; }

            public CosmeticProcedure(string type, int duration, int price) : base("Cosmetic procedure", price, type)
            {
                Duration = duration;
            }

            public override void PrintInfo()
            {
                Console.WriteLine($"{Name} ({Type}, {Duration} min): {Price} UAH");
            }

            public override void Edit()
            {
                base.Edit();
                Console.Write("\nEnter new type:");
                this.Type = Console.ReadLine();
                Console.Write("\nEnter new duration:");
                this.Duration = int.Parse(Console.ReadLine());
            }
        }
        #endregion

        #region people
        public abstract class Person : IEditor
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public string Type { get; set; }
            public virtual void Edit()
            {
                PrintInfo();
                Console.WriteLine("Enter new name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter new surname:");
                Surname = Console.ReadLine();
                Console.WriteLine("Enter new phone number:");
                PhoneNumber = Console.ReadLine();
            }
            public virtual void PrintInfo()
            {
                Console.WriteLine($"Type: {Type,-10} | Name: {Name,-15} | Surname: {Surname,-15} | Phonenumber: {PhoneNumber,-15} |");
            }

            public Person()
            {
                Random rand = new Random();
                Names randomName = (Names)Enum.GetValues(typeof(Names)).GetValue(rand.Next(Enum.GetValues(typeof(Names)).Length));
                Name = randomName.ToString();

                Surnames surname = (Surnames)Enum.GetValues(typeof(Surnames)).GetValue(rand.Next(Enum.GetValues(typeof(Surnames)).Length));
                Surname = surname.ToString();

                PhoneNumber = "+380";
                PhoneNumber += rand.Next(66, 99).ToString();
                PhoneNumber += rand.Next(1000000, 9999999).ToString();

            }
        }

        public class Client : Person
        {
            public Client(int money)
            {
                Type = "Client";
                Money = money;
            }
            public int Money { get; set; }

            public override void Edit()
            {
                base.Edit();
                Console.WriteLine("Enter amount of money:");
                Money = int.Parse(Console.ReadLine());
            }
        }
        public class Master : Person
        {
            public int Rank { get; set; }
            public Master(int rank)
            {

                Type = "Master";
                Rank = rank;
            }

            public void Work()
            {
                Console.WriteLine($"Master {Name} is working.");
            }
            public override void Edit()
            {
                base.Edit();
                Console.WriteLine("Enter rang:");
                Rank = int.Parse(Console.ReadLine());
            }
        }
        #endregion

        #region products
        public class Product : IEditor
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public Product(string name, int price)
            {
                Name = name;
                Price = price;
            }
            public void Edit()
            {
                PrintInfo();
                Console.Write("\nEnter new name:");
                Name = Console.ReadLine();
                Console.Write("\nEnter new price:");
                Price = int.Parse(Console.ReadLine());
            }
            public void PrintInfo()
            {
                Console.WriteLine($"Name: {Name}\t| Price: {Price}\t| ");
            }
        }
        #endregion

    }
}