
namespace Flashcards.SQL_Helpers
{
    internal class SQL_History
    {
        internal static string AddToHistory()
        {
            return @"INSERT INTO History(Date, Score)
                           VALUES(@Date, @Score)";
        }
        internal static string ViewHistory()
        {
            return "SELECT * FROM History";
        }

    }
}
