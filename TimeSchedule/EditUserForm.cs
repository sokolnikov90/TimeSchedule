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

    public partial class EditUserForm : Form
    {
        public EventWaitHandle ewhCardReaded = new EventWaitHandle(false, EventResetMode.AutoReset);

        public User User { get; set; }

        private CardReader reader;

        private User user;

        private SQLiteConnection context;

        public EditUserForm(SQLiteConnection context, User user)
        {
            InitializeComponent();

            this.context = context;

            this.user = user;

            this.tbFIO.Text = user.FIO;
            this.tbCardNumber.Text = user.CardNumber;

            reader = new CardReader();

            reader.CardReaded += WriteCardNumber;

            reader.Start();
        }

        private void btnBindCard_Click(object sender, EventArgs e)
        {
            var fio = tbFIO.Text.Trim();
            var cardNumber = tbCardNumber.Text;

            if (fio == string.Empty)
            {
                MessageBox.Show("Необходимо ввести ФИО пользователя.");
                return;
            }

            if (cardNumber == string.Empty)
            {
                MessageBox.Show("Необходимо приложить карту к ридеру.");
                return;
            }

            if (context.Table<User>().Any(u => (u.Id != user.Id) && (u.CardNumber == cardNumber)))
            {
                string userFIO = context.Table<User>().First(u => u.CardNumber == cardNumber).FIO;
                MessageBox.Show("Данная карта уже привязана к пользователю: " + userFIO);
                return;
            }

            user.FIO = fio;
            user.CardNumber = cardNumber;

            User dbUser = context.Table<User>().First(u => u.Id == user.Id);
            
            context.RunInTransaction(() =>
                {
                    var cardHistory = context.Table<CardHistory>().Where(u => u.CardNumber == dbUser.CardNumber).ToList();
                    cardHistory.ForEach(c => c.CardNumber = cardNumber);
                    context.UpdateAll(cardHistory);
                    context.Update(user);
                });

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
