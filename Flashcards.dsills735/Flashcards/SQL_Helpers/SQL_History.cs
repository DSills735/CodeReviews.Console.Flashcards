
namespace Flashcards.SQL_Helpers;

internal class SQL_History
{
    internal const string AddToHistory = @"INSERT INTO History(Date, Score)
                   VALUES(@Date, @Score)";

    internal const string ViewHistory = "SELECT * FROM History";

}
