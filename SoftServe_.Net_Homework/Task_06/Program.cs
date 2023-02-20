namespace _Task_06
{

    class Rocket
    {
        private readonly string _name;
        private readonly int _payloadCapacity;
        private int? _currentPayloadWeight;

        public const int MAX_PAYLOAD_WEIGHT = 1000;

        public Rocket(string name, int payloadCapacity)
        {
            _name = name;
            _payloadCapacity = payloadCapacity;
        }
        public string Name
        {
            get { return _name; }
        }
        public int PayloadCapacity
        {
            get { return _payloadCapacity; }
        }
        public int? CurrentPayloadWeight
        {
            get { return _currentPayloadWeight; }
            set
            {
                if (value > MAX_PAYLOAD_WEIGHT)
                {
                    throw new ArgumentException($"Payload weight exceeds the maximum of {MAX_PAYLOAD_WEIGHT}.");
                }
                _currentPayloadWeight = value;
            }
        }

        public void Show()
        {
            Console.WriteLine($"Name: {_name}" +
                $" \nPayload Capacity = {_payloadCapacity}" +
                $"\nCurrent Payload Weight = {_currentPayloadWeight} ");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Rocket myRocket = new Rocket("Falcon 9", 5000);
            myRocket.CurrentPayloadWeight = 750; // встановлюємо вагу вантажу

            int rocketPayloadCapacity = myRocket.PayloadCapacity;
            int? currentPayloadWeight = myRocket.CurrentPayloadWeight;

            int maxPayloadWeight = Rocket.MAX_PAYLOAD_WEIGHT;

            myRocket.Show();


        }

    }
}