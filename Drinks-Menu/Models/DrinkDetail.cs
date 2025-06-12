﻿using Newtonsoft.Json;

namespace Drinks_Menu.Models;

public class DrinkDetail
{
    [JsonProperty("idDrink")] public string DrinkId { get; set; }
    [JsonProperty("strDrink")] public string DrinkName { get; set; }
    [JsonProperty("strAlcoholic")] public string Alcoholic { get; set; }
    [JsonProperty("strGlass")] public string Glass { get; set; }
    [JsonProperty("strInstructions")] public string Instructions { get; set; }
    [JsonProperty("strIngredient1")] public string Ingredient1 { get; set; }
    [JsonProperty("strIngredient2")] public string Ingredient2 { get; set; }
    [JsonProperty("strIngredient3")] public string Ingredient3 { get; set; }
    [JsonProperty("strIngredient4")] public string Ingredient4 { get; set; }
    [JsonProperty("strIngredient5")] public string Ingredient5 { get; set; }
    [JsonProperty("strIngredient6")] public string Ingredient6 { get; set; }
    [JsonProperty("strIngredient7")] public string Ingredient7 { get; set; }
    [JsonProperty("strIngredient8")] public string Ingredient8 { get; set; }
    [JsonProperty("strIngredient9")] public string Ingredient9 { get; set; }
    [JsonProperty("strIngredient10")] public string Ingredient10 { get; set; }
    [JsonProperty("strIngredient11")] public string Ingredient11 { get; set; }
    [JsonProperty("strIngredient12")] public string Ingredient12 { get; set; }
    [JsonProperty("strIngredient13")] public string Ingredient13 { get; set; }
    [JsonProperty("strIngredient14")] public string Ingredient14 { get; set; }
    [JsonProperty("strIngredient15")] public string Ingredient15 { get; set; }
}

public class DrinkDetails
{
    [JsonProperty("drinks")] public List<DrinkDetail> DrinkDetailList { get; set; }
}