using System;

namespace Calculator
{
    public class MenuItem
    {
        // displayed in the menu
        public string Title { get; set; }

        // The corresponding function
        public Action Action { get; set; }
    }
}
