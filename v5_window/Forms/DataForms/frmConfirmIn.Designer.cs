namespace iParkingv5_window.Forms.DataForms
{
    partial class frmConfirmIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmIn));
            panel1 = new Panel();
            dgvEventInData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panelEventPic = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            picOverview = new Usercontrols.MovablePictureBox();
            picVehicle = new Usercontrols.MovablePictureBox();
            lblMessage = new Label();
            panelAction = new Panel();
            lblCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEventInData).BeginInit();
            panelEventPic.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOverview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).BeginInit();
            panelAction.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvEventInData);
            panel1.Controls.Add(panelEventPic);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 44);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(883, 327);
            panel1.TabIndex = 6;
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEventInData.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEventInData.Dock = DockStyle.Fill;
            dgvEventInData.Location = new Point(0, 0);
            dgvEventInData.Margin = new Padding(3, 2, 3, 2);
            dgvEventInData.Name = "dgvEventInData";
            dgvEventInData.RowHeadersVisible = false;
            dgvEventInData.RowTemplate.Height = 29;
            dgvEventInData.Size = new Size(602, 327);
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
            // panelEventPic
            // 
            panelEventPic.Controls.Add(tableLayoutPanel1);
            panelEventPic.Dock = DockStyle.Right;
            panelEventPic.Location = new Point(602, 0);
            panelEventPic.Margin = new Padding(3, 2, 3, 2);
            panelEventPic.Name = "panelEventPic";
            panelEventPic.Size = new Size(281, 327);
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
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(281, 327);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // picOverview
            // 
            picOverview.Dock = DockStyle.Fill;
            picOverview.Location = new Point(3, 2);
            picOverview.Margin = new Padding(3, 2, 3, 2);
            picOverview.Name = "picOverview";
            picOverview.Size = new Size(275, 159);
            picOverview.SizeMode = PictureBoxSizeMode.Zoom;
            picOverview.TabIndex = 0;
            picOverview.TabStop = false;
            // 
            // picVehicle
            // 
            picVehicle.Dock = DockStyle.Fill;
            picVehicle.Location = new Point(3, 165);
            picVehicle.Margin = new Padding(3, 2, 3, 2);
            picVehicle.Name = "picVehicle";
            picVehicle.Size = new Size(275, 160);
            picVehicle.SizeMode = PictureBoxSizeMode.Zoom;
            picVehicle.TabIndex = 0;
            picVehicle.TabStop = false;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(883, 44);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(lblCancel1);
            panelAction.Controls.Add(btnOk1);
            panelAction.Dock = DockStyle.Bottom;
            panelAction.Location = new Point(0, 371);
            panelAction.Margin = new Padding(3, 2, 3, 2);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(883, 46);
            panelAction.TabIndex = 5;
            // 
            // lblCancel1
            // 
            lblCancel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCancel1.AutoSize = true;
            lblCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblCancel1.ForeColor = Color.Black;
            lblCancel1.Location = new Point(818, 7);
            lblCancel1.Margin = new Padding(3, 2, 3, 2);
            lblCancel1.Name = "lblCancel1";
            lblCancel1.Size = new Size(57, 30);
            lblCancel1.TabIndex = 5;
            lblCancel1.Text = "Đóng";
            // 
            // btnOk1
            // 
            btnOk1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk1.AutoSize = true;
            btnOk1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOk1.ForeColor = Color.Black;
            btnOk1.Location = new Point(729, 7);
            btnOk1.Margin = new Padding(3, 2, 3, 2);
            btnOk1.Name = "btnOk1";
            btnOk1.Size = new Size(83, 30);
            btnOk1.TabIndex = 4;
            btnOk1.Text = "Xác nhận";
            // 
            // frmConfirmIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 417);
            Controls.Add(panel1);
            Controls.Add(lblMessage);
            Controls.Add(panelAction);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmConfirmIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác nhận thông tin";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEventInData).EndInit();
            panelEventPic.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picOverview).EndInit();
            ((System.ComponentModel.ISupportInitialize)picVehicle).EndInit();
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvEventInData;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Panel panelEventPic;
        private TableLayoutPanel tableLayoutPanel1;
        private Usercontrols.MovablePictureBox picOverview;
        private Usercontrols.MovablePictureBox picVehicle;
        private Label lblMessage;
        private Panel panelAction;
        private iPakrkingv5.Controls.Controls.Buttons.LblCancel lblCancel1;
        private iPakrkingv5.Controls.Controls.Buttons.BtnOk btnOk1;
    }
}