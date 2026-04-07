using Spectre.Console;


namespace Flashcards.Validation;

internal class FlashcardValidationHelper
{

    internal static bool FlashcardInputValidation(string text)
    {

        AnsiConsole.MarkupLine($"You wrote [bold][underline]{text}[/][/]. Is that correct? Y or N");

            string resp = Console.ReadLine().Trim().ToLower();
            bool intended = ResponseValidation.YesOrNoValidation( resp );

        if (intended)
        {
            return true;
        }
        else
        {
            return false;
        }
        
        
    }
}
