namespace iParkingv5_window.Usercontrols
{
    partial class ucFileInfo
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblVersion = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblUpdateDate = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblVersion, 0, 0);
            tableLayoutPanel1.Controls.Add(lblUpdateDate, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(534, 47);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Dock = DockStyle.Fill;
            lblVersion.IsBold = true;
            lblVersion.IsUpper = true;
            lblVersion.Location = new Point(4, 1);
            lblVersion.MaxFontSize = -1;
            lblVersion.Message = "";
            lblVersion.MessageBackColor = SystemColors.ButtonHighlight;
            lblVersion.MessageForeColor = Color.Black;
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(259, 45);
            lblVersion.TabIndex = 0;
            lblVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUpdateDate
            // 
            lblUpdateDate.AutoSize = true;
            lblUpdateDate.Dock = DockStyle.Fill;
            lblUpdateDate.IsBold = true;
            lblUpdateDate.IsUpper = true;
            lblUpdateDate.Location = new Point(270, 1);
            lblUpdateDate.MaxFontSize = -1;
            lblUpdateDate.Message = "";
            lblUpdateDate.MessageBackColor = SystemColors.ButtonHighlight;
            lblUpdateDate.MessageForeColor = Color.Black;
            lblUpdateDate.Name = "lblUpdateDate";
            lblUpdateDate.Size = new Size(260, 45);
            lblUpdateDate.TabIndex = 0;
            lblUpdateDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucFileInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(0);
            Name = "ucFileInfo";
            Size = new Size(534, 47);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblVersion;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblUpdateDate;
    }
}
