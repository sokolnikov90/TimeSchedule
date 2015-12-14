namespace TimeSchedule
{
    partial class TimeSchedule
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.tpReports = new System.Windows.Forms.TabPage();
            this.btnBuild = new System.Windows.Forms.Button();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(576, 372);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddUser.Location = new System.Drawing.Point(3, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(134, 31);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Controls.Add(this.tpReports);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 410);
            this.tabControl1.TabIndex = 2;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.tableLayoutPanel1);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(734, 384);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Сотрудники";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 378F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 378);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnDeleteUser, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnEditUser, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAddUser, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(585, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(140, 372);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteUser.Location = new System.Drawing.Point(3, 77);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(134, 31);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Удалить";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.AutoSize = true;
            this.btnEditUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditUser.Location = new System.Drawing.Point(3, 40);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(134, 31);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "Изменить";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // tpReports
            // 
            this.tpReports.Controls.Add(this.btnBuild);
            this.tpReports.Controls.Add(this.lbTo);
            this.tpReports.Controls.Add(this.lbFrom);
            this.tpReports.Controls.Add(this.label1);
            this.tpReports.Controls.Add(this.dtpTo);
            this.tpReports.Controls.Add(this.dtpFrom);
            this.tpReports.Location = new System.Drawing.Point(4, 22);
            this.tpReports.Name = "tpReports";
            this.tpReports.Padding = new System.Windows.Forms.Padding(3);
            this.tpReports.Size = new System.Drawing.Size(734, 384);
            this.tpReports.TabIndex = 1;
            this.tpReports.Text = "Отчеты";
            this.tpReports.UseVisualStyleBackColor = true;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(6, 85);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(138, 39);
            this.btnBuild.TabIndex = 2;
            this.btnBuild.Text = "Построить";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(233, 66);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(19, 13);
            this.lbTo.TabIndex = 1;
            this.lbTo.Text = "по";
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(8, 66);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(13, 13);
            this.lbFrom.TabIndex = 1;
            this.lbFrom.Text = "с";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Построить отчет по присутствию сотрудников";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(258, 60);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.RightToLeftLayout = true;
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(27, 59);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // TimeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 410);
            this.Controls.Add(this.tabControl1);
            this.Name = "TimeSchedule";
            this.Text = "TimeSchedule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpReports.ResumeLayout(false);
            this.tpReports.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.TabPage tpReports;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}

