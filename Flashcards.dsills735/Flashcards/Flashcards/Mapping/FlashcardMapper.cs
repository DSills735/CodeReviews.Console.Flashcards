namespace Flashcards.Mapping;

public static class FlashcardMapper
{
    public static DTO.FlashcardDTO ToDto(this Entities.Flashcard flashcard, int displayId)
    {
        return new DTO.FlashcardDTO(displayId, flashcard.FlashcardID, flashcard.Question, flashcard.Answer);
    }
}