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

    internal static async Task<string> ChooseDrinkByCategory()
    {
        var category = await ChooseCategory();

        var drinks = await DrinksController.GetDrinksByCategory(category);

        var drinksArray = drinks.Select(d => d.strDrink).ToArray();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Please select a drink:")
            .AddChoices(drinksArray));

        var drinkOption = drinks.FirstOrDefault(d => d.strDrink == option).idDrink;

        return drinkOption;
    }

    internal static async Task ChooseDrinkByName()
    {
        var drinkId = await ChooseDrinkByCategory();

        var drink = await DrinksController.GetDrinkDetails(drinkId);

        var ingredientList = new List<string>();

        for (var i = 1; i <= 15; i++)
        {
            var ingredient = drink.FirstOrDefault(d => d.idDrink == drinkId)
                .GetType().GetProperty($"strIngredient{i}")
                ?.GetValue(drink.FirstOrDefault(d => d.idDrink == drinkId), null);

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
            drink.FirstOrDefault(d => d.idDrink == drinkId).strDrink,
            drink.FirstOrDefault(d => d.idDrink == drinkId).strAlcoholic,
            drink.FirstOrDefault(d => d.idDrink == drinkId).strGlass,
            drink.FirstOrDefault(d => d.idDrink == drinkId).strInstructions,
            ingredients
        );

        AnsiConsole.Write(table);
    }
}