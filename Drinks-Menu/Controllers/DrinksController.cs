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
            using HttpResponseMessage response = await client.GetAsync("list.php?c=list");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedJsonResponse = JsonConvert.DeserializeObject<Categories>(jsonResponse);

            List<Category> categories = deserializedJsonResponse.CategoriesList;

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
            using HttpResponseMessage response = await _client.GetAsync($"filter.php?c={category}");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedJsonResponse = JsonConvert.DeserializeObject<Drinks>(jsonResponse);

            List<Drink> drinks = deserializedJsonResponse.DrinksList;

            return drinks;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }

    internal static async Task<List<DrinkDetail>> GetDrinksByName(string name)
    {
        using HttpResponseMessage response = await _client.GetAsync($"filter.php?s={name}");

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        var deserializedJsonResponse = JsonConvert.DeserializeObject<DrinkDetails>(jsonResponse);

        List<DrinkDetail> drink = deserializedJsonResponse.DrinkDetailList;

        return drink;
    }
}