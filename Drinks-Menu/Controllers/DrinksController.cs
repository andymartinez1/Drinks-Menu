

using Spectre.Console;

namespace Drinks_Menu.Controllers;

public class DrinksController
{
    internal static HttpClient _client = new HttpClient()
    {
        BaseAddress = new Uri("www.thecocktaildb.com/api/json/v1/1/")
    };

    internal static async Task GetAllDrinksByCategory(HttpClient client)
    {
        using HttpResponseMessage response = await client.GetAsync("list.php?c=list");
        
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        AnsiConsole.WriteLine($"{jsonResponse}");
    }
}