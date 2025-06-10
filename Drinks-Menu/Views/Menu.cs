using Drinks_Menu.Controllers;
using Spectre.Console;

namespace Drinks_Menu.Views;

public class Menu
{
    internal async Task MainMenu()
    {
        var isMenuRunning = true;
        while (isMenuRunning)
        {
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        "View Drink Categories",
                        "2",
                        "3",
                        "Quit"));
            switch (userChoice)
            {
                case "View Drink Categories":
                    AnsiConsole.Clear();
                    var client = DrinksController._client;
                    await DrinksController.GetAllCategories(client);
                    break;
                case "2":
                    AnsiConsole.Clear();
                    break;
                case "3":
                    AnsiConsole.Clear();
                    break;
                case "Quit":
                    AnsiConsole.Clear();
                    AnsiConsole.WriteLine("Goodbye");
                    isMenuRunning = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }
}