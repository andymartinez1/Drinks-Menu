using Drinks_Menu.Controllers;
using Spectre.Console;

namespace Drinks_Menu.Views;

public class UserInterface
{
    internal static async Task<string> ChooseCategory()
    {
        var categories = await DrinksController.GetAllCategories(DrinksController._client);

        var categoryArray = categories.Select(c => c.strCategory).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Please select a drink category:")
            .AddChoices(categoryArray));

        var categoryOption = categories.FirstOrDefault(c => c.strCategory == option);

        return categoryOption.strCategory;
    }

    internal static async Task ViewDrinksByCategory()
    {
        var category = await ChooseCategory();
        
        var drinks = await DrinksController.GetDrinksByCategory(category);

        var table = new Table()
            .AddColumn($"{category} Drinks");
        
        foreach (var drink in drinks)
        {
            table.AddRow(drink.strDrink);
        }
        
        AnsiConsole.Write(table);
    }
}