using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Study
{
    internal class QuizHelper
    {
        internal static decimal ScoreGrader(int score, int cardCount)
        {
            decimal correct = Convert.ToDecimal(score);
            decimal total = Convert.ToDecimal(cardCount);

            return correct / total * 100;
            
        }

        internal static string TodaysDate()
        {
            return DateTime.Now.ToString("MM/dd/yyyy");

        }

        internal static void FinalScorePrintout(decimal finalScore)
        {
            int score = Convert.ToInt32(finalScore);
            

            if (score > 90) 
            {
                AnsiConsole.MarkupLine($"[green] Great Job! You scored a {score}%.[/]") ;
            }
            else if (score > 70)
            {
                AnsiConsole.MarkupLine($"[GreenYellow] Good job! You scored a {score}%.[/]") ;
            }
            else if (score > 70)
            {
                AnsiConsole.MarkupLine($"[yellow] Getting there! You scored a {score}%.[/]");
            }
            else if (score > 60)
            {
                AnsiConsole.MarkupLine($"[IndianRed] Keep trying! You scored a {score}%.[/]");
            }
            else if (score > 50)
            {
                AnsiConsole.MarkupLine($"[red] Just getting started! You scored a {score}%.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[maroon] You need more practice. You scored a {score}%.[/]");
            }
        }
    }
}
