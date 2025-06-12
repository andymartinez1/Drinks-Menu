using Drinks_Menu.Controllers;
using Spectre.Console;

namespace Drinks_Menu.Views;

public class Menu
{
    internal async Task MainMenu()
    {
        bool IsRunning = true;
        while (IsRunning)
        {
            AnsiConsole.Write(new FigletText("Drinks"));
            await UserInterface.ChooseDrinkByName();
        }
        AnsiConsole.WriteLine("Thank you for using the Drinks Menu!");
    }
}