using Drinks_Menu.Models;
using Drinks_Menu.Views;
using Newtonsoft.Json;
using Spectre.Console;

namespace Drinks_Menu.Controllers;

public class DrinksController
{
    internal static HttpClient _client = new()
    {
        BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/")
    };

    internal static async Task GetAllCategories(HttpClient client)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync("list.php?c=list");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var deserializedJsonResponse = JsonConvert.DeserializeObject<Categories>(jsonResponse);

            List<Category> categories = deserializedJsonResponse.CategoriesList;
            
            UserInterface.ShowCategories(categories);
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine(e.Message);
            throw;
        }
    }
}