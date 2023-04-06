namespace Exam
{
    #endregion

    internal partial class Program
    {
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



    }
}