using Newtonsoft.Json;

namespace Drinks_Menu.Models;

public class AlcoholicFilter
{
    public string strAlcoholic { get; set; }
}

public class AlcoholicFilters
{
    [JsonProperty("drinks")]
    public List<Category> AlcoholicFilterList { get; set; }
}