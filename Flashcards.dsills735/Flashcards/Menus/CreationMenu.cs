using Spectre.Console;
using System.Threading;

namespace Flashcards.Menus;

 
public class CreationMenu
{
    public static void StackCreationMenu()
    {
        Console.Clear();

        AnsiConsole.MarkupLine("[slowblink][purple]Welcome to the Creator menu.[/][/]");
        Console.WriteLine();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(
                    "[green]Add a new flashcard to an existing subject[/]",
                    "[yellow]Create a new subject[/]",
                    "[blue]View existing subjects[/]",
                    "[maroon]Return to the main menu[/]"
                )
        );

        switch (choice)
        {
            case "[green]Add a new flashcard to an existing subject[/]":
                Card_Ops.FlashcardCreation.CardCreator();
                break;

            case "[yellow]Create a new subject[/]":
                Stack_Ops.StackCreation.CreateStack();
                break;

            case "[blue]View existing subjects[/]":
                Database_Helpers.ViewStacks.DisplayStacks();
                break;

            case "[maroon]Return to the main menu[/]":
                MainMenu.HomeScreen();
                break;
        }
    }

}
