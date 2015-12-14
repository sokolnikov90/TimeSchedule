namespace TimeSchedule
{
    partial class AutorisationForm
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
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbFIO = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbAddUser = new System.Windows.Forms.GroupBox();
            this.gbAddUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(6, 52);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(248, 20);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // lbFIO
            // 
            this.lbFIO.AutoSize = true;
            this.lbFIO.Location = new System.Drawing.Point(6, 36);
            this.lbFIO.Name = "lbFIO";
            this.lbFIO.Size = new System.Drawing.Size(45, 13);
            this.lbFIO.TabIndex = 1;
            this.lbFIO.Text = "Пароль";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(6, 87);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(118, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Войти";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnBindCard_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbAddUser
            // 
            this.gbAddUser.Controls.Add(this.btnAddUser);
            this.gbAddUser.Controls.Add(this.btnCancel);
            this.gbAddUser.Controls.Add(this.tbPassword);
            this.gbAddUser.Controls.Add(this.lbFIO);
            this.gbAddUser.Location = new System.Drawing.Point(12, 12);
            this.gbAddUser.Name = "gbAddUser";
            this.gbAddUser.Size = new System.Drawing.Size(278, 154);
            this.gbAddUser.TabIndex = 3;
            this.gbAddUser.TabStop = false;
            this.gbAddUser.Text = "Введите пароль";
            // 
            // AutorisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 178);
            this.Controls.Add(this.gbAddUser);
            this.Name = "AutorisationForm";
            this.Text = "Авторизация";
            this.gbAddUser.ResumeLayout(false);
            this.gbAddUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbFIO;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbAddUser;
    }
}