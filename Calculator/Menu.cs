using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Menu
    {
        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public List<MenuItem> MenuItems { get; set; }

        public virtual void PrintToConsole()
        {
            foreach (var item in MenuItems) Console.WriteLine("{0} : {1}", MenuItems.IndexOf(item), item.Title);
        }

        public static MenuItem CreateWithAction(string title, Action action)
        {
            return new MenuItem
            {
                Title = title,
                Action = action
            };
        }

        public static Menu Build(User user, Calculator calculator)
        {
            var menu = new Menu();
            menu.MenuItems.Add(CreateWithAction("Exit", () => Environment.Exit(0)));
            foreach (var operatorValue in Enum.GetValues(typeof(Operators)))
            {
                var @operator = (Operators) operatorValue;
                menu.MenuItems.Add(CreateWithAction(
                    @operator.ToString(),
                    () => user.OperateCalculator(calculator, @operator)
                ));
            }

            menu.MenuItems.Add(CreateWithAction("Clear", () => calculator.Clear()));
            return menu;
        }

        public void SetActiveMenu(int choiceIndex)
        {
            if (!IsValidIndex(choiceIndex)) throw new ArgumentOutOfRangeException();
            var menuItemSelected = MenuItems[choiceIndex];
            menuItemSelected.Action();
        }

        public void SetActiveMenu()
        {
            var index = Input.Int();
            SetActiveMenu(index);
        }

        public bool IsValidIndex(int choiceIndex)
        {
            return choiceIndex >= 0 && choiceIndex < MenuItems.Count;
        }
    }
}