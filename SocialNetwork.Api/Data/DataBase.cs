using System.Data.SQLite;
using Dapper;

namespace SocialNetwork.Api.Data
{
    public static class DataBase
    {
        public static void Create()
        {
            var sqLiteConnection = new SQLiteConnection("Data Source=./SocialNetwork.db");
            sqLiteConnection.Execute(@"Create Table if not exists Messages(
                Author VARCHAR(100) NOT NULL,
                Post VARCHAR(144) NOT NULL,
                Timestamp DATETIME NOT NULL)");

            sqLiteConnection.Execute(@"Create Table if not exists Subscriptions(
                User VARCHAR(100) NOT NULL,
                Subscriber VARCHAR(100) NOT NULL)");

            sqLiteConnection.Close();
            sqLiteConnection.Dispose();
        }
    }
}