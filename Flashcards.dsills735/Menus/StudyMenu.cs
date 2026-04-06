using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Menus
{
    internal class StudyMenu
    {

        internal static void StudyHome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the study area. Please choose an option from below.");
            Console.WriteLine();
            Console.WriteLine("1. Quiz yourself on a subject");
            Console.WriteLine("2. Modify an existing stack or flashcard.");
            Console.WriteLine("3. View the all of the cards in a subject");
            Console.WriteLine("4. Return to main menu. ");

            string temp = Console.ReadLine()!.Trim();

            switch (temp)
            {
                case "1":
                    Study.Quiz.SingleSubjectQuiz();
                    break;

                case "2":
                    DeleteMenu.DeleteMenus();
                    break;

                case "3":
                    Study.ViewCardsHelper.GetStackID();
                    break;

                case "4":
                    MainMenu.HomeScreen();
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
