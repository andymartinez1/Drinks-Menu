using Drinks_Menu.Models;
using Newtonsoft.Json;
using Spectre.Console;

namespace Drinks_Menu.Controllers;

public class DrinksController
{
    internal static HttpClient _client = new()
    {
        BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
    };

    internal static async Task<List<Category>> GetAllCategories(HttpClient client)
    {
        try
        {
            using var response = await client.GetAsync("list.php?c=list");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedJsonResponse = JsonConvert.DeserializeObject<Categories>(jsonResponse);

            var categories = deserializedJsonResponse.CategoriesList;

            return categories;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }

    internal static async Task<List<Drink>> GetDrinksByCategory(string category)
    {
        try
        {
            using var response = await _client.GetAsync($"filter.php?c={category}");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedJsonResponse = JsonConvert.DeserializeObject<Drinks>(jsonResponse);

            var drinks = deserializedJsonResponse.DrinksList;

            return drinks;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }

    internal static async Task<List<DrinkDetail>> GetDrinkDetails(string id)
    {
        try
        {
            using var response = await _client.GetAsync($"lookup.php?i={id}");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedJsonResponse = JsonConvert.DeserializeObject<DrinkDetails>(jsonResponse);

            var drink = deserializedJsonResponse.DrinkDetailList;

            return drink;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }
}