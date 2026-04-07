using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Menus;

internal class StudyMenu
{
    internal static void StudyHome()
    {
        while (true)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Welcome to the study area. Please choose an option:")
                    .AddChoices(
                        "Quiz yourself on a subject",
                        "Modify an existing stack or flashcard",
                        "View all cards in a subject",
                        "Return to main menu"
                    ));

            switch (choice)
            {
                case "Quiz yourself on a subject":
                    Study.Quiz.SingleSubjectQuiz();
                    break;

                case "Modify an existing stack or flashcard":
                    DeleteMenu.DeleteMenus();
                    break;

                case "View all cards in a subject":
                    Study.ViewCardsHelper.GetStackID();
                    break;

                case "Return to main menu":
                    MainMenu.HomeScreen();
                    return;
            }
        }
    }
}