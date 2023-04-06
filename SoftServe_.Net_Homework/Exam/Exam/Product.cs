namespace Exam
{
  

    internal partial class Program
    {
     
        #region people
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