namespace Exam
{
    

    internal partial class Program
    {
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
        

    }
}