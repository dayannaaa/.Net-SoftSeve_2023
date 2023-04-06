namespace Exam
{


    internal partial class Program
    {
        
        #region people
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

    }
}