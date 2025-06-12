using System.Reflection;
using Drinks_Menu.Controllers;
using Drinks_Menu.Models;
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

    internal static async Task<string> ChooseDrinkByCategory()
    {
        var category = await ChooseCategory();

        var drinks = await DrinksController.GetDrinksByCategory(category);

        var drinksArray = drinks.Select(d => d.strDrink).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Please select a drink:")
            .AddChoices(drinksArray));

        return option;
    }

    internal static async Task ChooseDrinkByName()
    {
        var drinkByCategory = await ChooseDrinkByCategory();

        var drink = await DrinksController.GetDrinksByName(drinkByCategory);
        
        var properties = drink.GetType().GetProperties();
        
        var values = properties.ToDictionary(p => p.Name, 
            p => p.GetValue(drink) as string ?? "no data found");

        foreach (var property in values)
        {
            if(property.Value.Equals("no data found")) continue;
            AnsiConsole.MarkupLine("[green]{0}[/]: [yellow]{1}[/]", property.Key, property.Value);
        }
    }
}