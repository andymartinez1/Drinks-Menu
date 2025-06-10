using Drinks_Menu.Controllers;
using Drinks_Menu.Models;
using Spectre.Console;

namespace Drinks_Menu.Views;

public class UserInterface
{
    internal static async Task ShowCategories(List<Category> categories)
    {
        var table = new Table();
        table.Title(new TableTitle("Drinks"));
        table.AddColumn(new TableColumn("Category"));

        foreach (var category in categories)
        {
            table.AddRow(category.strCategory);
        }

        AnsiConsole.Write(table);
    }
}