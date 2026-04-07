using Spectre.Console;
namespace Flashcards.Menus;

internal class DeleteMenu
{
    internal static void DeleteMenus()
    {
        Console.Clear();

        AnsiConsole.MarkupLine("Welcome to the delete menu. What do you want to delete?");
        Console.WriteLine();
        AnsiConsole.MarkupLine("[maroon][rapidblink]WARNING!![/][/] Deleting a subject will delete all flashcards within the subject");
        Console.WriteLine();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(
                    "[green]Individual Flashcard[/]",
                    "[red]An entire subject[/]",
                    "Go to the study section",
                    "Return to the main menu"
                )
        );

        switch (choice)
        {
            case "[green]Individual Flashcard[/]":
                Card_Ops.DeleteFlashcard.DeleteSingleFlashcard();
                break;

            case "[red]An entire subject[/]":
                Stack_Ops.DeleteStacks.DeleteStack();
                break;

            case "Go to the study section":
                StudyMenu.StudyHome();
                break;

            case "Return to the main menu":
                MainMenu.HomeScreen();
                break;
        }
    }
}
