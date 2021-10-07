using System;
using System.Linq;

namespace Calculator
{
    public class Program
    {
        private static readonly Calculator _calculator = new Calculator();
        private static readonly User User = new User();
        private static readonly Menu _menu = Menu.Build(User, _calculator);

        private static void Main()
        {
            Run();
        }

        private static void Run()
        {
            _menu.PrintToConsole();
            DrawSum();
            try
            {
                _menu.SetActiveMenu();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            finally
            {
                Console.Clear();
                Run();
            }
        }

        private static void DrawSum()
        {
            Console.WriteLine("Sum: {0}", _calculator.Sum);
        }
    }
}