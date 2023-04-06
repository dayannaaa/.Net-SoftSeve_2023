namespace Exam
{
    #endregion

    internal partial class Program
    {
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
                Console.WriteLine($"| {"Client",-20} | {"Service",-20} | {"Date",-12} | {"Performer",-20} |");
                Console.WriteLine($"| {Client.Name + " " + Client.Surname,-20} | {Service.Name,-20} | {Date.ToString("dd/MM/yyyy"),-12} | {Performer.Name + " " + Performer.Surname,-20} |");
            }


        }

    }
}