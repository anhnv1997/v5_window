using iPakrkingv5.Controls.Controls.Buttons;

namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirmOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmOut));
            lblMessage = new Label();
            panelAction = new Panel();
            btnCancel1 = new LblCancel();
            btnOk = new BtnOk();
            dgvEventInData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            panelEventPic = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverview = new Usercontrols.MovablePictureBox();
            picVehicle = new Usercontrols.MovablePictureBox();
            panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventInData).BeginInit();
            panel1.SuspendLayout();
            panelEventPic.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(945, 58);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(btnCancel1);
            panelAction.Controls.Add(btnOk);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 423);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(945, 62);
            panelAction.TabIndex = 1;
            // 
            // btnCancel1
            // 
            btnCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel1.AutoSize = true;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(865, 14);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(57, 30);
            btnCancel1.TabIndex = 3;
            btnCancel1.Text = "Đóng";
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.AutoSize = true;
            btnOk.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk.ForeColor = Color.Black;
            btnOk.Location = new Point(784, 14);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(83, 30);
            btnOk.TabIndex = 2;
            btnOk.Text = "Xác nhận";
            // 
            // dgvEventInData
            // 
            dgvEventInData.AllowUserToAddRows = false;
            dgvEventInData.AllowUserToDeleteRows = false;
            dgvEventInData.AllowUserToResizeColumns = false;
            dgvEventInData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            dgvEventInData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEventInData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEventInData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEventInData.BackgroundColor = SystemColors.Control;
            dgvEventInData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventInData.ColumnHeadersVisible = false;
            dgvEventInData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEventInData.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEventInData.Dock = DockStyle.Fill;
            dgvEventInData.Location = new Point(0, 0);
            dgvEventInData.Name = "dgvEventInData";
            dgvEventInData.RowHeadersVisible = false;
            dgvEventInData.RowTemplate.Height = 29;
            dgvEventInData.Size = new Size(624, 365);
            dgvEventInData.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Header";
            Column1.Name = "Column1";
            Column1.Width = 5;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Content";
            Column2.Name = "Column2";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvEventInData);
            panel1.Controls.Add(panelEventPic);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(945, 365);
            panel1.TabIndex = 3;
            // 
            // panelEventPic
            // 
            panelEventPic.Controls.Add(tableLayoutPanel1);
            panelEventPic.Dock = DockStyle.Right;
            panelEventPic.Location = new Point(624, 0);
            panelEventPic.Name = "panelEventPic";
            panelEventPic.Size = new Size(321, 365);
            panelEventPic.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picOverview, 0, 0);
            tableLayoutPanel1.Controls.Add(picVehicle, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(321, 365);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picOverview
            // 
            picOverview.Dock = DockStyle.Fill;
            picOverview.Location = new Point(3, 3);
            picOverview.Name = "picOverview";
            picOverview.Size = new Size(315, 176);
            picOverview.SizeMode = PictureBoxSizeMode.Zoom;
            picOverview.TabIndex = 0;
            picOverview.TabStop = false;
            // 
            // picVehicle
            // 
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(3, 185);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(315, 177);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // frmConfirmOut
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(945, 485);
            Controls.Add(panel1);
            Controls.Add(lblMessage);
            Controls.Add(panelAction);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfirmOut";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventInData).EndInit();
            panel1.ResumeLayout(false);
            panelEventPic.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverview).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
        private Panel panelAction;
        private BtnOk btnOk;
        private LblCancel btnCancel1;
        private DataGridView dgvEventInData;
        private Panel panel1;
        private Panel panelEventPic;
        private TableLayoutPanel tableLayoutPanel1;
        private Usercontrols.MovablePictureBox picOverview;
        private Usercontrols.MovablePictureBox picVehicle;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}