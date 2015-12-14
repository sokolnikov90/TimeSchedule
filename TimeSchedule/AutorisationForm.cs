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

    public partial class AutorisationForm : Form
    {
        public AutorisationForm()
        {
            InitializeComponent();
        }

        private void btnBindCard_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == "lanit" || tbPassword.Text == "дфтше")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBindCard_Click(sender, e);
            }
        }
    }
}
