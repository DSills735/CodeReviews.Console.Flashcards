using Flashcards.SQL_Helpers;
using Flashcards.DTO;
using Flashcards.Mapping;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;


namespace Flashcards.Card_Ops;

internal class ViewCards
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();

    internal static List<FlashcardDTO> GetFlashcardDTOs(int stackId)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        return connection.Query<Entities.Flashcard>(SqlHelper.ReturnEntireStackWithStackID, new { StackID = stackId })
            .Select((card, index) => card.ToDto(index + 1))
            .ToList();
    }

    internal static void SingleSubjectCardsToTable(int stackId)
    {
        var flashcards = GetFlashcardDTOs(stackId);

        if (flashcards.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No flashcards found for this stack.[/]");
            Console.ReadKey();
            return;
        }

        var table = new Table().RoundedBorder().BorderColor(Color.Blue);
        table.AddColumn("[yellow]#[/]");
        table.AddColumn("[red]Question[/]");
        table.AddColumn("[green]Answer[/]");

        foreach (var card in flashcards)
        {
            table.AddRow(
                $"[yellow]{card.DisplayId}[/]",
                $"[red]{card.Question}[/]",
                $"[green]{card.Answer}[/]"
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[grey]Press any key to return to the study menu.[/]");
        Console.ReadKey();
        
    }
}

