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
            button1 = new Button();
            btnCusomerRegiser = new Button();
            btnRegisterFingerPrint = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(282, 37);
            button1.Name = "button1";
            button1.Size = new Size(205, 165);
            button1.TabIndex = 0;
            button1.Text = "Nạp vân tay";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnCusomerRegiser
            // 
            btnCusomerRegiser.Location = new Point(60, 37);
            btnCusomerRegiser.Name = "btnCusomerRegiser";
            btnCusomerRegiser.Size = new Size(184, 165);
            btnCusomerRegiser.TabIndex = 0;
            btnCusomerRegiser.Text = "Đăng ký khách hàng";
            btnCusomerRegiser.UseVisualStyleBackColor = true;
            btnCusomerRegiser.Click += btnCusomerRegiser_Click;
            // 
            // btnRegisterFingerPrint
            // 
            btnRegisterFingerPrint.Location = new Point(60, 223);
            btnRegisterFingerPrint.Name = "btnRegisterFingerPrint";
            btnRegisterFingerPrint.Size = new Size(184, 165);
            btnRegisterFingerPrint.TabIndex = 0;
            btnRegisterFingerPrint.Text = "Đăng ký vân tay";
            btnRegisterFingerPrint.UseVisualStyleBackColor = true;
            btnRegisterFingerPrint.Click += btnRegisterFingerPrint_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegisterFingerPrint);
            Controls.Add(btnCusomerRegiser);
            Controls.Add(button1);
            Name = "frmMain";
            Text = "frmMain";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnCusomerRegiser;
        private Button btnRegisterFingerPrint;
    }
}