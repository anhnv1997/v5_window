namespace iParkingv5_window.Forms
{
    partial class frmDemo
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelCamera = new Panel();
            panelLprCamera = new Panel();
            picLpr = new PictureBox();
            panel2 = new Panel();
            lbl2Title = new Label();
            lbl2_fee = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel13 = new Panel();
            lbl9Title = new Label();
            lbl9_fee = new Label();
            panel12 = new Panel();
            lbl8Title = new Label();
            lbl8_fee = new Label();
            panel11 = new Panel();
            lbl7Title = new Label();
            lbl7_fee = new Label();
            panel10 = new Panel();
            lbl6Title = new Label();
            lbl6_fee = new Label();
            panel9 = new Panel();
            lbl5Title = new Label();
            lbl5_fee = new Label();
            panel8 = new Panel();
            lbl4Title = new Label();
            lbl4_fee = new Label();
            panel7 = new Panel();
            lbl3Title = new Label();
            lbl3_fee = new Label();
            panel6 = new Panel();
            lbl1_title = new Label();
            lbl1_fee = new Label();
            panel4 = new Panel();
            picQR = new PictureBox();
            lblFee = new Label();
            lblTime = new Label();
            lblDetectPlate = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel5 = new Panel();
            timerGetToken = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelLprCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLpr).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 691);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panelCamera, 0, 0);
            tableLayoutPanel1.Controls.Add(panelLprCamera, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(328, 691);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelCamera
            // 
            panelCamera.Dock = DockStyle.Fill;
            panelCamera.Location = new Point(4, 4);
            panelCamera.Name = "panelCamera";
            panelCamera.Size = new Size(320, 338);
            panelCamera.TabIndex = 0;
            // 
            // panelLprCamera
            // 
            panelLprCamera.Controls.Add(picLpr);
            panelLprCamera.Dock = DockStyle.Fill;
            panelLprCamera.Location = new Point(4, 349);
            panelLprCamera.Name = "panelLprCamera";
            panelLprCamera.Size = new Size(320, 338);
            panelLprCamera.TabIndex = 0;
            // 
            // picLpr
            // 
            picLpr.Dock = DockStyle.Fill;
            picLpr.Image = (Image)resources.GetObject("picLpr.Image");
            picLpr.Location = new Point(0, 0);
            picLpr.Name = "picLpr";
            picLpr.Size = new Size(320, 338);
            picLpr.SizeMode = PictureBoxSizeMode.Zoom;
            picLpr.TabIndex = 0;
            picLpr.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lbl2Title);
            panel2.Controls.Add(lbl2_fee);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(305, 8);
            panel2.Margin = new Padding(8);
            panel2.Name = "panel2";
            panel2.Size = new Size(281, 156);
            panel2.TabIndex = 1;
            // 
            // lbl2Title
            // 
            lbl2Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl2Title.Dock = DockStyle.Fill;
            lbl2Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl2Title.ForeColor = Color.White;
            lbl2Title.Location = new Point(0, 0);
            lbl2Title.Margin = new Padding(4, 0, 4, 0);
            lbl2Title.Name = "lbl2Title";
            lbl2Title.Padding = new Padding(0, 16, 0, 0);
            lbl2Title.Size = new Size(279, 124);
            lbl2Title.TabIndex = 1;
            lbl2Title.Text = "Xe lôi đạp\r\nXe máy điện";
            lbl2Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl2_fee
            // 
            lbl2_fee.Dock = DockStyle.Bottom;
            lbl2_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl2_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl2_fee.Location = new Point(0, 124);
            lbl2_fee.Name = "lbl2_fee";
            lbl2_fee.Size = new Size(279, 30);
            lbl2_fee.TabIndex = 2;
            lbl2_fee.Text = "2.000đ";
            lbl2_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(panel13, 2, 2);
            tableLayoutPanel2.Controls.Add(panel12, 1, 2);
            tableLayoutPanel2.Controls.Add(panel11, 0, 2);
            tableLayoutPanel2.Controls.Add(panel10, 2, 1);
            tableLayoutPanel2.Controls.Add(panel9, 1, 1);
            tableLayoutPanel2.Controls.Add(panel8, 0, 1);
            tableLayoutPanel2.Controls.Add(panel7, 2, 0);
            tableLayoutPanel2.Controls.Add(panel6, 0, 0);
            tableLayoutPanel2.Controls.Add(panel2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(328, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(893, 517);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // panel13
            // 
            panel13.BackColor = Color.White;
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Controls.Add(lbl9Title);
            panel13.Controls.Add(lbl9_fee);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(602, 352);
            panel13.Margin = new Padding(8);
            panel13.Name = "panel13";
            panel13.Size = new Size(283, 157);
            panel13.TabIndex = 9;
            // 
            // lbl9Title
            // 
            lbl9Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl9Title.Dock = DockStyle.Fill;
            lbl9Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl9Title.ForeColor = Color.White;
            lbl9Title.Location = new Point(0, 0);
            lbl9Title.Margin = new Padding(4, 0, 4, 0);
            lbl9Title.Name = "lbl9Title";
            lbl9Title.Padding = new Padding(0, 16, 0, 0);
            lbl9Title.Size = new Size(281, 125);
            lbl9Title.TabIndex = 1;
            lbl9Title.Text = "Xe tải có trọng tải 10 đến18 tấn\r\nXe chở hàng bằng container\r\n";
            lbl9Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl9_fee
            // 
            lbl9_fee.Dock = DockStyle.Bottom;
            lbl9_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl9_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl9_fee.Location = new Point(0, 125);
            lbl9_fee.Name = "lbl9_fee";
            lbl9_fee.Size = new Size(281, 30);
            lbl9_fee.TabIndex = 2;
            lbl9_fee.Text = "80.000đ";
            lbl9_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            panel12.BackColor = Color.White;
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(lbl8Title);
            panel12.Controls.Add(lbl8_fee);
            panel12.Dock = DockStyle.Fill;
            panel12.Location = new Point(305, 352);
            panel12.Margin = new Padding(8);
            panel12.Name = "panel12";
            panel12.Size = new Size(281, 157);
            panel12.TabIndex = 8;
            // 
            // lbl8Title
            // 
            lbl8Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl8Title.Dock = DockStyle.Fill;
            lbl8Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl8Title.ForeColor = Color.White;
            lbl8Title.Location = new Point(0, 0);
            lbl8Title.Margin = new Padding(4, 0, 4, 0);
            lbl8Title.Name = "lbl8Title";
            lbl8Title.Padding = new Padding(0, 16, 0, 0);
            lbl8Title.Size = new Size(279, 125);
            lbl8Title.TabIndex = 1;
            lbl8Title.Text = "Xe ô tô trên 31 chỗ\r\nXe tải có trọng tải 4 đến dưới 10 tấn";
            lbl8Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl8_fee
            // 
            lbl8_fee.Dock = DockStyle.Bottom;
            lbl8_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl8_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl8_fee.Location = new Point(0, 125);
            lbl8_fee.Name = "lbl8_fee";
            lbl8_fee.Size = new Size(279, 30);
            lbl8_fee.TabIndex = 2;
            lbl8_fee.Text = "50.000đ";
            lbl8_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            panel11.BackColor = Color.White;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(lbl7Title);
            panel11.Controls.Add(lbl7_fee);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(8, 352);
            panel11.Margin = new Padding(8);
            panel11.Name = "panel11";
            panel11.Size = new Size(281, 157);
            panel11.TabIndex = 7;
            // 
            // lbl7Title
            // 
            lbl7Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl7Title.Dock = DockStyle.Fill;
            lbl7Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl7Title.ForeColor = Color.White;
            lbl7Title.Location = new Point(0, 0);
            lbl7Title.Margin = new Padding(4, 0, 4, 0);
            lbl7Title.Name = "lbl7Title";
            lbl7Title.Padding = new Padding(0, 16, 0, 0);
            lbl7Title.Size = new Size(279, 125);
            lbl7Title.TabIndex = 1;
            lbl7Title.Text = "Xe ô tô 12 đến 30 chỗ\r\nXe tải có trọng tải 2 đến dưới 4 tấn";
            lbl7Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl7_fee
            // 
            lbl7_fee.Dock = DockStyle.Bottom;
            lbl7_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl7_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl7_fee.Location = new Point(0, 125);
            lbl7_fee.Name = "lbl7_fee";
            lbl7_fee.Size = new Size(279, 30);
            lbl7_fee.TabIndex = 2;
            lbl7_fee.Text = "40.000đ";
            lbl7_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(lbl6Title);
            panel10.Controls.Add(lbl6_fee);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(602, 180);
            panel10.Margin = new Padding(8);
            panel10.Name = "panel10";
            panel10.Size = new Size(283, 156);
            panel10.TabIndex = 6;
            // 
            // lbl6Title
            // 
            lbl6Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl6Title.Dock = DockStyle.Fill;
            lbl6Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl6Title.ForeColor = Color.White;
            lbl6Title.Location = new Point(0, 0);
            lbl6Title.Margin = new Padding(4, 0, 4, 0);
            lbl6Title.Name = "lbl6Title";
            lbl6Title.Padding = new Padding(0, 16, 0, 0);
            lbl6Title.Size = new Size(281, 124);
            lbl6Title.TabIndex = 1;
            lbl6Title.Text = "Xe ô tô 07, 09 chỗ\r\nXe tải có trọng tải 1 đến dưới 2 tấn";
            lbl6Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl6_fee
            // 
            lbl6_fee.Dock = DockStyle.Bottom;
            lbl6_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl6_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl6_fee.Location = new Point(0, 124);
            lbl6_fee.Name = "lbl6_fee";
            lbl6_fee.Size = new Size(281, 30);
            lbl6_fee.TabIndex = 2;
            lbl6_fee.Text = "30.000đ";
            lbl6_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(lbl5Title);
            panel9.Controls.Add(lbl5_fee);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(305, 180);
            panel9.Margin = new Padding(8);
            panel9.Name = "panel9";
            panel9.Size = new Size(281, 156);
            panel9.TabIndex = 5;
            // 
            // lbl5Title
            // 
            lbl5Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl5Title.Dock = DockStyle.Fill;
            lbl5Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl5Title.ForeColor = Color.White;
            lbl5Title.Location = new Point(0, 0);
            lbl5Title.Margin = new Padding(4, 0, 4, 0);
            lbl5Title.Name = "lbl5Title";
            lbl5Title.Padding = new Padding(0, 16, 0, 0);
            lbl5Title.Size = new Size(279, 124);
            lbl5Title.TabIndex = 1;
            lbl5Title.Text = "Xe ô tô 4 chỗ ngồi";
            lbl5Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl5_fee
            // 
            lbl5_fee.Dock = DockStyle.Bottom;
            lbl5_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl5_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl5_fee.Location = new Point(0, 124);
            lbl5_fee.Name = "lbl5_fee";
            lbl5_fee.Size = new Size(279, 30);
            lbl5_fee.TabIndex = 2;
            lbl5_fee.Text = "25.000đ";
            lbl5_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(lbl4Title);
            panel8.Controls.Add(lbl4_fee);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(8, 180);
            panel8.Margin = new Padding(8);
            panel8.Name = "panel8";
            panel8.Size = new Size(281, 156);
            panel8.TabIndex = 4;
            // 
            // lbl4Title
            // 
            lbl4Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl4Title.Dock = DockStyle.Fill;
            lbl4Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl4Title.ForeColor = Color.White;
            lbl4Title.Location = new Point(0, 0);
            lbl4Title.Margin = new Padding(4, 0, 4, 0);
            lbl4Title.Name = "lbl4Title";
            lbl4Title.Padding = new Padding(0, 16, 0, 0);
            lbl4Title.Size = new Size(279, 124);
            lbl4Title.TabIndex = 1;
            lbl4Title.Text = "Xe tải dưới 1 Tấn";
            lbl4Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl4_fee
            // 
            lbl4_fee.Dock = DockStyle.Bottom;
            lbl4_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl4_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl4_fee.Location = new Point(0, 124);
            lbl4_fee.Name = "lbl4_fee";
            lbl4_fee.Size = new Size(279, 30);
            lbl4_fee.TabIndex = 2;
            lbl4_fee.Text = "10.000đ";
            lbl4_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(lbl3Title);
            panel7.Controls.Add(lbl3_fee);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(602, 8);
            panel7.Margin = new Padding(8);
            panel7.Name = "panel7";
            panel7.Size = new Size(283, 156);
            panel7.TabIndex = 3;
            // 
            // lbl3Title
            // 
            lbl3Title.BackColor = Color.FromArgb(71, 136, 199);
            lbl3Title.Dock = DockStyle.Fill;
            lbl3Title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl3Title.ForeColor = Color.White;
            lbl3Title.Location = new Point(0, 0);
            lbl3Title.Margin = new Padding(8);
            lbl3Title.Name = "lbl3Title";
            lbl3Title.Padding = new Padding(0, 16, 0, 0);
            lbl3Title.Size = new Size(281, 124);
            lbl3Title.TabIndex = 1;
            lbl3Title.Text = "Xe mô tô 02, 03 bánh,\r\nXe ba gác, xe thô sơ,...";
            lbl3Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl3_fee
            // 
            lbl3_fee.Dock = DockStyle.Bottom;
            lbl3_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl3_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl3_fee.Location = new Point(0, 124);
            lbl3_fee.Name = "lbl3_fee";
            lbl3_fee.Size = new Size(281, 30);
            lbl3_fee.TabIndex = 2;
            lbl3_fee.Text = "5.000đ";
            lbl3_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(lbl1_title);
            panel6.Controls.Add(lbl1_fee);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(8, 8);
            panel6.Margin = new Padding(8);
            panel6.Name = "panel6";
            panel6.Size = new Size(281, 156);
            panel6.TabIndex = 2;
            // 
            // lbl1_title
            // 
            lbl1_title.BackColor = Color.FromArgb(71, 136, 199);
            lbl1_title.Dock = DockStyle.Fill;
            lbl1_title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbl1_title.ForeColor = Color.White;
            lbl1_title.Location = new Point(0, 0);
            lbl1_title.Margin = new Padding(4, 0, 4, 0);
            lbl1_title.Name = "lbl1_title";
            lbl1_title.Padding = new Padding(0, 16, 0, 0);
            lbl1_title.Size = new Size(279, 124);
            lbl1_title.TabIndex = 1;
            lbl1_title.Text = "Xe đạp (Xe đạp điện)\r\nXe đẩy";
            lbl1_title.TextAlign = ContentAlignment.TopCenter;
            // 
            // lbl1_fee
            // 
            lbl1_fee.Dock = DockStyle.Bottom;
            lbl1_fee.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbl1_fee.ForeColor = Color.FromArgb(71, 136, 199);
            lbl1_fee.Location = new Point(0, 124);
            lbl1_fee.Name = "lbl1_fee";
            lbl1_fee.Size = new Size(279, 30);
            lbl1_fee.TabIndex = 2;
            lbl1_fee.Text = "1.000đ";
            lbl1_fee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(picQR);
            panel4.Controls.Add(lblFee);
            panel4.Controls.Add(lblTime);
            panel4.Controls.Add(lblDetectPlate);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(328, 517);
            panel4.Name = "panel4";
            panel4.Size = new Size(893, 174);
            panel4.TabIndex = 2;
            // 
            // picQR
            // 
            picQR.BackColor = SystemColors.ControlLight;
            picQR.Location = new Point(9, 6);
            picQR.Name = "picQR";
            picQR.Size = new Size(173, 164);
            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            picQR.TabIndex = 6;
            picQR.TabStop = false;
            // 
            // lblFee
            // 
            lblFee.AutoSize = true;
            lblFee.Font = new Font("Segoe UI", 24F);
            lblFee.ForeColor = Color.DarkRed;
            lblFee.Location = new Point(310, 111);
            lblFee.Name = "lblFee";
            lblFee.Size = new Size(121, 45);
            lblFee.TabIndex = 5;
            lblFee.Text = "_ _ _ _ _";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 16F);
            lblTime.Location = new Point(310, 72);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(82, 30);
            lblTime.TabIndex = 4;
            lblTime.Text = "_ _ _ _ _";
            // 
            // lblDetectPlate
            // 
            lblDetectPlate.AutoSize = true;
            lblDetectPlate.Font = new Font("Segoe UI", 16F);
            lblDetectPlate.Location = new Point(310, 23);
            lblDetectPlate.Name = "lblDetectPlate";
            lblDetectPlate.Size = new Size(82, 30);
            lblDetectPlate.TabIndex = 3;
            lblDetectPlate.Text = "_ _ _ _ _";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label3.Location = new Point(189, 111);
            label3.Name = "label3";
            label3.Size = new Size(77, 45);
            label3.TabIndex = 2;
            label3.Text = "Phí:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(188, 72);
            label2.Name = "label2";
            label2.Size = new Size(116, 30);
            label2.TabIndex = 2;
            label2.Text = "Thời gian:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(188, 23);
            label1.Name = "label1";
            label1.Size = new Size(123, 30);
            label1.TabIndex = 2;
            label1.Text = "Biển số xe:";
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(5, 174);
            panel5.TabIndex = 1;
            // 
            // timerGetToken
            // 
            timerGetToken.Enabled = true;
            timerGetToken.Interval = 60000;
            // 
            // frmDemo
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1221, 691);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmDemo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Demo";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panelLprCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLpr).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
        private Label label2;
        private Label label1;
        private Panel panel5;
        private PictureBox picLpr;
        private Label lblFee;
        private Label lblTime;
        private Label lblDetectPlate;
        private Label label3;
        private Panel panelCamera;
        private Panel panelLprCamera;
        private Label lbl2Title;
        private Panel panel13;
        private Label lbl9Title;
        private Panel panel12;
        private Label lbl8Title;
        private Panel panel11;
        private Label lbl7Title;
        private Panel panel10;
        private Label lbl6Title;
        private Panel panel9;
        private Label lbl5Title;
        private Panel panel8;
        private Label lbl4Title;
        private Panel panel7;
        private Label lbl3Title;
        private Panel panel6;
        private Label lbl1_title;
        private Label lbl2_fee;
        private Label lbl9_fee;
        private Label lbl8_fee;
        private Label lbl7_fee;
        private Label lbl6_fee;
        private Label lbl5_fee;
        private Label lbl4_fee;
        private Label lbl3_fee;
        private Label lbl1_fee;
        private PictureBox picQR;
        private System.Windows.Forms.Timer timerGetToken;
    }
}