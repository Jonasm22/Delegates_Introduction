namespace Events
{

    public delegate void Notify(string message);
        public class EventPublisher
        {
            public event Notify OnNotify;

            public void RaiseEvent(string message)
            {

                OnNotify?.Invoke(message); // Invoke the event if there are any subscribers

            }

        }



        public class EventSubscriber
        {
            public void OnEventRaised(string message)
            {
                Console.WriteLine("Event received: " +
                    " " + message);
            }
        }

    internal class Program
    {

        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();

            publisher.OnNotify += subscriber.OnEventRaised;

            publisher.RaiseEvent("TEST");
            Console.ReadLine();

        }
    }
}
