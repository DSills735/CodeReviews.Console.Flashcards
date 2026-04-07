using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Flashcards.SQL_Helpers;
using Flashcards.Menus;


namespace Program;

public class Program
{
    internal static IConfiguration config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .Build();

    internal static string connectionString = ConnString();

    internal static string ConnString()
    {
        string? connectionString = Program.config.GetConnectionString("DefaultConnection");
        return connectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    static void Main(string[] args)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        var sql1 = SqlHelper.CreateStackTable;
        var sql2 = SqlHelper.CreateFlashcardTable;
        var sql3 = SqlHelper.CreateHistoryTable;


        connection.Execute(sql1);
        connection.Execute(sql2);
        connection.Execute(sql3);


        MainMenu.HomeScreen();
        
    }

}