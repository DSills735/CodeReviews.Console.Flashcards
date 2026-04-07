namespace Flashcards.Entities;

public class Flashcard
{
    public int FlashcardID { get; set; }
    public required string Question { get; set; }
    public required string Answer { get; set; }
    public int StackID { get; set; }
}
