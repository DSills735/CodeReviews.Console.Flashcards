using Spectre.Console;
namespace Flashcards.Menus
{
    internal class DeleteMenu
    {
        internal static void DeleteMenus()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the delete menu. What do you want to delete?");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[maroon][rapidblink] WARNING!![/][/] Deleting a subject will delete all flashcards within the subject");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[green]1. Individual Flashcard[/]");
            AnsiConsole.MarkupLine("[red]2. An entire subject[/]");
            AnsiConsole.MarkupLine("3. Go to the study section.");
            AnsiConsole.MarkupLine("4. Return to the main menu.");

            string temp = Console.ReadLine().Trim();

            switch (temp)
            {
                case "1":
                    Card_Ops.DeleteFlashcard.DeleteSingleFlashcard();
                    break;

                case "2":
                    Stack_Ops.DeleteStacks.DeleteStack();
                    break;

                case "3":
                    StudyMenu.StudyHome();
                    break;

                case "4":
                    MainMenu.HomeScreen();
                    break;

                default:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[rapidblink][maroon]Invalid Response![/][/] Please choose a [bold][underline]valid option from the list[/][/].");
                    AnsiConsole.Status()
                         .Start("Regenerating options...", ctx =>
                         {
                             ctx.Spinner(Spinner.Known.Aesthetic);
                             Thread.Sleep(3000);
                         });
                    DeleteMenus();
                    break;

            }
        }
    }
}
