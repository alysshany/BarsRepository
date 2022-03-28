using System;

namespace DelegateEventTask
{
    class Program
    {
        static void Main(string[] args)
        {
            EventClass events = new EventClass();
            events.OnKeyPressed += Handler;
            events.Run();
        }

        public static void Handler(object? sender, char charKey)
        {
            Console.WriteLine($"Your char: {charKey}");
        }
    }

    public class EventClass
    {
        public event EventHandler<char> OnKeyPressed;

        public void Run()
        {
            bool going = true;
            while (going)
            {
                Console.WriteLine("Press the key:");
                var letter = Convert.ToChar(Console.ReadLine());

                if (letter == 'c')
                {
                    going = false;
                }
                else
                {
                    OnKeyPressed?.Invoke(this, letter);
                }
            }
        }
    }
}
