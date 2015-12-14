namespace TimeSchedule
{
    partial class EditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.lbFIO = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbCardNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAddUser = new System.Windows.Forms.GroupBox();
            this.gbAddUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(15, 41);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(248, 20);
            this.tbFIO.TabIndex = 0;
            this.tbFIO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFIO_KeyDown);
            // 
            // lbFIO
            // 
            this.lbFIO.AutoSize = true;
            this.lbFIO.Location = new System.Drawing.Point(15, 25);
            this.lbFIO.Name = "lbFIO";
            this.lbFIO.Size = new System.Drawing.Size(34, 13);
            this.lbFIO.TabIndex = 1;
            this.lbFIO.Text = "ФИО";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(15, 122);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(118, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Сохранить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnBindCard_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(139, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbCardNumber
            // 
            this.tbCardNumber.Location = new System.Drawing.Point(15, 87);
            this.tbCardNumber.Name = "tbCardNumber";
            this.tbCardNumber.ReadOnly = true;
            this.tbCardNumber.Size = new System.Drawing.Size(248, 20);
            this.tbCardNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер карты";
            // 
            // gbAddUser
            // 
            this.gbAddUser.Controls.Add(this.btnAddUser);
            this.gbAddUser.Controls.Add(this.btnCancel);
            this.gbAddUser.Controls.Add(this.tbFIO);
            this.gbAddUser.Controls.Add(this.tbCardNumber);
            this.gbAddUser.Controls.Add(this.label1);
            this.gbAddUser.Controls.Add(this.lbFIO);
            this.gbAddUser.Location = new System.Drawing.Point(12, 12);
            this.gbAddUser.Name = "gbAddUser";
            this.gbAddUser.Size = new System.Drawing.Size(278, 154);
            this.gbAddUser.TabIndex = 3;
            this.gbAddUser.TabStop = false;
            this.gbAddUser.Text = "Отредактируйте ФИО и приложите карту к ридеру";
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 178);
            this.Controls.Add(this.gbAddUser);
            this.Name = "EditUserForm";
            this.Text = "Редактирование сотрудника";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUserForm_FormClosing);
            this.gbAddUser.ResumeLayout(false);
            this.gbAddUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label lbFIO;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbCardNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAddUser;
    }
}