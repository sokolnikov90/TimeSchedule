namespace CardReaderDLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using GS.Apdu;
    using GS.PCSC;
    using GS.SCard;
    using GS.Util.Hex;

    public class CardReader
    {
        public delegate void CardReadedEventHandler(object sender, CardReadedEventArgs e);

        public event CardReadedEventHandler CardReaded;

        public class CardReadedEventArgs : EventArgs
        {
            private readonly KeyValuePair<string, DateTime> lastCard;

            public CardReadedEventArgs(KeyValuePair<string, DateTime> lastCard)
            {
                this.lastCard = lastCard;
            }

            public KeyValuePair<string, DateTime> CardNumber
            {
                get { return this.lastCard; }
            }
        }

        private readonly EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);

        private Thread readThread;

        private PCSCReader reader;

        private KeyValuePair<string, DateTime> lastCard = new KeyValuePair<string, DateTime>(string.Empty, DateTime.Now);

        private static readonly TimeSpan cardLockTime = new TimeSpan(0,0,1);

        public void Start()
        {
            this.readThread = new Thread(() =>
                {
                    do
                    {
                        this.reader = new PCSCReader();

                        this.reader.Connect();
                        this.reader.ActivateCard();

//                        string readerName = this.reader.ReaderNames.First(name => name.Contains("PICC"));
//
//                        this.reader.WaitForCardPresent(readerName);
//                        this.reader.Connect(readerName);
                        RespApdu respApdu = reader.Exchange("FF CA 00 00 00");

                        var cardString = string.Empty;

                        if (respApdu.SW1SW2 == 0x9000)
                        {
                            cardString = HexFormatting.ToHexString(respApdu.Data);
                        }

                        if (!string.IsNullOrEmpty(cardString) &&
                                ((lastCard.Key != cardString) ||
                                ((lastCard.Key == cardString) && (DateTime.Now - lastCard.Value > cardLockTime))))
                        {
                            lastCard = new KeyValuePair<string, DateTime>(cardString, DateTime.Now);
                            var cardEvArg = new CardReadedEventArgs(lastCard);
                            OnCardReaded(cardEvArg);
                        }

                        this.reader.Disconnect();

                    } while (!ewh.WaitOne(0));
                });
            this.readThread.Start();
        }

        public void Stop()
        {
            ewh.Set();
            this.reader.Disconnect();
            this.readThread.Join();
        }

        protected virtual void OnCardReaded(CardReadedEventArgs cardEventargs)
        {
            var handler = this.CardReaded;
            if (handler != null)
            {
                handler(this, cardEventargs);
            }
        }
    }
}
