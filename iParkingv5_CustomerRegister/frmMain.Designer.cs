namespace iParkingv5_CustomerRegister
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            button1 = new Button();
            btnCusomerRegiser = new Button();
            btnRegisterFingerPrint = new Button();
            btnVehicle = new Button();
            lblEventMonitor = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(415, 227);
            button1.Name = "button1";
            button1.Size = new Size(205, 165);
            button1.TabIndex = 3;
            button1.Text = "Thiết bị";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += frmDevice_Click;
            // 
            // btnCusomerRegiser
            // 
            btnCusomerRegiser.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnCusomerRegiser.Image = (Image)resources.GetObject("btnCusomerRegiser.Image");
            btnCusomerRegiser.Location = new Point(181, 35);
            btnCusomerRegiser.Name = "btnCusomerRegiser";
            btnCusomerRegiser.Size = new Size(198, 165);
            btnCusomerRegiser.TabIndex = 0;
            btnCusomerRegiser.Text = "Khách hàng";
            btnCusomerRegiser.TextAlign = ContentAlignment.BottomCenter;
            btnCusomerRegiser.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCusomerRegiser.UseVisualStyleBackColor = true;
            btnCusomerRegiser.Click += btnCusomerRegiser_Click;
            // 
            // btnRegisterFingerPrint
            // 
            btnRegisterFingerPrint.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnRegisterFingerPrint.Image = (Image)resources.GetObject("btnRegisterFingerPrint.Image");
            btnRegisterFingerPrint.Location = new Point(415, 35);
            btnRegisterFingerPrint.Name = "btnRegisterFingerPrint";
            btnRegisterFingerPrint.Size = new Size(198, 165);
            btnRegisterFingerPrint.TabIndex = 2;
            btnRegisterFingerPrint.Text = "Vân tay";
            btnRegisterFingerPrint.TextAlign = ContentAlignment.BottomCenter;
            btnRegisterFingerPrint.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRegisterFingerPrint.UseVisualStyleBackColor = true;
            btnRegisterFingerPrint.Click += btnRegisterFingerPrint_Click;
            // 
            // btnVehicle
            // 
            btnVehicle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnVehicle.Image = (Image)resources.GetObject("btnVehicle.Image");
            btnVehicle.Location = new Point(181, 227);
            btnVehicle.Name = "btnVehicle";
            btnVehicle.Size = new Size(198, 165);
            btnVehicle.TabIndex = 1;
            btnVehicle.Text = "Phương tiện";
            btnVehicle.TextAlign = ContentAlignment.BottomCenter;
            btnVehicle.TextImageRelation = TextImageRelation.ImageAboveText;
            btnVehicle.UseVisualStyleBackColor = true;
            btnVehicle.Click += btnVehicle_Click;
            // 
            // lblEventMonitor
            // 
            lblEventMonitor.Dock = DockStyle.Bottom;
            lblEventMonitor.Font = new Font("Segoe UI", 13F);
            lblEventMonitor.Location = new Point(0, 438);
            lblEventMonitor.Name = "lblEventMonitor";
            lblEventMonitor.Size = new Size(800, 35);
            lblEventMonitor.TabIndex = 4;
            lblEventMonitor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(lblEventMonitor);
            Controls.Add(btnRegisterFingerPrint);
            Controls.Add(btnVehicle);
            Controls.Add(btnCusomerRegiser);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Identity Service";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnCusomerRegiser;
        private Button btnRegisterFingerPrint;
        private Button btnVehicle;
        private Label lblEventMonitor;
    }
}