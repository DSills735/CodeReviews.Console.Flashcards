namespace Flashcards.SQL_Helpers
{
    internal class SqlHelper
    {
        
        internal static string CreateStackTable()
        {
            return @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Stacks')
                    BEGIN
                         CREATE TABLE Stacks (
                            StackID INT PRIMARY KEY IDENTITY(1,1),
                            Subject VARCHAR(255),
                            HighScore INT
                             );
                    END";

        }
        internal static string CreateFlashcardTable()
        {
            return @"IF NOT EXISTS ( Select * FROM sys.tables WHERE name = 'Flashcards')
                    BEGIN

                        CREATE TABLE Flashcards (
                            FlashcardID INT PRIMARY KEY IDENTITY(1,1),
                            Question VARCHAR(255),
                            Answer VARCHAR (255),
                            StackID INT,
                            FOREIGN KEY (StackID) REFERENCES Stacks(StackID)
                            ON DELETE CASCADE   
                            );
                    END";
        }
        internal static string CreateHistoryTable()
        {
            return @"IF NOT EXISTS (Select * FROM sys.tables WHERE name = 'History')
                        BEGIN
                               CREATE TABLE History (
                                    HistoryID INT PRIMARY KEY IDENTITY(1,1),
                                    Date VARCHAR(255),
                                    Score VARCHAR(255)
                                );
                        END
                                    ";
        }
        internal static string ViewStacks(){
                        return @"SELECT * FROM Stacks";
        }
        internal static string ViewFlashcards()
        {
            return @"SELECT * FROM Flashcards
                        ORDER BY StackID";
        }

        internal static string SearchStacks()
        {
            return @"SELECT COUNT(*) AS TotalCount
                        FROM Stacks     
                        WHERE Subject = @Subject";              
        }

        internal static string SearchStacksByID()
        {
            return @"SELECT COUNT(*) AS TotalCount
                        FROM Stacks     
                        WHERE StackID = @StackID";
        }

        internal static string SearchFlashcardsByID()
        {
            return @"SELECT COUNT(*) AS TotalCount
                        FROM Flashcards     
                        WHERE FlashcardID = @FlashcardID";
        }

        internal static string AddToStacks()
        {
            return @"INSERT INTO Stacks(Subject)
                        VALUES (@Subject)";
        }

        internal static string AddToFlashcards()
        {
            return @"INSERT INTO Flashcards(Question, Answer, StackID)
                           VALUES(@Question, @Answer, @StackID)";
        }

        internal static string SearchForSubjectID()
        {
            return @"SELECT COUNT(*) AS TotalCount
                    FROM Stacks
                   WHERE StackID = @StackID";
        }

        internal static string DeleteStack()
        {
            return @"DELETE FROM Stacks WHERE StackID =  @StackID";
        }

        internal static string DeleteFlashcard()
        {
            return @"DELETE FROM Flashcards WHERE FlashcardID = @FlashcardID";
        }
        internal static string ReturnEntireStackWithStackID()
        {
            return @"Select * FROM Flashcards WHERE StackID = @StackID ORDER BY NEWID()";
        }
    }
}
