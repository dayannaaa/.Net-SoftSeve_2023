namespace Exam
{
    #endregion

    internal partial class Program
    {
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



    }
}