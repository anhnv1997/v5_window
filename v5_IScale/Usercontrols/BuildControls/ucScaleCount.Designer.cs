namespace v5_IScale.Usercontrols.BuildControls
{
    partial class ucScaleCount
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
            timerUpdateCount.Stop();
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblMoreThanSecondCount = new Label();
            lblSecondCount = new Label();
            lblFirstCount = new Label();
            timerUpdateCount = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 1, 3);
            tableLayoutPanel1.Controls.Add(lblMoreThanSecondCount, 2, 3);
            tableLayoutPanel1.Controls.Add(lblSecondCount, 2, 2);
            tableLayoutPanel1.Controls.Add(lblFirstCount, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(471, 190);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.Location = new Point(150, 42);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 0;
            label1.Text = "Cân lần 1:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(150, 74);
            label2.Name = "label2";
            label2.Size = new Size(111, 31);
            label2.TabIndex = 1;
            label2.Text = "Cân lần 2:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(150, 105);
            label3.Name = "label3";
            label3.Size = new Size(111, 42);
            label3.TabIndex = 2;
            label3.Text = "Cân lần >2:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMoreThanSecondCount
            // 
            lblMoreThanSecondCount.Dock = DockStyle.Fill;
            lblMoreThanSecondCount.Font = new Font("Digital-7", 15.75F, FontStyle.Bold);
            lblMoreThanSecondCount.Location = new Point(267, 105);
            lblMoreThanSecondCount.Name = "lblMoreThanSecondCount";
            lblMoreThanSecondCount.Size = new Size(54, 42);
            lblMoreThanSecondCount.TabIndex = 2;
            lblMoreThanSecondCount.Text = "0";
            lblMoreThanSecondCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSecondCount
            // 
            lblSecondCount.Dock = DockStyle.Fill;
            lblSecondCount.Font = new Font("Digital-7", 15.75F, FontStyle.Bold);
            lblSecondCount.Location = new Point(267, 74);
            lblSecondCount.Name = "lblSecondCount";
            lblSecondCount.Size = new Size(54, 31);
            lblSecondCount.TabIndex = 2;
            lblSecondCount.Text = "0";
            lblSecondCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFirstCount
            // 
            lblFirstCount.Dock = DockStyle.Fill;
            lblFirstCount.Font = new Font("Digital-7", 15.75F, FontStyle.Bold);
            lblFirstCount.Location = new Point(267, 42);
            lblFirstCount.Name = "lblFirstCount";
            lblFirstCount.Size = new Size(54, 32);
            lblFirstCount.TabIndex = 2;
            lblFirstCount.Text = "0";
            lblFirstCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timerUpdateCount
            // 
            timerUpdateCount.Interval = 1000;
            timerUpdateCount.Tick += timerUpdateCount_Tick;
            // 
            // ucScaleCount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucScaleCount";
            Size = new Size(471, 190);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblMoreThanSecondCount;
        private Label lblSecondCount;
        private Label lblFirstCount;
        private System.Windows.Forms.Timer timerUpdateCount;
    }
}
