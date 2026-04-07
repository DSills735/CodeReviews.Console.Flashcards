using Microsoft.Extensions.Configuration;


namespace Flashcards.Database_Helpers;

internal class ConnectionString
{

    internal static string ConnString()
    {
                   string? connectionString = Program.Program.config.GetConnectionString("DefaultConnection");
        return connectionString;

    }
}
