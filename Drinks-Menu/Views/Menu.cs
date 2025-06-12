using Spectre.Console;

namespace Drinks_Menu.Views;

public class Menu
{
    internal async Task MainMenu()
    {
        var IsRunning = true;
        while (IsRunning)
        {
            AnsiConsole.Write(new FigletText("Drinks Menu")
                .Color(Color.DarkSeaGreen3));
            var userChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Please choose an option:")
                .HighlightStyle(Style.Parse("bold yellow"))
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(
                    "View Drinks Menu",
                    "Exit"));
            switch (userChoice)
            {
                case "View Drinks Menu":
                    AnsiConsole.Clear();
                    await UserInterface.ChooseDrinkByName();
                    break;
                case "Exit":
                    AnsiConsole.WriteLine("Thank you for using the Drinks Menu. Goodbye!");
                    IsRunning = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}