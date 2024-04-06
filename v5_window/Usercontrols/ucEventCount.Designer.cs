namespace iParkingv5_window.Usercontrols
{
    partial class ucEventCount
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblCurrentVehicleInPark = new Label();
            lblVehicleIn = new Label();
            lblVehicleOutDay = new Label();
            timerUpdateCount = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(79, 30);
            label1.TabIndex = 0;
            label1.Text = "Xe vào";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(3, 62);
            label2.Name = "label2";
            label2.Size = new Size(63, 30);
            label2.TabIndex = 0;
            label2.Text = "Xe ra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(0, 126);
            label3.Name = "label3";
            label3.Size = new Size(104, 30);
            label3.TabIndex = 0;
            label3.Text = "Trong bãi";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentVehicleInPark
            // 
            lblCurrentVehicleInPark.AutoSize = true;
            lblCurrentVehicleInPark.Font = new Font("Digital-7", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentVehicleInPark.ForeColor = Color.Navy;
            lblCurrentVehicleInPark.Location = new Point(123, 112);
            lblCurrentVehicleInPark.Name = "lblCurrentVehicleInPark";
            lblCurrentVehicleInPark.Size = new Size(99, 44);
            lblCurrentVehicleInPark.TabIndex = 1;
            lblCurrentVehicleInPark.Text = "0000";
            // 
            // lblVehicleIn
            // 
            lblVehicleIn.AutoSize = true;
            lblVehicleIn.Font = new Font("Digital-7", 24F);
            lblVehicleIn.ForeColor = Color.Green;
            lblVehicleIn.Location = new Point(123, 11);
            lblVehicleIn.Name = "lblVehicleIn";
            lblVehicleIn.Size = new Size(75, 33);
            lblVehicleIn.TabIndex = 1;
            lblVehicleIn.Text = "0000";
            // 
            // lblVehicleOutDay
            // 
            lblVehicleOutDay.AutoSize = true;
            lblVehicleOutDay.Font = new Font("Digital-7", 24F);
            lblVehicleOutDay.ForeColor = Color.FromArgb(192, 0, 0);
            lblVehicleOutDay.Location = new Point(123, 59);
            lblVehicleOutDay.Name = "lblVehicleOutDay";
            lblVehicleOutDay.Size = new Size(75, 33);
            lblVehicleOutDay.TabIndex = 1;
            lblVehicleOutDay.Text = "0000";
            // 
            // timerUpdateCount
            // 
            timerUpdateCount.Interval = 1000;
            timerUpdateCount.Tick += timerUpdateCount_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 171F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(317, 212);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblVehicleOutDay);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblVehicleIn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblCurrentVehicleInPark);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 20);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(317, 171);
            panel1.TabIndex = 0;
            // 
            // ucEventCount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucEventCount";
            Size = new Size(317, 212);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblCurrentVehicleInPark;
        private Label lblVehicleIn;
        private Label lblVehicleOutDay;
        private System.Windows.Forms.Timer timerUpdateCount;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
    }
}
