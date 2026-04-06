using Spectre.Console;

namespace Flashcards.Menus
{
    internal class MainMenu
    {

        internal static void HomeScreen()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[slowblink][Blue]Welcome to the Flashcards app![/][/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("1. Add a new subject, or a new flashcard to an existing stack.");
            AnsiConsole.MarkupLine("2. Study");
            AnsiConsole.MarkupLine("3. Delete specific cards, or an entire subject");
            AnsiConsole.MarkupLine("4. View History");
            AnsiConsole.MarkupLine("[maroon]5. Exit Application[/]");


            string temp = Console.ReadLine().Trim() ;

            switch (temp)
            {
                case "1":
                    CreationMenu.StackCreationMenu();
                    break;

                case "2":
                    StudyMenu.StudyHome();
                    break;

                case "3":
                    DeleteMenu.DeleteMenus();
                    break;

                case "4":
                    Study.ViewHistory.PrintHistoryTable();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    AnsiConsole.MarkupLine("[rapidblink][maroon]Invalid Response![/][/] Please choose a [bold][underline]valid option from the list[/][/]. Thank you");
                    AnsiConsole.Status()
                         .Start("Regenerating options...", ctx =>
                         {
                             ctx.Spinner(Spinner.Known.Aesthetic);
                             Thread.Sleep(3000);


                         });
                    MainMenu.HomeScreen();
                    break;
            }
        }


    }
}
