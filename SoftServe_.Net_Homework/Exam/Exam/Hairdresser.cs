using System.Globalization;


namespace Exam
{
    #endregion

    internal partial class Program
    {
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
                CreateMasters();
                CreateClients();
            }
            private void CreateMasters()
            {
                Master master1 = new Master(3) { Name = "John Smith" };
                Master master2 = new Master(4) { Name = "Jane Doe" };
                Master master3 = new Master(5) { Name = "Mark Johnson" };
                Persons.Add(master1);
                Persons.Add(master2);
                Persons.Add(master3);
            }
            private void CreateClients()
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

    }
}