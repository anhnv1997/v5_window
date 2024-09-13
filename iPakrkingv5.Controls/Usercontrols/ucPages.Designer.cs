namespace iPakrkingv5.Controls.Usercontrols
{
    partial class ucPages
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
            lblMaxPage = new Controls.Labels.lblResult();
            picNext = new FontAwesome.Sharp.IconPictureBox();
            picLast = new FontAwesome.Sharp.IconPictureBox();
            picBack = new FontAwesome.Sharp.IconPictureBox();
            picFirst = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblResult1 = new Controls.Labels.lblResult();
            txtCurrentPage = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picNext).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLast).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFirst).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblMaxPage
            // 
            lblMaxPage.BackColor = SystemColors.ButtonHighlight;
            lblMaxPage.Dock = DockStyle.Fill;
            lblMaxPage.IsBold = true;
            lblMaxPage.IsUpper = true;
            lblMaxPage.Location = new Point(451, 0);
            lblMaxPage.MaxFontSize = 32;
            lblMaxPage.Message = "00";
            lblMaxPage.MessageBackColor = SystemColors.ButtonHighlight;
            lblMaxPage.MessageForeColor = Color.Black;
            lblMaxPage.Name = "lblMaxPage";
            lblMaxPage.Size = new Size(34, 35);
            lblMaxPage.TabIndex = 1;
            // 
            // picNext
            // 
            picNext.BackColor = SystemColors.ButtonHighlight;
            picNext.Cursor = Cursors.Hand;
            picNext.Dock = DockStyle.Fill;
            picNext.ForeColor = SystemColors.ControlText;
            picNext.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            picNext.IconColor = SystemColors.ControlText;
            picNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            picNext.IconSize = 34;
            picNext.Location = new Point(491, 0);
            picNext.Margin = new Padding(3, 0, 3, 0);
            picNext.Name = "picNext";
            picNext.Size = new Size(34, 35);
            picNext.SizeMode = PictureBoxSizeMode.Zoom;
            picNext.TabIndex = 2;
            picNext.TabStop = false;
            picNext.Click += picNext_Click;
            // 
            // picLast
            // 
            picLast.BackColor = SystemColors.ButtonHighlight;
            picLast.Cursor = Cursors.Hand;
            picLast.Dock = DockStyle.Fill;
            picLast.ForeColor = SystemColors.ControlText;
            picLast.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            picLast.IconColor = SystemColors.ControlText;
            picLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
            picLast.IconSize = 34;
            picLast.Location = new Point(531, 0);
            picLast.Margin = new Padding(3, 0, 3, 0);
            picLast.Name = "picLast";
            picLast.Size = new Size(34, 35);
            picLast.SizeMode = PictureBoxSizeMode.Zoom;
            picLast.TabIndex = 2;
            picLast.TabStop = false;
            picLast.Click += picLast_Click;
            // 
            // picBack
            // 
            picBack.BackColor = SystemColors.ButtonHighlight;
            picBack.Cursor = Cursors.Hand;
            picBack.Dock = DockStyle.Fill;
            picBack.ForeColor = SystemColors.ControlText;
            picBack.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            picBack.IconColor = SystemColors.ControlText;
            picBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            picBack.IconSize = 34;
            picBack.Location = new Point(311, 0);
            picBack.Margin = new Padding(3, 0, 3, 0);
            picBack.Name = "picBack";
            picBack.Size = new Size(34, 35);
            picBack.SizeMode = PictureBoxSizeMode.Zoom;
            picBack.TabIndex = 2;
            picBack.TabStop = false;
            picBack.Click += picBack_Click;
            // 
            // picFirst
            // 
            picFirst.BackColor = SystemColors.ButtonHighlight;
            picFirst.Cursor = Cursors.Hand;
            picFirst.Dock = DockStyle.Fill;
            picFirst.ForeColor = SystemColors.ControlText;
            picFirst.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            picFirst.IconColor = SystemColors.ControlText;
            picFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
            picFirst.IconSize = 34;
            picFirst.Location = new Point(271, 0);
            picFirst.Margin = new Padding(3, 0, 3, 0);
            picFirst.Name = "picFirst";
            picFirst.Size = new Size(34, 35);
            picFirst.SizeMode = PictureBoxSizeMode.Zoom;
            picFirst.TabIndex = 2;
            picFirst.TabStop = false;
            picFirst.Click += picFirst_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picFirst, 1, 0);
            tableLayoutPanel1.Controls.Add(picLast, 7, 0);
            tableLayoutPanel1.Controls.Add(picBack, 2, 0);
            tableLayoutPanel1.Controls.Add(picNext, 6, 0);
            tableLayoutPanel1.Controls.Add(lblMaxPage, 5, 0);
            tableLayoutPanel1.Controls.Add(lblResult1, 4, 0);
            tableLayoutPanel1.Controls.Add(txtCurrentPage, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(837, 35);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // lblResult1
            // 
            lblResult1.BackColor = SystemColors.ButtonHighlight;
            lblResult1.Dock = DockStyle.Fill;
            lblResult1.IsBold = true;
            lblResult1.IsUpper = true;
            lblResult1.Location = new Point(431, 0);
            lblResult1.MaxFontSize = 32;
            lblResult1.Message = "/";
            lblResult1.MessageBackColor = SystemColors.ButtonHighlight;
            lblResult1.MessageForeColor = Color.Black;
            lblResult1.Name = "lblResult1";
            lblResult1.Size = new Size(14, 35);
            lblResult1.TabIndex = 4;
            // 
            // txtCurrentPage
            // 
            txtCurrentPage.BackColor = Color.FromArgb(128, 255, 255);
            txtCurrentPage.Dock = DockStyle.Bottom;
            txtCurrentPage.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtCurrentPage.Location = new Point(351, 4);
            txtCurrentPage.Margin = new Padding(3, 0, 3, 0);
            txtCurrentPage.Name = "txtCurrentPage";
            txtCurrentPage.Size = new Size(74, 31);
            txtCurrentPage.TabIndex = 5;
            txtCurrentPage.Text = "1";
            txtCurrentPage.TextAlign = HorizontalAlignment.Center;
            // 
            // ucPages
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucPages";
            Size = new Size(837, 35);
            ((System.ComponentModel.ISupportInitialize)picNext).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLast).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFirst).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Controls.Labels.lblResult lblMaxPage;
        private FontAwesome.Sharp.IconPictureBox picNext;
        private FontAwesome.Sharp.IconPictureBox picLast;
        private FontAwesome.Sharp.IconPictureBox picBack;
        private FontAwesome.Sharp.IconPictureBox picFirst;
        private TableLayoutPanel tableLayoutPanel1;
        private Controls.Labels.lblResult lblResult1;
        private TextBox txtCurrentPage;
    }
}
