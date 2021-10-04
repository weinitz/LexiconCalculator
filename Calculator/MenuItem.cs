﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    internal class MenuItem
    {
        // displayed in the menu
        public string Text { get; set; }

        // The corresponding function
        public Action Action { get; set; }

        public static MenuItem CreateWithAction(string title, Action action)
        {
            return new MenuItem()
            {
                Text = title,
                Action = action
            };
        }
    }
}