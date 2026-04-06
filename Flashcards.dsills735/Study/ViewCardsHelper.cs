using Flashcards.SQL_Helpers;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;

namespace Flashcards.Study
{
    internal class ViewCardsHelper
    {
        static string? connectionString = Database_Helpers.ConnectionString.ConnString();
        internal static void GetStackID()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            var stacks = connection.Query(SqlHelper.ViewStacks()).ToList();


            var table = new Table()
                    .RoundedBorder()
                    .BorderColor(Color.Blue);
            table.AddColumn("[red]Stack ID[/]");
            table.AddColumn("[green]Subject[/]");

            foreach (var stack in stacks)
            {
                table.AddRow($"[red]{stack.StackID}[/]", $"[green]{stack.Subject}[/]");
            }

            AnsiConsole.Write(table);

            Console.WriteLine("What stack to you want to view?");
            string resp = Console.ReadLine()!;
            Validation.StackValidation.IsTheStackIDInputValid(resp);

            Card_Ops.ViewCards.SingleSubjectCardsToTable(resp);

        }
    }
}
