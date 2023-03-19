namespace Task_14
{
    internal class Program
    {
        static void InitializeArray(int[] array, Func<int> generateValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = generateValue();
            }
        }
        static void InitializeArray(int[] array, Func<int, int> generateValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = generateValue(i);
            }
        }
        static void Main(string[] args)
        {
            int[] array = new int[15];
            InitializeArray(array, () => new Random().Next(1, 101));
            Console.WriteLine("Array Task 1: \n" + string.Join(", ", array));

            int[] arrayTaskTwo = new int[10];
            InitializeArray(arrayTaskTwo, i => (int)Math.Pow(2, i + 1));
            Console.WriteLine("\nArray Task 2: \n" + string.Join(", ", arrayTaskTwo));

            int[] arrayTaskThree = new int[20];
            InitializeArray(arrayTaskThree, i => i * 3);
            Console.WriteLine("\nArray Task 3: \n" + string.Join(", ", arrayTaskThree));

        }
    }
}