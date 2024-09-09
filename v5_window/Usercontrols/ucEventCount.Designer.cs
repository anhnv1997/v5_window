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
            lblVehicleIn = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleInTitle = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleOutDayTitle = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblVehicleOutDay = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblCurrentVehicleInParkTitle = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            lblCurrentVehicleInPark = new iPakrkingv5.Controls.Controls.Labels.lblResult();
            timerUpdateCount = new System.Windows.Forms.Timer(components);
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.Controls.Add(lblVehicleIn, 1, 0);
            tableLayoutPanel2.Controls.Add(lblVehicleInTitle, 0, 0);
            tableLayoutPanel2.Controls.Add(lblVehicleOutDayTitle, 2, 0);
            tableLayoutPanel2.Controls.Add(lblVehicleOutDay, 3, 0);
            tableLayoutPanel2.Controls.Add(lblCurrentVehicleInParkTitle, 4, 0);
            tableLayoutPanel2.Controls.Add(lblCurrentVehicleInPark, 5, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(355, 68);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // lblVehicleIn
            // 
            lblVehicleIn.BackColor = SystemColors.Control;
            lblVehicleIn.Dock = DockStyle.Fill;
            lblVehicleIn.Location = new Point(63, 1);
            lblVehicleIn.MaxFontSize = -1;
            lblVehicleIn.Message = "";
            lblVehicleIn.MessageBackColor = SystemColors.Control;
            lblVehicleIn.MessageForeColor = Color.White;
            lblVehicleIn.Name = "lblVehicleIn";
            lblVehicleIn.Size = new Size(52, 66);
            lblVehicleIn.TabIndex = 3;
            lblVehicleIn.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblVehicleInTitle
            // 
            lblVehicleInTitle.BackColor = SystemColors.Control;
            lblVehicleInTitle.Dock = DockStyle.Fill;
            lblVehicleInTitle.Location = new Point(4, 1);
            lblVehicleInTitle.MaxFontSize = -1;
            lblVehicleInTitle.Message = "";
            lblVehicleInTitle.MessageBackColor = SystemColors.Control;
            lblVehicleInTitle.MessageForeColor = Color.White;
            lblVehicleInTitle.Name = "lblVehicleInTitle";
            lblVehicleInTitle.Size = new Size(52, 66);
            lblVehicleInTitle.TabIndex = 6;
            lblVehicleInTitle.Text = "Vào";
            lblVehicleInTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleOutDayTitle
            // 
            lblVehicleOutDayTitle.BackColor = SystemColors.Control;
            lblVehicleOutDayTitle.Dock = DockStyle.Fill;
            lblVehicleOutDayTitle.Location = new Point(122, 1);
            lblVehicleOutDayTitle.MaxFontSize = -1;
            lblVehicleOutDayTitle.Message = "";
            lblVehicleOutDayTitle.MessageBackColor = SystemColors.Control;
            lblVehicleOutDayTitle.MessageForeColor = Color.White;
            lblVehicleOutDayTitle.Name = "lblVehicleOutDayTitle";
            lblVehicleOutDayTitle.Size = new Size(52, 66);
            lblVehicleOutDayTitle.TabIndex = 7;
            lblVehicleOutDayTitle.Text = "Ra";
            lblVehicleOutDayTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVehicleOutDay
            // 
            lblVehicleOutDay.BackColor = SystemColors.Control;
            lblVehicleOutDay.Dock = DockStyle.Fill;
            lblVehicleOutDay.Font = new Font("Digital-7", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVehicleOutDay.Location = new Point(181, 1);
            lblVehicleOutDay.MaxFontSize = -1;
            lblVehicleOutDay.Message = "";
            lblVehicleOutDay.MessageBackColor = SystemColors.Control;
            lblVehicleOutDay.MessageForeColor = Color.White;
            lblVehicleOutDay.Name = "lblVehicleOutDay";
            lblVehicleOutDay.Size = new Size(52, 66);
            lblVehicleOutDay.TabIndex = 4;
            lblVehicleOutDay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentVehicleInParkTitle
            // 
            lblCurrentVehicleInParkTitle.BackColor = SystemColors.Control;
            lblCurrentVehicleInParkTitle.Dock = DockStyle.Fill;
            lblCurrentVehicleInParkTitle.Location = new Point(240, 1);
            lblCurrentVehicleInParkTitle.MaxFontSize = -1;
            lblCurrentVehicleInParkTitle.Message = "";
            lblCurrentVehicleInParkTitle.MessageBackColor = SystemColors.Control;
            lblCurrentVehicleInParkTitle.MessageForeColor = Color.White;
            lblCurrentVehicleInParkTitle.Name = "lblCurrentVehicleInParkTitle";
            lblCurrentVehicleInParkTitle.Size = new Size(52, 66);
            lblCurrentVehicleInParkTitle.TabIndex = 8;
            lblCurrentVehicleInParkTitle.Text = "Tồn";
            lblCurrentVehicleInParkTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentVehicleInPark
            // 
            lblCurrentVehicleInPark.BackColor = SystemColors.Control;
            lblCurrentVehicleInPark.Dock = DockStyle.Fill;
            lblCurrentVehicleInPark.Location = new Point(299, 1);
            lblCurrentVehicleInPark.MaxFontSize = -1;
            lblCurrentVehicleInPark.Message = "";
            lblCurrentVehicleInPark.MessageBackColor = SystemColors.Control;
            lblCurrentVehicleInPark.MessageForeColor = Color.White;
            lblCurrentVehicleInPark.Name = "lblCurrentVehicleInPark";
            lblCurrentVehicleInPark.Size = new Size(52, 66);
            lblCurrentVehicleInPark.TabIndex = 5;
            lblCurrentVehicleInPark.TextAlign = ContentAlignment.MiddleRight;
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
            Size = new Size(355, 68);
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
