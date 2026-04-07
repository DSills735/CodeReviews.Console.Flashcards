using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Flashcards.SQL_Helpers;
using Flashcards.DTO;
using Flashcards.Mapping;

namespace Flashcards.Card_Ops;

internal class DeleteFlashcard
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();

    internal static void DeleteSingleFlashcard()
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        var results = connection.Query<Entities.Flashcard>(SqlHelper.ViewFlashcards).ToList();

        var flashcards = results
            .Select((card, index) => card.ToDto(index + 1))
            .ToList();

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

        var resp = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the [green]Flashcard #[/] to delete:")
                .InvalidChoiceMessage("[red]That's not a valid number![/]")
                .Validate(displayId =>
                {
                    return flashcards.Any(f => f.DisplayId == displayId)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[maroon]No flashcard with that number.[/]");
                }));

        var target = flashcards.First(f => f.DisplayId == resp);

        bool confirmed = AnsiConsole.Confirm($"[maroon]Are you sure you want to delete flashcard #{resp}?[/]");

        if (confirmed)
        {
            connection.Execute(SqlHelper.DeleteFlashcard, new { FlashcardID = target.Id });
        }

        Menus.DeleteMenu.DeleteMenus();
    }
}