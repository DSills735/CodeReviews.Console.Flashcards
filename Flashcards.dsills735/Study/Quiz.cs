using Microsoft.Data.SqlClient;
using Spectre.Console;
using Dapper;
using Flashcards.Mapping;

namespace Flashcards.Study
{
    internal class Quiz
    {
        static string? connectionString = Database_Helpers.ConnectionString.ConnString();
        internal static void SingleSubjectQuiz()
        {
            Console.Clear();
            using SqlConnection connection = new SqlConnection(connectionString);

            Console.WriteLine("What subject would you like quizzed on?");

            Database_Helpers.ViewStacks.DisplayStacksForUpdate();

            string resp = Console.ReadLine()!;

            bool exists = false;

            

            while (!exists)
            {
                int count = connection.ExecuteScalar<int>(SQL_Helpers.SqlHelper.SearchStacksByID(), new { StackID = resp });

                if (count == 0)
                {

                    AnsiConsole.MarkupLine(@"[rapidblink][maroon]ERROR!![/][/][red] This stack was not found.[/] Please ensure the ID you are entering is reflected on the table above.");
                    resp = Console.ReadLine()!;
                }
                else
                {
                    exists = true;
                }

                var subject = connection.Query<Flashcards.Entities.Flashcard>(SQL_Helpers.SqlHelper.ReturnEntireStackWithStackID(), new { StackID = resp });

                int qNum = 1;
                int score = 0;
                bool correct = false;
                int cardCounter = 0; 

                foreach (var stack in subject)
                {

                    var dto = stack.ToDto();
                    Console.Clear();
                    Console.WriteLine($"Question {qNum}: {dto.Question}");
                    Console.WriteLine();
                    Console.WriteLine("When you are ready to see the answer, press any key.");
                    Console.ReadKey();
                    Console.WriteLine(dto.Answer);
                    Console.WriteLine();
                    Console.WriteLine("Did you get the answer right? Y/N");

                    string txt = Console.ReadLine()!;

                    correct = Validation.ResponseValidation.YesOrNoValidation(txt);

                    if (correct)
                    {
                        score++;
                    }
                    cardCounter++;
                    qNum++;
                    correct = false;
                }

                Console.Clear();
                Console.WriteLine("You are finished with the stack.");

                decimal finalScore = QuizHelper.ScoreGrader(score, cardCounter);
                QuizHelper.FinalScorePrintout(finalScore);
                Console.WriteLine();
                Console.WriteLine("");

                string today = QuizHelper.TodaysDate();



                AnsiConsole.Status()
                         .Start("Writing your score to database and returning you to the study menu...", ctx =>
                         {
                             connection.Execute(SQL_Helpers.SQL_History.AddToHistory(), new { Date = today, Score = finalScore });
                             ctx.Spinner(Spinner.Known.Aesthetic);
                             Thread.Sleep(3000);
                         });

                Menus.StudyMenu.StudyHome();
            }
        }
    }
}
