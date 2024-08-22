namespace Genericos_Lecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1, 2, 3 ,4 ,5};
            string[] StringArray2 = { "one", "two", "Three", "for" };

            PrintArray(intArray);
            PrintArray(StringArray2);

      
        }

        

        public static void PrintIntArray(int[] array)
        {
            foreach (int item in array) {
                Console.WriteLine(item);

            }
        }

        public static void PrintStringArray(string[] array)
        {
            foreach (string item in array) {
                Console.WriteLine(item);

            }
        }

        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
    
                Console.WriteLine(item);
            }

        }
    }
}


