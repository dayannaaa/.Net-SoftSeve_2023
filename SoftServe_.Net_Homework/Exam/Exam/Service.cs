namespace Exam
{
    #endregion

    internal partial class Program
    {
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

    }
}