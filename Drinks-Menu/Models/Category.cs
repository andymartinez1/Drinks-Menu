using Newtonsoft.Json;

namespace Drinks_Menu.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public string DrinkCategory { get; set; }
}

public class Categories
{
    [JsonProperty("drinks")] public List<Category> CategoriesList { get; set; }
}