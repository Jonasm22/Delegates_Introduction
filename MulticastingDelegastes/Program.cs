namespace MulticastingDelegastes
{
    internal class Program
    {
        public delegate void LogHandler(string message);

        // Studing again the code class 209 
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
                    // creating a multicast delegate
                    Logger logger = new Logger();
                    LogHandler logHandler = logger.LogToConsole;
                    logHandler += logger.LogToFile;

                    // invoking the multicast delegate
                    logHandler("Log this Info");



                    foreach (LogHandler handler in logHandler.GetInvocationList())
                    {
                        try
                        {
                            handler("Event occurred with error handling");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception caught: " + ex.Message);
                        }




                        // removing a method from the multicast delegate
                        if(IsMethodInDelegate(logHandler, logger.LogToFile))
                        {
                            logHandler -= logger.LogToFile;
                            Console.WriteLine("Log to File method removed");
                        }
                        else
                        {
                            Console.WriteLine("Log to File Method not found");
                        }
                     
                        if(logHandler != null)
                        {
                            InvokeSafely(logHandler, "After removing LogTo File");
                            
                        }
                        
                        

                        //logHandler("After removing logToFile");

                        Console.ReadLine();
                    }

                }

                static void InvokeSafely(LogHandler logHandler, string message)
                {
                    LogHandler tempLogHandler = logHandler;
                    if (tempLogHandler != null)
                    {

                        tempLogHandler(message);

                    }

                }

                static bool IsMethodInDelegate(LogHandler logHandler, LogHandler method)
                {

                    if(logHandler == null)
                    {
                        return false;
                    }

                    foreach(var d in logHandler.GetInvocationList())
                    {
                        if(d == (Delegate)method)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            
            
            }



        }
    }

}
