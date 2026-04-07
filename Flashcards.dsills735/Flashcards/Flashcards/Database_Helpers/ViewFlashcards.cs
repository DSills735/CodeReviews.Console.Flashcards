using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Spectre.Console;


namespace Flashcards.Database_Helpers;

internal class ViewFlashcards
{
    static string? connectionString = Program.Program.config.GetConnectionString("DefaultConnection");

    

    internal static void FlashcardsToTable()
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        var cards = connection.Query(SQL_Helpers.SqlHelper.ViewFlashcards);

        var table = new Table()
            .RoundedBorder()
            .BorderColor(Color.Red);
        table.AddColumn("[red]Card ID[/]");
        table.AddColumn("[green]Question[/]");
        table.AddColumn("[yellow]Answer[/]");

        var count = 1;
        foreach(var card in cards)
        {
            table.AddRow($"[red]{count}[/]", $"[green]{card.Question}[/]", $"[yellow]{card.Answer}[/]");
            ++count;
        }
        AnsiConsole.Write(table);
    }
}
