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
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 68);
            label1.TabIndex = 0;
            label1.Text = "Xe vào";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(4, 68);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 68);
            label2.TabIndex = 0;
            label2.Text = "Xe ra";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(4, 136);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 69);
            label3.TabIndex = 0;
            label3.Text = "Trong bãi";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentVehicleInPark
            // 
            lblCurrentVehicleInPark.Dock = DockStyle.Fill;
            lblCurrentVehicleInPark.Font = new Font("Digital-7", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentVehicleInPark.ForeColor = Color.Navy;
            lblCurrentVehicleInPark.Location = new Point(116, 136);
            lblCurrentVehicleInPark.Margin = new Padding(4, 0, 4, 0);
            lblCurrentVehicleInPark.Name = "lblCurrentVehicleInPark";
            lblCurrentVehicleInPark.Size = new Size(235, 69);
            lblCurrentVehicleInPark.TabIndex = 1;
            lblCurrentVehicleInPark.Text = "0000";
            lblCurrentVehicleInPark.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVehicleIn
            // 
            lblVehicleIn.Dock = DockStyle.Fill;
            lblVehicleIn.Font = new Font("Digital-7", 24F);
            lblVehicleIn.ForeColor = Color.Green;
            lblVehicleIn.Location = new Point(116, 0);
            lblVehicleIn.Margin = new Padding(4, 0, 4, 0);
            lblVehicleIn.Name = "lblVehicleIn";
            lblVehicleIn.Size = new Size(235, 68);
            lblVehicleIn.TabIndex = 1;
            lblVehicleIn.Text = "0000";
            lblVehicleIn.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVehicleOutDay
            // 
            lblVehicleOutDay.Dock = DockStyle.Fill;
            lblVehicleOutDay.Font = new Font("Digital-7", 24F);
            lblVehicleOutDay.ForeColor = Color.FromArgb(192, 0, 0);
            lblVehicleOutDay.Location = new Point(116, 68);
            lblVehicleOutDay.Margin = new Padding(4, 0, 4, 0);
            lblVehicleOutDay.Name = "lblVehicleOutDay";
            lblVehicleOutDay.Size = new Size(235, 68);
            lblVehicleOutDay.TabIndex = 1;
            lblVehicleOutDay.Text = "0000";
            lblVehicleOutDay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timerUpdateCount
            // 
            timerUpdateCount.Interval = 1000;
            timerUpdateCount.Tick += timerUpdateCount_Tick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(lblCurrentVehicleInPark, 1, 2);
            tableLayoutPanel2.Controls.Add(lblVehicleOutDay, 1, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 1);
            tableLayoutPanel2.Controls.Add(lblVehicleIn, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(355, 205);
            tableLayoutPanel2.TabIndex = 2;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // ucEventCount
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucEventCount";
            Size = new Size(355, 205);
            tableLayoutPanel2.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel2;
    }
}
