using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CardReaderDLL;

namespace CardReaderConsole
{
    using System.Data.Common;

    using SQLite;

    class Program
    {
        private static SQLiteConnection context;

        static void Main(string[] args)
        {
            context = new SQLiteConnection("userHistory.sqlite", SQLiteOpenFlags.ReadWrite);

            CardReader reader = new CardReader();

            reader.CardReaded += WriteCardNumber;
            
            reader.Start();

            Thread.Sleep(60000);

            reader.Stop();
        }

        static void WriteCardNumber(object sender, CardReader.CardReadedEventArgs e)
        {
            User user = new User() { CardNumber = e.CardNumber.Key };
            bool isThere = context.Table<User>().Contains<User>(user);

            if (isThere)
            {
                CardHistory cardHistory = new CardHistory(e.CardNumber);
                context.Insert(cardHistory);
            }
        }
    }
}
