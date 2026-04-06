using Flashcards.SQL_Helpers;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;


namespace Flashcards.Card_Ops
{
    internal class ViewCards
    {
        static string? connectionString = Database_Helpers.ConnectionString.ConnString();
        internal static void SingleSubjectCardsToTable(string id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);


            var stacks = connection.Query(SqlHelper.ReturnEntireStackWithStackID(), new {StackID = id}).ToList();


            var table = new Table()
                    .RoundedBorder()
                    .BorderColor(Color.Blue);
            table.AddColumn("[yellow]Flashcard ID[/]");
            table.AddColumn("[red]Question[/]");
            table.AddColumn("[green]Answer[/]");

            foreach (var stack in stacks)
            {
                table.AddRow($"[yellow] {stack.FlashcardID}[/]", $"[red]{stack.Question}[/]", $"[green]{stack.Answer}[/]");
            }

            AnsiConsole.Write(table);
            Console.WriteLine("Press any key when you are ready to return to study menu.");
            Console.ReadKey();
            Menus.StudyMenu.StudyHome();
        }
        
    }
    }

