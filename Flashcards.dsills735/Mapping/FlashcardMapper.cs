
namespace Flashcards.Mapping
{
    public static class FlashcardMapper
    {
        public static DTO.FlashcardDTO ToDto(this Entities.Flashcard flashcard)
        {
            return new DTO.FlashcardDTO(flashcard.Question, flashcard.Answer);

     
        }
    }
}
