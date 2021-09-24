﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    internal class Menu
    {
        public List<MenuItem> MenuItems { get; set; }

        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public virtual void PrintToConsole()
        {
            foreach (MenuItem item in MenuItems)
            {
                Console.WriteLine("{0} : {1}", MenuItems.IndexOf(item), item.Text);
            }
        }
    }
}
