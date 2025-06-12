using Drinks_Menu.Controllers;
using Spectre.Console;

namespace Drinks_Menu.Views;

public class UserInterface
{
    internal static async Task<string> ChooseCategory()
    {
        var categories = await DrinksController.GetAllCategories(DrinksController._client);

        var categoryArray = categories.Select(c => c.DrinkCategory).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Please select a drink category:")
            .AddChoices(categoryArray));

        var categoryOption = categories.FirstOrDefault(c => c.DrinkCategory == option);

        return categoryOption.DrinkCategory;
    }

    internal static async Task<string> ChooseDrinkByCategory()
    {
        var category = await ChooseCategory();

        var drinks = await DrinksController.GetDrinksByCategory(category);

        var drinksArray = drinks.Select(d => d.DrinkName).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Please select a drink:")
            .AddChoices(drinksArray));

        var drinkOption = drinks.FirstOrDefault(d => d.DrinkName == option).DrinkId;

        return drinkOption;
    }

    internal static async Task ChooseDrinkByName()
    {
        var drinkId = await ChooseDrinkByCategory();

        var drink = await DrinksController.GetDrinkDetails(drinkId);

        var ingredientList = new List<string>();

        for (var i = 1; i <= 15; i++)
        {
            var ingredient = drink.FirstOrDefault(d => d.DrinkId == drinkId)
                .GetType().GetProperty($"Ingredient{i}")
                ?.GetValue(drink.FirstOrDefault(d => d.DrinkId == drinkId), null);

            if (ingredient != null && !string.IsNullOrEmpty(ingredient.ToString()))
                ingredientList.Add(ingredient.ToString());
        }

        var ingredients = string.Join(", ", ingredientList);

        var table = new Table()
            .AddColumn("Drink Name")
            .AddColumn("Alcoholic")
            .AddColumn("Glass Type")
            .AddColumn("Instructions")
            .AddColumn("Ingredients");
        table.AddRow(
            drink.FirstOrDefault(d => d.DrinkId == drinkId).DrinkName,
            drink.FirstOrDefault(d => d.DrinkId == drinkId).Alcoholic,
            drink.FirstOrDefault(d => d.DrinkId == drinkId).Glass,
            drink.FirstOrDefault(d => d.DrinkId == drinkId).Instructions,
            ingredients
        );

        AnsiConsole.Write(table);
    }
}