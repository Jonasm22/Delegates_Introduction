namespace Delegates_Introduction
{
    public delegate void LogHandler(string message);


    public class Logger
    {

        public void LogToConsole(string message)
        {

            Console.WriteLine("Console Log: " + message);

        }

        public void LogToFile(string message)
        {
            Console.WriteLine("File Log : " + message);

        }


        public class Program
        {

            static void Main(string[] args)
            {
                Logger logger = new Logger();
                LogHandler logHandler = logger.LogToConsole;
                logHandler("Logge to console.");

                logHandler = logger.LogToFile;
                logHandler("Log some stuff");

                Console.ReadLine();
            }



        }
    }
}
