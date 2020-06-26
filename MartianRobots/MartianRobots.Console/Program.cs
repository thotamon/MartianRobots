namespace MartianRobots.Console
{
    using System;
    using MartianRobots.Core;

    class Program
    {
        public static void Main(string[] args)
        {
            var inputController = new InputController(s => Console.WriteLine(s));
            bool running = true;
            Console.CancelKeyPress += (s, e) => { running = false; e.Cancel = true; };

            while (running)
            {
                var command = Console.ReadLine();
                inputController.ProcessLine(command);
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
