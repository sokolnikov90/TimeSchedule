using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardReaderDLL;

namespace TimeSchedule
{
    using SQLite;

    public partial class TimeSchedule : Form
    {
        private SQLiteConnection context;

        private BindingList<User> bindingUserList; 

        public TimeSchedule()
        {
            InitializeComponent();

            context = new SQLiteConnection(@"C:\Program Files\LANIT\TimeSchedule\userHistory.sqlite", SQLiteOpenFlags.ReadWrite);

            var userList = context.Query<User>("SELECT * FROM USER");

            bindingUserList = new BindingList<User>(userList);
            var source = new BindingSource(bindingUserList, null);
            dataGridView1.DataSource = source;

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var form = new AddUserForm(context))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bindingUserList.Add(form.User);
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();

            new EditUserForm(context, selectedUser).ShowDialog();

            dataGridView1.Refresh();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();

            var result = MessageBox.Show("Вы уверены, что хотите удалить сотрудника: " + selectedUser.FIO, "Удаление пользователя", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                context.RunInTransaction(() =>
                    {
                        context.Execute(String.Format("DELETE FROM CARDHISTORY WHERE CARDNUMBER = '{0}'", selectedUser.CardNumber));
                        context.Delete<User>(selectedUser.Id);
                    });
                bindingUserList.Remove(selectedUser);
            }
        }

        private User GetSelectedUser()
        {
            int userId = -1;

            try
            {
                userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch
            {

            }

            var user = bindingUserList.First(u => u.Id == userId);

            return user;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date.AddDays(1);

            if (from > to)
            {
                MessageBox.Show("Начальная дата отчета не может опережать конечную дату.");
                return;
            }

            try
            {
                UserHistoryReport userHistoryReport = new UserHistoryReport(context, from, to);

                userHistoryReport.MakeAnExcel();

                MessageBox.Show("Отчет успешно построен");
            }
            catch(Exception exp)
            {
                MessageBox.Show("Ошибка построения отчета." + Environment.NewLine + exp);
            }
        }
    }
}
