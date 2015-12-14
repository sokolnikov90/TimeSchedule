namespace CardReaderDLL
{
    using System;
    using System.ComponentModel;

    using SQLite;

    public class User
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id
        {
            get { return this.id; }

            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        [MaxLength(50), NotNull]
        public string FIO
        {
            get { return this.fio; }

            set
            {
                if (value != this.fio)
                {
                    this.fio = value;
                    NotifyPropertyChanged("FIO");
                }
            }
        }

        [MaxLength(50), NotNull]
        public string CardNumber
        {
            get { return this.cardNumber; }

            set
            {
                if (value != this.cardNumber)
                {
                    this.cardNumber = value;
                    NotifyPropertyChanged("CardNumber");
                }
            }
        }

        public User(string fio, string cardNumber)
        {
            FIO = fio;
            CardNumber = cardNumber;
        }

        public User()
        {

        }

        public override bool Equals(System.Object obj)
        {
            User user = obj as User;

            return Equals(user);
        }

        public bool Equals(User user)
        {
            // If parameter is null return false:
            if (user == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (CardNumber == user.CardNumber);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private int id;
        private string fio = string.Empty;
        private string cardNumber = string.Empty;
    }
}
