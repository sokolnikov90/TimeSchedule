namespace CardReaderDLL
{
    using System;
    using System.Collections.Generic;

    using SQLite;

    public class CardHistory
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [MaxLength(50), NotNull]
        public string CardNumber { get; set; }

        [MaxLength(19), NotNull]
        public string DateTime { get; set; }

        public CardHistory(KeyValuePair<string, DateTime> cardData)
        {
            CardNumber = cardData.Key;
            DateTime = cardData.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public CardHistory()
        {
            
        }
    }
}
