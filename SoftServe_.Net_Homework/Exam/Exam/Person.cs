namespace Exam
{
  

    internal partial class Program
    {
        
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
        #endregion

    }
}