namespace v5MonitorApp.UserControls
{
    partial class ucDeviceMonitor<T> where T : Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAbnormalStatus = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGridView = new System.Windows.Forms.Panel();
            this.chbAutoSize = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbDIsplayGridview = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbnormalStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAbnormalStatus
            // 
            this.dgvAbnormalStatus.AllowUserToAddRows = false;
            this.dgvAbnormalStatus.AllowUserToDeleteRows = false;
            this.dgvAbnormalStatus.AllowUserToResizeColumns = false;
            this.dgvAbnormalStatus.AllowUserToResizeRows = false;
            this.dgvAbnormalStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAbnormalStatus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAbnormalStatus.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAbnormalStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAbnormalStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbnormalStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3});
            this.dgvAbnormalStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAbnormalStatus.Location = new System.Drawing.Point(0, 693);
            this.dgvAbnormalStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAbnormalStatus.Name = "dgvAbnormalStatus";
            this.dgvAbnormalStatus.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAbnormalStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAbnormalStatus.RowHeadersVisible = false;
            this.dgvAbnormalStatus.Size = new System.Drawing.Size(861, 234);
            this.dgvAbnormalStatus.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 41;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Thời Gian";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 112;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 68;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Trạng Thái";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panelGridView
            // 
            this.panelGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridView.Location = new System.Drawing.Point(0, 47);
            this.panelGridView.Name = "panelGridView";
            this.panelGridView.Size = new System.Drawing.Size(861, 880);
            this.panelGridView.TabIndex = 1;
            // 
            // chbAutoSize
            // 
            this.chbAutoSize.AutoSize = true;
            this.chbAutoSize.Location = new System.Drawing.Point(217, 8);
            this.chbAutoSize.Name = "chbAutoSize";
            this.chbAutoSize.Size = new System.Drawing.Size(405, 25);
            this.chbAutoSize.TabIndex = 2;
            this.chbAutoSize.Text = "Tự động co kích thước Gridview theo nội dung hiển thị";
            this.chbAutoSize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cỡ chữ";
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(78, 6);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(94, 29);
            this.numFontSize.TabIndex = 4;
            this.numFontSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numFontSize.ValueChanged += new System.EventHandler(this.numFontSize_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbDIsplayGridview);
            this.panel1.Controls.Add(this.numFontSize);
            this.panel1.Controls.Add(this.chbAutoSize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 47);
            this.panel1.TabIndex = 5;
            // 
            // chbDIsplayGridview
            // 
            this.chbDIsplayGridview.AutoSize = true;
            this.chbDIsplayGridview.Checked = true;
            this.chbDIsplayGridview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDIsplayGridview.Location = new System.Drawing.Point(637, 8);
            this.chbDIsplayGridview.Name = "chbDIsplayGridview";
            this.chbDIsplayGridview.Size = new System.Drawing.Size(178, 25);
            this.chbDIsplayGridview.TabIndex = 5;
            this.chbDIsplayGridview.Text = "Hiển thị danh sách lỗi";
            this.chbDIsplayGridview.UseVisualStyleBackColor = true;
            this.chbDIsplayGridview.CheckedChanged += new System.EventHandler(this.chbDIsplayGridview_CheckedChanged);
            // 
            // ucDeviceMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAbnormalStatus);
            this.Controls.Add(this.panelGridView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucDeviceMonitor";
            this.Size = new System.Drawing.Size(861, 927);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbnormalStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAbnormalStatus;
        private Panel panelGridView;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private CheckBox chbAutoSize;
        private Label label1;
        private NumericUpDown numFontSize;
        private Panel panel1;
        private CheckBox chbDIsplayGridview;
    }
}
