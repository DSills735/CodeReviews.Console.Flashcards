using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Flashcards.SQL_Helpers;
using Flashcards.Menus;


namespace Program
{
    public class Program
    {
        internal static IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

        static string? connectionString = config.GetConnectionString("DefaultConnection");

        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            var sql1 = SqlHelper.CreateStackTable();
            var sql2 = SqlHelper.CreateFlashcardTable();
            var sql3 = SqlHelper.CreateHistoryTable();


            connection.Execute(sql1);
            connection.Execute(sql2);
            connection.Execute(sql3);


            MainMenu.HomeScreen();
            
        }

    }
}