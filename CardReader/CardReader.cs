using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace CardReader
{
    using CardReaderDLL;

    using SQLite;

    public partial class CardReader : ServiceBase
    {
        private SQLiteConnection context;

        private CardReaderDLL.CardReader reader;

        public CardReader()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            context = new SQLiteConnection(@"C:\Program Files\LANIT\TimeSchedule\userHistory.sqlite", SQLiteOpenFlags.ReadWrite);

            reader = new CardReaderDLL.CardReader();

            reader.CardReaded += WriteCardNumber;

            reader.Start();
        }

        protected override void OnStop()
        {
            if (reader != null)
                reader.Stop();

            if (context != null)
                context.Close();
        }

        void WriteCardNumber(object sender, CardReaderDLL.CardReader.CardReadedEventArgs e)
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
