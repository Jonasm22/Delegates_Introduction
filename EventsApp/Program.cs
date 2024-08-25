namespace EventsApp
{

    public delegate void TemperatureChangeHandler(string message);
    public class TemeperatureMonitor
    {
        public event TemperatureChangeHandler OnTemperatureChanged;

        private int _temperature;

        public int Temperature
        {
            get { return _temperature; }

            set
            {
                _temperature = value;
                if (_temperature > 30)
                {
                    //RAISE EVENT!!
                    RaiseTemperutareChangedEvent("Temperature is above threshold");

                }
                else if (_temperature < 9)
                {
                    RaiseTemperutareChangedEvent("Take a jaket is very cold outside");
                }

            }
        }

        protected virtual void RaiseTemperutareChangedEvent(string message)
        {

            OnTemperatureChanged?.Invoke(message);

        }

    }

    public class TemperatureAlert
    {
        public void OnTemperatureChanged(string message)
        {
            Console.WriteLine("Alert: " + message);
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                TemeperatureMonitor monitor = new TemeperatureMonitor();
                TemperatureAlert alert = new TemperatureAlert();

                monitor.OnTemperatureChanged += alert.OnTemperatureChanged;
                monitor.Temperature = 20;
                Console.WriteLine("Please enter the temperature: ");
                monitor.Temperature = int.Parse(Console.ReadLine());


            }
        }
    }
}