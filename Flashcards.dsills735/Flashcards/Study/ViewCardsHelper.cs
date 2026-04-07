using Flashcards.SQL_Helpers;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;

namespace Flashcards.Study;

internal class ViewCardsHelper
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();

    internal static void GetStackID()
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        var table = new Table().RoundedBorder().BorderColor(Color.Blue);
        table.AddColumn("[red]Stack ID[/]");
        table.AddColumn("[green]Subject[/]");

        var stacks = connection.Query(SqlHelper.ViewStacks).ToList();

        foreach (var stack in stacks)
        {
            table.AddRow($"[red]{stack.StackID}[/]", $"[green]{stack.Subject}[/]");
        }

        AnsiConsole.Write(table);

        var stackId = AnsiConsole.Prompt(
            new TextPrompt<int>("Which [green]Stack ID[/] would you like to view?")
                .InvalidChoiceMessage("[red]That's not a valid ID format![/]")
                .Validate(id =>
                {
                    int count = connection.ExecuteScalar<int>(SqlHelper.SearchStacksByID, new { StackID = id });
                    return count > 0
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[maroon]Stack not found.[/] Please enter an ID from the table above.");
                }));

        Card_Ops.ViewCards.SingleSubjectCardsToTable(stackId);
    }
}
