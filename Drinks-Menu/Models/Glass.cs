using Newtonsoft.Json;

namespace Drinks_Menu.Models;

public class Glass
{
    public string strGlass { get; set; }
}

public class Glasses
{
    [JsonProperty("drinks")]
    public List<Category> GlassesList { get; set; }
}