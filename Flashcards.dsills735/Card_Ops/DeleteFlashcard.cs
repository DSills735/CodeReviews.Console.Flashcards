using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;

namespace Flashcards.Card_Ops
{
    internal class DeleteFlashcard
    {
        static string? connectionString = Database_Helpers.ConnectionString.ConnString();

        internal static void DeleteSingleFlashcard()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            Console.WriteLine("What flashcard would you like to delete? (Enter the ID)");
            Console.WriteLine();

            Database_Helpers.ViewFlashcards.FlashcardsToTable();
            bool exists = false;

            var resp = AnsiConsole.Prompt(
    new TextPrompt<int>("Enter the [green]Flashcard ID[/]:")
        .InvalidChoiceMessage("[red]That's not a valid ID format![/]")
        .Validate(id =>
        {
            int count = connection.ExecuteScalar<int>(
                SQL_Helpers.SqlHelper.SearchFlashcardsByID(),
                new { FlashcardID = id }
            );

            return count > 0
                ? ValidationResult.Success()
                : ValidationResult.Error("[maroon]ERROR!![/] This stack was not found.");
        }));

            AnsiConsole.MarkupLine("[rapidblink][maroon] Are you sure you want to delete this flashcard?[/][/] Y / N");

            string tmp = Console.ReadLine()!.Trim().ToLower();

            if (tmp == "y")
            {
                connection.Execute(SQL_Helpers.SqlHelper.DeleteFlashcard(), new { FlashcardID = resp });
                AnsiConsole.Status()
                .Start("Deleting flaschard and returning you to the delete menu. ", ctx =>
                {

                    ctx.Spinner(Spinner.Known.Aesthetic);
                    Thread.Sleep(3000);
                });
                Menus.DeleteMenu.DeleteMenus();
            }
            else
            {
                AnsiConsole.Status()
                .Start("Stopping flaschard deletion and returning you to the Delete menu. ", ctx =>
                {

                    ctx.Spinner(Spinner.Known.Aesthetic);
                    Thread.Sleep(3000);
                });

                Menus.DeleteMenu.DeleteMenus();
            }
        }
    }
}
