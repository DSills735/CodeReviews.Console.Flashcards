using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;
using Flashcards.Mapping;

namespace Flashcards.Study;

internal class Quiz
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();

    internal static void SingleSubjectQuiz()
    {
        Console.Clear();
        using SqlConnection connection = new SqlConnection(connectionString);

        Database_Helpers.ViewStacks.DisplayStacksForUpdate();

        var stackId = AnsiConsole.Prompt(
            new TextPrompt<int>("What [green]Stack ID[/] would you like to be quizzed on?")
                .InvalidChoiceMessage("[red]That's not a valid ID format![/]")
                .Validate(id =>
                {
                    int count = connection.ExecuteScalar<int>(SQL_Helpers.SqlHelper.SearchStacksByID, new { StackID = id });
                    return count > 0
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[maroon]Stack not found.[/] Please enter an ID from the table above.");
                }));

        var flashcards = connection.Query<Entities.Flashcard>(SQL_Helpers.SqlHelper.ReturnEntireStackWithStackID, new { StackID = stackId })
            .Select((card, index) => card.ToDto(index + 1))
            .ToList();

        int score = 0;

        foreach (var card in flashcards)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[yellow]Question {card.DisplayId}:[/] {card.Question}");
            AnsiConsole.MarkupLine("[grey]Press any key to reveal the answer...[/]");
            Console.ReadKey();

            AnsiConsole.MarkupLine($"[green]Answer:[/] {card.Answer}");
            Console.WriteLine();

            if (AnsiConsole.Confirm("Did you get it right?"))
            {
                score++;
            }
        }

        Console.Clear();
        AnsiConsole.MarkupLine("[bold]You've finished the stack![/]");

        decimal finalScore = QuizHelper.ScoreGrader(score, flashcards.Count);
        QuizHelper.FinalScorePrintout(finalScore);

        AnsiConsole.Status()
            .Start("Saving your score...", ctx =>
            {
                ctx.Spinner(Spinner.Known.Aesthetic);
                connection.Execute(SQL_Helpers.SQL_History.AddToHistory, new { Date = QuizHelper.TodaysDate(), Score = finalScore });
            });
    }
}


