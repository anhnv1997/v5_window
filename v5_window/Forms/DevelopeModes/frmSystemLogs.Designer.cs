namespace iParkingv5_window.Forms.DevelopeModes
{
    partial class frmSystemLogs
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
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            dgvData = new DataGridView();
            panel2 = new Panel();
            txtCmd = new TextBox();
            btnSearch = new Button();
            panel1 = new Panel();
            btnCancel = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1024, 539);
            tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvData);
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1016, 505);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "LogCMD";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = SystemColors.ButtonHighlight;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(3, 103);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersVisible = false;
            dgvData.RowTemplate.Height = 25;
            dgvData.Size = new Size(1010, 399);
            dgvData.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtCmd);
            panel2.Controls.Add(btnSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1010, 100);
            panel2.TabIndex = 4;
            // 
            // txtCmd
            // 
            txtCmd.BackColor = SystemColors.InactiveCaption;
            txtCmd.Dock = DockStyle.Fill;
            txtCmd.Location = new Point(0, 0);
            txtCmd.Multiline = true;
            txtCmd.Name = "txtCmd";
            txtCmd.Size = new Size(910, 100);
            txtCmd.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Dock = DockStyle.Right;
            btnSearch.Location = new Point(910, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 100);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 539);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4);
            panel1.Size = new Size(1024, 61);
            panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Location = new Point(870, 4);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 53);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Đóng";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmSystemLogs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1024, 600);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "frmSystemLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kiểm tra log hệ thống";
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Panel panel1;
        private Button btnCancel;
        private DataGridView dgvData;
        private TextBox txtCmd;
        private Button btnSearch;
        private Panel panel2;
    }
}