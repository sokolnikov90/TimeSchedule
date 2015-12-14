using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeSchedule
{
    using System.Threading;

    using CardReaderDLL;

    using SQLite;

    public partial class AddUserForm : Form
    {
        public EventWaitHandle ewhCardReaded = new EventWaitHandle(false, EventResetMode.AutoReset);

        public User User { get; set; }

        private CardReader reader;

        private SQLiteConnection context;

        public AddUserForm(SQLiteConnection context)
        {
            InitializeComponent();

            this.context = context;

            reader = new CardReader();

            reader.CardReaded += WriteCardNumber;

            reader.Start();
        }

        private void btnBindCard_Click(object sender, EventArgs e)
        {
            var fio = tbFIO.Text.Trim();
            var cardNumber = tbCardNumber.Text;

            if (String.IsNullOrEmpty(fio))
            {
                MessageBox.Show("Необходимо ввести ФИО пользователя.");
                return;
            }

            if (String.IsNullOrEmpty(cardNumber))
            {
                MessageBox.Show("Необходимо приложить карту к ридеру.");
                return;
            }

            if (context.Table<User>().Any(u => u.CardNumber == cardNumber))
            {
                string userFIO = context.Table<User>().First(u => u.CardNumber == cardNumber).FIO;
                MessageBox.Show("Данная карта уже привязана к пользователю: " + userFIO);
                return;
            }

            User = new User(fio, cardNumber);

            User.Id = context.Insert(User);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void WriteCardNumber(object sender, CardReader.CardReadedEventArgs e)
        {
            this.Invoke(new Action<string>(this.ChangeCardNumberText), new object[] { e.CardNumber.Key });

            ewhCardReaded.Set();
        }

        private void ChangeCardNumberText(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(this.ChangeCardNumberText), new object[] { value });
                return;
            }
            tbCardNumber.Text = value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            reader.Stop();
        }

        private void tbFIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBindCard_Click(sender, e);
            }
        }
    }
}
