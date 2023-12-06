using System.Data.SQLite;

namespace CodeTimeTracker
{
    internal class Program
    {
        public static string connectionString = @"Data Source=..\..\..\Files\Library.db;Version=3;";
        static void Main()
        {
            CreateDatabase();
            GetUserInput();
        }

        static void CreateDatabase()
        {
            if (!File.Exists(@"..\..\..\Files\Library.db"))
            {
                SQLiteConnection.CreateFile(@"..\..\..\Files\Library.db");


                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand tableCmd = connection.CreateCommand();

                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS drinking_water (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                    )";

                    tableCmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}