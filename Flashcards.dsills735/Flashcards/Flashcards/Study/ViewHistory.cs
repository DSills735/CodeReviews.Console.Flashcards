using Dapper;
using Flashcards.SQL_Helpers;
using Microsoft.Data.SqlClient;
using Spectre.Console;

namespace Flashcards.Study;

internal class ViewHistory
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();

    internal static void PrintHistoryTable()
    {

        using SqlConnection connection = new SqlConnection(connectionString);
        var history = connection.Query(SQL_History.ViewHistory).ToList();

        var table = new Table()
                .RoundedBorder()
                .BorderColor(Color.Blue);
        table.AddColumn("[red]Date[/]");
        table.AddColumn("[green]Score[/]");

        foreach (var his in history)
        {
            table.AddRow($"[red]{his.Date}[/]", $"[green]{his.Score}%[/]");
        }

AnsiConsole.Write(table);
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();

        Menus.MainMenu.HomeScreen();
    }

}