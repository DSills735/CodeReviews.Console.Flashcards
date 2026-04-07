
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;
namespace Flashcards.Validation;

internal class StackValidation
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();
    internal static void IsTheStackIDInputValid(string resp)
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        bool exists = false;
        while (!exists)
        {
            int count = connection.ExecuteScalar<int>(SQL_Helpers.SqlHelper.SearchStacksByID, new { StackID = resp });

            if (count == 0)
            {

                AnsiConsole.MarkupLine(@"[rapidblink][maroon]ERROR!![/][/][red] This stack was not found.[/] Please ensure the ID you are entering is reflected on the table above.");
                resp = Console.ReadLine()!;
            }
            else
            {
                exists = true;
            }
        }
    }
}
