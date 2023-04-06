namespace Exam
{
   
    internal partial class Program
    {
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

    }
}