
namespace Flashcards.Validation
{
    internal class ResponseValidation
    {

        internal static bool YesOrNoValidation(string txt)
        {
            if (txt == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
