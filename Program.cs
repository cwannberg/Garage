﻿using Garage.UI;

namespace Garage;

internal class Program
{
    static void Main(string[] args)
    {
        var ui = new ConsoleUI();
        ui.ShowWelcomeMessage();
    }
}
