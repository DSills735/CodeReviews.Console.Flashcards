using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;

namespace Flashcards.Stack_Ops;

internal class DeleteStacks
{
    static string? connectionString = Database_Helpers.ConnectionString.ConnString();
    internal static void DeleteStack()
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        Console.WriteLine("What stack do you want to delete? (Enter StackID value)");
        Console.WriteLine();
        Database_Helpers.ViewStacks.DisplayStacksForUpdate();
        Console.WriteLine();

        string resp = Console.ReadLine();

        bool exists = false;


        while (!exists)
        {
            int count = connection.ExecuteScalar<int>(SQL_Helpers.SqlHelper.SearchStacksByID, new { StackID = resp });

            if (count == 0)
            {

                AnsiConsole.MarkupLine(@"[rapidblink][maroon]ERROR!![/][/][red] This stack was not found.[/] Please ensure the ID you are entering is reflected on the table above.");
                resp = Console.ReadLine();
            }
            else
            {
                exists = true;
            }
        }

        AnsiConsole.MarkupLine("[rapidblink][maroon] Are you sure you want to delete this stack, and all of the flashcards with it?[/][/] Y / N");

        string tmp = Console.ReadLine().Trim().ToLower();
        

        if( tmp == "y")
        {
            connection.Execute(SQL_Helpers.SqlHelper.DeleteStack, new { StackID = resp });
            AnsiConsole.Status()
            .Start("Deleting stack and returning you to the delete menu. ", ctx =>
            {

                ctx.Spinner(Spinner.Known.Aesthetic);
            });
            Menus.DeleteMenu.DeleteMenus();
        }
        else
        {
            AnsiConsole.Status()
            .Start("Stopping stack deletion and returning you to the Delete menu. ", ctx =>
            {
               
                ctx.Spinner(Spinner.Known.Aesthetic);
            });

            Menus.DeleteMenu.DeleteMenus();
        }
        

    }
}
