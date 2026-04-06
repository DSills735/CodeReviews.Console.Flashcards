using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;


namespace Flashcards.Card_Ops
{
    internal class FlashcardCreation
    {

        static string? connectionString = Database_Helpers.ConnectionString.ConnString();

        internal static void CardCreator()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            bool reply = false;
            Console.WriteLine("Hello. Please choose the ID of a subject you would like to add this card to.");

            Database_Helpers.ViewStacks.DisplayStacksForUpdate();

            Console.WriteLine();


            string subj = Console.ReadLine();
            int stackID = Convert.ToInt32(subj);

            int subject = connection.ExecuteScalar<int>(SQL_Helpers.SqlHelper.SearchForSubjectID(), new { StackID = subj });

            AnsiConsole.Status()
                .Start("Searching for subject...", ctx =>
                 {

                     reply = Validation.DbValidation.ValidateSearchByStackID(subject);
                     ctx.Spinner(Spinner.Known.Aesthetic);
                     Thread.Sleep(3000);
                 });
            if (!reply)
            {
                CardCreator();
            }
            else
            {
                reply = true;
            }

            bool intended = false;
            string question = "";
            string answer = "";

            while (!intended)
            {
                Console.Clear();
                AnsiConsole.MarkupLine("What do you want the [underline][bold]question[/][/] to be?");

                question = Console.ReadLine();

                intended = Validation.FlashcardValidationHelper.FlashcardInputValidation(question);
            }

            intended = false;

            while (!intended)
            {
                Console.Clear();
                AnsiConsole.MarkupLine("What do you want the [underline][bold]answer[/][/] to be?");

                answer = Console.ReadLine();

                intended = Validation.FlashcardValidationHelper.FlashcardInputValidation(answer);
            }


            AnsiConsole.Status()
                .Start("Adding flashcard to database...", ctx =>
                {
                     
                    connection.Execute(SQL_Helpers.SqlHelper.AddToFlashcards(), new {Question = question, Answer = answer, StackID = stackID} );
                    ctx.Spinner(Spinner.Known.Aesthetic);
                    Thread.Sleep(3000);
                });

            AnsiConsole.MarkupLine($"[green]The flashcard has been successfully created![/]");

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


