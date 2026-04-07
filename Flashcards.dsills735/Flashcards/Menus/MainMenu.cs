using Spectre.Console;

namespace Flashcards.Menus;

internal class MainMenu
{

    internal static void HomeScreen()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[slowblink][blue]Welcome to the Flashcards app![/][/]");
        Console.WriteLine();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What would you like to do?")
                .AddChoices(
                    "Add a new subject, or a new flashcard to an existing stack",
                    "Study",
                    "Delete specific cards, or an entire subject",
                    "View History",
                    "[maroon]Exit Application[/]"
                )
        );

        switch (choice)
        {
            case "Add a new subject, or a new flashcard to an existing stack":
                CreationMenu.StackCreationMenu();
                break;

            case "Study":
                StudyMenu.StudyHome();
                break;

            case "Delete specific cards, or an entire subject":
                DeleteMenu.DeleteMenus();
                break;

            case "View History":
                Study.ViewHistory.PrintHistoryTable();
                break;

            case "[maroon]Exit Application[/]":
                Environment.Exit(0);
                break;
        }
    }

}
