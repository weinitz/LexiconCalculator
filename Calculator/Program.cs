using System;
using System.Linq;

namespace Calculator
{
    class Program
    {
        private static readonly Menu menu = new Menu()
        {
            MenuItems =

                {
                new MenuItem()
                    {
                        Text = "Exit",
                        Action = () => Console.ReadKey()
                    },
                    new MenuItem()
                    {
                        Text = "Addition",
                        Action = () => InputAddition()
                    },
                    new MenuItem()
                    {
                        Text = "Substraction",
                        Action = () => InputSubstraction()
                    },
                    new MenuItem()
                    {
                        Text = "Division",
                        Action = () => InputDivision()
                    },
                new MenuItem()
                    {
                        Text = "Multiplication",
                        Action = () => InputMultiplication()
                    },
                    new MenuItem()
                    {
                        Text = "Clear",
                        Action = () => calculator.Clear()
                    }
            }
        };

        private static Calculator calculator;

        static void Main(string[] args)
        {
            calculator = new Calculator();
            while (ShowMenu()) ;
            Console.ReadKey();
        }

        private static Boolean ShowMenu()
        {
            Console.Clear();
            menu.PrintToConsole();
            Console.WriteLine("Sum: {0}", calculator.GetSum());
            string choice = Console.ReadLine();

            if (choice == "exit" || choice == "0")
            {
                return false;
            }

            if (!int.TryParse(choice, out int choiceIndex) || choiceIndex < 0 || choiceIndex >= menu.MenuItems.Count)
            {
                Console.Clear();

                Console.WriteLine("Invalid selection - try again");
                return ShowMenu();
            }
            else
            {
                Console.Clear();
                var menuItemSelected = menu.MenuItems[choiceIndex];
                menuItemSelected.Action();
                return true;
            }
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Sum: {0}", calculator.GetSum());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static double InputNumber(string op)
        {
            Console.WriteLine("Input number");
            Console.Write("{0}{1}", calculator.GetSum(), op);
            var input = Console.ReadLine();
            double number;
            double.TryParse(input, out number);

            return number;
        }

        private static double[] InputNumbers(string op)
        {
            Console.WriteLine("Input numbers seperated by {0}", op);
            var input = Console.ReadLine();
            String[] allDigits = input.Split(op);

            try
            {
                double[] numbers = allDigits.Select(d => double.Parse(d)).ToArray();
                return numbers;
            }
            catch
            {
                Console.WriteLine("Incorrect format. Please try again");
                return InputNumbers(op);
            }

        }

        private static void InputAddition()
        {
            if (calculator.IS_FIRST)
            {
                var number = InputNumbers("+");
                calculator.Addition(number);
            }
            else
            {
                var number = InputNumber("+");

                calculator.Addition(number);
            }
            PressAnyKeyToContinue();
        }

        private static void InputSubstraction()
        {
            if (calculator.IS_FIRST)
            {
                var number = InputNumbers("-");
                calculator.Subtraction(number);
            }
            else
            {
                var number = InputNumber("-");

                calculator.Subtraction(number);
            }
            PressAnyKeyToContinue();
        }

        private static void InputDivision()
        {
            try
            {
                if (calculator.IS_FIRST)
                {
                    var numbers = InputNumbers("/");
                    calculator.Division(numbers);
                }
                else
                {
                    var number = InputNumber("/");

                    calculator.Division(number);
                }
                PressAnyKeyToContinue();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("DivideByZeroException: {0}", e.Message);
                InputDivision();
            }
            
        }

        private static void InputMultiplication()
        {
            if (calculator.IS_FIRST)
            {
                var numbers = InputNumbers("*");
                calculator.Multiplication(numbers);
            }
            else
            {
                var number = InputNumber("*");
                calculator.Multiplication(number);
            }
            PressAnyKeyToContinue();
        }

    }
}
