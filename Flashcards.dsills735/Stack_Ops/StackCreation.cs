using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;

namespace Flashcards.Stack_Ops
{
    internal class StackCreation
    {
        
        static string? connectionString = Database_Helpers.ConnectionString.ConnString();
        public static void CreateStack()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            Console.Clear();
            
            AnsiConsole.MarkupLine("[slowblink]Welcome to the create a stack area.[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("Please enter a unique name for the subject you wish to create.");

            string name = Console.ReadLine()!;

            bool exists = false;


            while (!exists)
            {
                int count = connection.ExecuteScalar<int>(SQL_Helpers.SqlHelper.SearchStacks(), new { Subject = name });

                if (count > 0)
                {
                    
                    AnsiConsole.MarkupLine(@"[rapidblink][maroon]ERROR!![/][/][red] You cannot create a new subject with an existing name.[/] Please enter another name.");
                    name = Console.ReadLine()!;
                }
                else
                {
                    exists = true;
                }

            }
            
            
            AnsiConsole.Status()
                .Start("Creating stack...", ctx =>
                {
                    connection.Execute(SQL_Helpers.SqlHelper.AddToStacks(), new { Subject = name });
                    ctx.Spinner(Spinner.Known.Aesthetic);
                    Thread.Sleep(3000);
                });

            AnsiConsole.MarkupLine($"[green]{name} stack has been successfully created![/]");

            AnsiConsole.Status()
                .Start("Returning to Creator menu...", ctx =>
                {
                   
                    ctx.Spinner(Spinner.Known.Aesthetic);
                    Thread.Sleep(1000);
                    
                });
            
            Menus.CreationMenu.StackCreationMenu();
        }
        
    }
}
