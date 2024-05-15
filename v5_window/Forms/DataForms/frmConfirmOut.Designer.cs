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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmOut));
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelAction = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel1 = new iPakrkingv5.Controls.Controls.Buttons.LblCancel();
            this.btnOk2 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            this.btnOk1 = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            this.btnOk = new iPakrkingv5.Controls.Controls.Buttons.BtnOk();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.dgvEventInData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelEventPic = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picOverview = new iParkingv5_window.Usercontrols.MovablePictureBox();
            this.picVehicle = new iParkingv5_window.Usercontrols.MovablePictureBox();
            this.pnlQR = new System.Windows.Forms.Panel();
            this.panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventInData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelEventPic.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).BeginInit();
            this.pnlQR.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(976, 58);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "label1";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.label1);
            this.panelAction.Controls.Add(this.btnCancel1);
            this.panelAction.Controls.Add(this.btnOk2);
            this.panelAction.Controls.Add(this.btnOk1);
            this.panelAction.Controls.Add(this.btnOk);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAction.Location = new System.Drawing.Point(0, 405);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(976, 100);
            this.panelAction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // btnCancel1
            // 
            this.btnCancel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel1.AutoSize = true;
            this.btnCancel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel1.ForeColor = System.Drawing.Color.Black;
            this.btnCancel1.Location = new System.Drawing.Point(907, 54);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(57, 30);
            this.btnCancel1.TabIndex = 3;
            this.btnCancel1.Text = "Đóng";
            // 
            // btnOk2
            // 
            this.btnOk2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk2.AutoSize = true;
            this.btnOk2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOk2.ForeColor = System.Drawing.Color.Black;
            this.btnOk2.Location = new System.Drawing.Point(375, 19);
            this.btnOk2.Name = "btnOk2";
            this.btnOk2.Size = new System.Drawing.Size(144, 59);
            this.btnOk2.TabIndex = 2;
            this.btnOk2.Text = "Thanh toán QR";
            // 
            // btnOk1
            // 
            this.btnOk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk1.AutoSize = true;
            this.btnOk1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOk1.ForeColor = System.Drawing.Color.Black;
            this.btnOk1.Location = new System.Drawing.Point(553, 19);
            this.btnOk1.Name = "btnOk1";
            this.btnOk1.Size = new System.Drawing.Size(159, 59);
            this.btnOk1.TabIndex = 2;
            this.btnOk1.Text = "Thanh toán VETC";
            this.btnOk1.Click += new System.EventHandler(this.btnVETC_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.AutoSize = true;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(185, 19);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(144, 59);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Tiền mặt";
            // 
            // picQR
            // 
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picQR.Location = new System.Drawing.Point(20, 20);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(305, 307);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 5;
            this.picQR.TabStop = false;
            // 
            // dgvEventInData
            // 
            this.dgvEventInData.AllowUserToAddRows = false;
            this.dgvEventInData.AllowUserToDeleteRows = false;
            this.dgvEventInData.AllowUserToResizeColumns = false;
            this.dgvEventInData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvEventInData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEventInData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEventInData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEventInData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEventInData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventInData.ColumnHeadersVisible = false;
            this.dgvEventInData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEventInData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEventInData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEventInData.Location = new System.Drawing.Point(0, 0);
            this.dgvEventInData.Name = "dgvEventInData";
            this.dgvEventInData.RowHeadersVisible = false;
            this.dgvEventInData.RowTemplate.Height = 29;
            this.dgvEventInData.Size = new System.Drawing.Size(373, 347);
            this.dgvEventInData.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Header";
            this.Column1.Name = "Column1";
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Content";
            this.Column2.Name = "Column2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEventInData);
            this.panel1.Controls.Add(this.panelEventPic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(345, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 347);
            this.panel1.TabIndex = 3;
            // 
            // panelEventPic
            // 
            this.panelEventPic.Controls.Add(this.tableLayoutPanel1);
            this.panelEventPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEventPic.Location = new System.Drawing.Point(373, 0);
            this.panelEventPic.Name = "panelEventPic";
            this.panelEventPic.Size = new System.Drawing.Size(258, 347);
            this.panelEventPic.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picOverview, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picVehicle, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 347);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picOverview
            // 
            this.picOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOverview.Location = new System.Drawing.Point(3, 3);
            this.picOverview.Name = "picOverview";
            this.picOverview.Size = new System.Drawing.Size(252, 167);
            this.picOverview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOverview.TabIndex = 0;
            this.picOverview.TabStop = false;
            // 
            // picVehicle
            // 
            this.picVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVehicle.Location = new System.Drawing.Point(3, 176);
            this.picVehicle.Name = "picVehicle";
            this.picVehicle.Size = new System.Drawing.Size(252, 168);
            this.picVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicle.TabIndex = 0;
            this.picVehicle.TabStop = false;
            // 
            // pnlQR
            // 
            this.pnlQR.Controls.Add(this.picQR);
            this.pnlQR.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlQR.Location = new System.Drawing.Point(0, 58);
            this.pnlQR.Name = "pnlQR";
            this.pnlQR.Padding = new System.Windows.Forms.Padding(20);
            this.pnlQR.Size = new System.Drawing.Size(345, 347);
            this.pnlQR.TabIndex = 4;
            // 
            // frmConfirmOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(976, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlQR);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panelAction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận thông tin";
            this.Load += new System.EventHandler(this.frmConfirmOut_Load);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventInData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelEventPic.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).EndInit();
            this.pnlQR.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private PictureBox picQR;
        private Label label1;
        private BtnOk btnOk2;
        private BtnOk btnOk1;
        private Panel pnlQR;
    }
}