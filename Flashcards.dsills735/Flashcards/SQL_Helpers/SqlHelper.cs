namespace Flashcards.SQL_Helpers;

    internal class SqlHelper
    {
        internal const string CreateStackTable = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Stacks')
                    BEGIN
                         CREATE TABLE Stacks (
                            StackID INT PRIMARY KEY IDENTITY(1,1),
                            Subject VARCHAR(255),
                            HighScore INT
                             );
                    END";

        internal const string CreateFlashcardTable = @"IF NOT EXISTS ( Select * FROM sys.tables WHERE name = 'Flashcards')
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

        internal const string CreateHistoryTable = @"IF NOT EXISTS (Select * FROM sys.tables WHERE name = 'History')
                        BEGIN
                               CREATE TABLE History (
                                    HistoryID INT PRIMARY KEY IDENTITY(1,1),
                                    Date VARCHAR(255),
                                    Score VARCHAR(255)
                                );
                        END
                                    ";

        internal const string ViewStacks = @"SELECT * FROM Stacks";

        internal const string ViewFlashcards = @"SELECT * FROM Flashcards
                        ORDER BY StackID";

        internal const string SearchStacks = @"SELECT COUNT(*) AS TotalCount
                        FROM Stacks     
                        WHERE Subject = @Subject";

        internal const string SearchStacksByID = @"SELECT COUNT(*) AS TotalCount
                        FROM Stacks     
                        WHERE StackID = @StackID";

        internal const string SearchFlashcardsByID = @"SELECT COUNT(*) AS TotalCount
                        FROM Flashcards     
                        WHERE FlashcardID = @FlashcardID";

        internal const string AddToStacks = @"INSERT INTO Stacks(Subject)
                        VALUES (@Subject)";

        internal const string AddToFlashcards = @"INSERT INTO Flashcards(Question, Answer, StackID)
                           VALUES(@Question, @Answer, @StackID)";

        internal const string SearchForSubjectID = @"SELECT COUNT(*) AS TotalCount
                    FROM Stacks
                   WHERE StackID = @StackID";

        internal const string DeleteStack = @"DELETE FROM Stacks WHERE StackID =  @StackID";

        internal const string DeleteFlashcard = @"DELETE FROM Flashcards WHERE FlashcardID = @FlashcardID";

        internal const string ReturnEntireStackWithStackID = @"Select * FROM Flashcards WHERE StackID = @StackID ORDER BY NEWID()";
    }


