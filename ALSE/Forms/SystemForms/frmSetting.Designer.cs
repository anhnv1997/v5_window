namespace ALSE
{
    partial class frmSetting
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            tabControl1 = new TabControl();
            tabController = new TabPage();
            dgvController = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            tsbAddController = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            tsbEditController = new ToolStripButton();
            tsbDeleteController = new ToolStripButton();
            tsbRefreshController = new ToolStripButton();
            tabControl1.SuspendLayout();
            tabController.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvController).BeginInit();
            tsbAddController.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabController);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabController
            // 
            tabController.Controls.Add(dgvController);
            tabController.Controls.Add(tsbAddController);
            tabController.Location = new Point(4, 29);
            tabController.Name = "tabController";
            tabController.Padding = new Padding(3);
            tabController.Size = new Size(792, 417);
            tabController.TabIndex = 1;
            tabController.Text = "Bộ điều khiển";
            tabController.UseVisualStyleBackColor = true;
            // 
            // dgvController
            // 
            dgvController.AllowUserToAddRows = false;
            dgvController.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvController.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvController.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvController.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvController.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvController.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvController.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvController.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvController.DefaultCellStyle = dataGridViewCellStyle3;
            dgvController.Dock = DockStyle.Fill;
            dgvController.Location = new Point(3, 30);
            dgvController.Name = "dgvController";
            dgvController.ReadOnly = true;
            dgvController.RowHeadersVisible = false;
            dgvController.RowTemplate.Height = 29;
            dgvController.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvController.Size = new Size(786, 384);
            dgvController.TabIndex = 2;
            dgvController.CellDoubleClick += dgvController_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn1.Width = 56;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "STT";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 66;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Tên";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Mã";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 62;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Mô tả";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 81;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Loại";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 69;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "IP";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 54;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Port";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 70;
            // 
            // tsbAddController
            // 
            tsbAddController.Items.AddRange(new ToolStripItem[] { toolStripButton1, tsbEditController, tsbDeleteController, tsbRefreshController });
            tsbAddController.Location = new Point(3, 3);
            tsbAddController.Name = "tsbAddController";
            tsbAddController.Size = new Size(786, 27);
            tsbAddController.TabIndex = 1;
            tsbAddController.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.add;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(66, 24);
            toolStripButton1.Tag = "CONTROLLER";
            toolStripButton1.Text = "Thêm";
            toolStripButton1.Click += tsbAdd_Click;
            // 
            // tsbEditController
            // 
            tsbEditController.Image = Properties.Resources.edit;
            tsbEditController.ImageTransparentColor = Color.Magenta;
            tsbEditController.Name = "tsbEditController";
            tsbEditController.Size = new Size(54, 24);
            tsbEditController.Tag = "CONTROLLER";
            tsbEditController.Text = "Sửa";
            tsbEditController.Click += tsbEdit_Click;
            // 
            // tsbDeleteController
            // 
            tsbDeleteController.Image = Properties.Resources.delete;
            tsbDeleteController.ImageTransparentColor = Color.Magenta;
            tsbDeleteController.Name = "tsbDeleteController";
            tsbDeleteController.Size = new Size(55, 24);
            tsbDeleteController.Tag = "CONTROLLER";
            tsbDeleteController.Text = "Xóa";
            tsbDeleteController.Click += tsbDelete_Click;
            // 
            // tsbRefreshController
            // 
            tsbRefreshController.Image = Properties.Resources.refresh;
            tsbRefreshController.ImageTransparentColor = Color.Magenta;
            tsbRefreshController.Name = "tsbRefreshController";
            tsbRefreshController.Size = new Size(87, 24);
            tsbRefreshController.Tag = "CONTROLLER";
            tsbRefreshController.Text = "Làm mới";
            tsbRefreshController.Click += tsbRefresh_Click;
            // 
            // frmSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmSetting";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấu hình hệ thống";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabController.ResumeLayout(false);
            tabController.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvController).EndInit();
            tsbAddController.ResumeLayout(false);
            tsbAddController.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabController;
        private TabPage tabOptions;
        private DataGridView dgvController;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private ToolStrip tsbAddController;
        private ToolStripButton toolStripButton1;
        private ToolStripButton tsbEditController;
        private ToolStripButton tsbDeleteController;
        private ToolStripButton tsbRefreshController;
        private CheckBox chbIsOrderFloorASC;
        private CheckBox chbDisplayArrowByFloorOrder;
        private Label label3;
        private Label label2;
        private NumericUpDown numWaitingSwipeCard;
        private Label label1;
    }
}