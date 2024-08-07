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
            tableLayoutPanel2 = new TableLayoutPanel();
            lblCurrentVehicleInParkTitle = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleOutDayTitle = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleIn = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleOutDay = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblCurrentVehicleInPark = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleInTitle = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            timerUpdateCount = new System.Windows.Forms.Timer(components);
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lblCurrentVehicleInParkTitle, 0, 2);
            tableLayoutPanel2.Controls.Add(lblVehicleOutDayTitle, 0, 1);
            tableLayoutPanel2.Controls.Add(lblVehicleIn, 1, 0);
            tableLayoutPanel2.Controls.Add(lblVehicleOutDay, 1, 1);
            tableLayoutPanel2.Controls.Add(lblCurrentVehicleInPark, 1, 2);
            tableLayoutPanel2.Controls.Add(lblVehicleInTitle, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(355, 205);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // lblCurrentVehicleInParkTitle
            // 
            lblCurrentVehicleInParkTitle.Dock = DockStyle.Fill;
            lblCurrentVehicleInParkTitle.Location = new Point(4, 135);
            lblCurrentVehicleInParkTitle.Name = "lblCurrentVehicleInParkTitle";
            lblCurrentVehicleInParkTitle.Size = new Size(170, 69);
            lblCurrentVehicleInParkTitle.TabIndex = 8;
            lblCurrentVehicleInParkTitle.Text = "Trong bãi";
            lblCurrentVehicleInParkTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleOutDayTitle
            // 
            lblVehicleOutDayTitle.Dock = DockStyle.Fill;
            lblVehicleOutDayTitle.Location = new Point(4, 68);
            lblVehicleOutDayTitle.Name = "lblVehicleOutDayTitle";
            lblVehicleOutDayTitle.Size = new Size(170, 66);
            lblVehicleOutDayTitle.TabIndex = 7;
            lblVehicleOutDayTitle.Text = "Xe ra";
            lblVehicleOutDayTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleIn
            // 
            lblVehicleIn.Dock = DockStyle.Fill;
            lblVehicleIn.Location = new Point(181, 1);
            lblVehicleIn.Name = "lblVehicleIn";
            lblVehicleIn.Size = new Size(170, 66);
            lblVehicleIn.TabIndex = 3;
            lblVehicleIn.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVehicleOutDay
            // 
            lblVehicleOutDay.Dock = DockStyle.Fill;
            lblVehicleOutDay.Font = new Font("Digital-7", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVehicleOutDay.Location = new Point(181, 68);
            lblVehicleOutDay.Name = "lblVehicleOutDay";
            lblVehicleOutDay.Size = new Size(170, 66);
            lblVehicleOutDay.TabIndex = 4;
            lblVehicleOutDay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentVehicleInPark
            // 
            lblCurrentVehicleInPark.Dock = DockStyle.Fill;
            lblCurrentVehicleInPark.Location = new Point(181, 135);
            lblCurrentVehicleInPark.Name = "lblCurrentVehicleInPark";
            lblCurrentVehicleInPark.Size = new Size(170, 69);
            lblCurrentVehicleInPark.TabIndex = 5;
            lblCurrentVehicleInPark.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVehicleInTitle
            // 
            lblVehicleInTitle.Dock = DockStyle.Fill;
            lblVehicleInTitle.Location = new Point(4, 1);
            lblVehicleInTitle.Name = "lblVehicleInTitle";
            lblVehicleInTitle.Size = new Size(170, 66);
            lblVehicleInTitle.TabIndex = 6;
            lblVehicleInTitle.Text = "Xe vào";
            lblVehicleInTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timerUpdateCount
            // 
            timerUpdateCount.Enabled = true;
            timerUpdateCount.Interval = 10000;
            timerUpdateCount.Tick += timerUpdateCount_Tick;
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
        private TableLayoutPanel tableLayoutPanel2;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblVehicleIn;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblVehicleOutDay;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblCurrentVehicleInPark;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblCurrentVehicleInParkTitle;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblVehicleOutDayTitle;
        private iPakrkingv5.Controls.Controls.Labels.lblResult lblVehicleInTitle;
        private System.Windows.Forms.Timer timerUpdateCount;
    }
}
