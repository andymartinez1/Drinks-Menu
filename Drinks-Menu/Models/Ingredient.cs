using Newtonsoft.Json;

namespace Drinks_Menu.Models;

public class Ingredient
{
    public string strIngredient1 { get; set; }
}

public class Ingredients
{
    [JsonProperty("drinks")]
    public List<Category> IngredientList { get; set; }
}