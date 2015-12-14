namespace CardReaderDLL
{
    using System;

    using SQLite;

    public class DbGateway
    {
        private SQLiteConnection sqLiteConnection;

        public void CreateDataBaseAndTables(string path)
        {
            System.Data.SQLite.SQLiteConnection.CreateFile("userHistory.sqlite");

            sqLiteConnection = new SQLiteConnection("userHistory.sqlite", SQLiteOpenFlags.ReadWrite);

            sqLiteConnection.CreateTable<User>();
            sqLiteConnection.CreateTable<CardHistory>();

            sqLiteConnection.Close();
        }

    }
}
