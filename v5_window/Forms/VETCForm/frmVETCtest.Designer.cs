namespace iParkingv5_window.Forms.VETCForm
{
    partial class frmVETCtest
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
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.txbEtagSocket = new System.Windows.Forms.TextBox();
            this.btnCheckConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFakeEtag = new System.Windows.Forms.Button();
            this.txbEtag = new System.Windows.Forms.TextBox();
            this.btnGetAllEtag = new System.Windows.Forms.Button();
            this.btnConfigPayment = new System.Windows.Forms.Button();
            this.btnTriggerPayment = new System.Windows.Forms.Button();
            this.btnCheckTransaction = new System.Windows.Forms.Button();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnGenQR = new System.Windows.Forms.Button();
            this.txbQR = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(12, 77);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(110, 48);
            this.btnCheckOut.TabIndex = 0;
            this.btnCheckOut.Text = "CheckOut";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // txbEtagSocket
            // 
            this.txbEtagSocket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEtagSocket.Location = new System.Drawing.Point(320, 65);
            this.txbEtagSocket.Multiline = true;
            this.txbEtagSocket.Name = "txbEtagSocket";
            this.txbEtagSocket.Size = new System.Drawing.Size(388, 141);
            this.txbEtagSocket.TabIndex = 1;
            // 
            // btnCheckConnect
            // 
            this.btnCheckConnect.Location = new System.Drawing.Point(12, 12);
            this.btnCheckConnect.Name = "btnCheckConnect";
            this.btnCheckConnect.Size = new System.Drawing.Size(87, 28);
            this.btnCheckConnect.TabIndex = 0;
            this.btnCheckConnect.Text = "CheckConnet";
            this.btnCheckConnect.UseVisualStyleBackColor = true;
            this.btnCheckConnect.Click += new System.EventHandler(this.btnCheckConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnFakeEtag
            // 
            this.btnFakeEtag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFakeEtag.Location = new System.Drawing.Point(320, 20);
            this.btnFakeEtag.Name = "btnFakeEtag";
            this.btnFakeEtag.Size = new System.Drawing.Size(97, 28);
            this.btnFakeEtag.TabIndex = 0;
            this.btnFakeEtag.Text = "Fake Etag";
            this.btnFakeEtag.UseVisualStyleBackColor = true;
            this.btnFakeEtag.Click += new System.EventHandler(this.btnFakeEtag_Click);
            // 
            // txbEtag
            // 
            this.txbEtag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEtag.Location = new System.Drawing.Point(423, 24);
            this.txbEtag.Name = "txbEtag";
            this.txbEtag.Size = new System.Drawing.Size(236, 23);
            this.txbEtag.TabIndex = 3;
            // 
            // btnGetAllEtag
            // 
            this.btnGetAllEtag.Location = new System.Drawing.Point(12, 139);
            this.btnGetAllEtag.Name = "btnGetAllEtag";
            this.btnGetAllEtag.Size = new System.Drawing.Size(110, 48);
            this.btnGetAllEtag.TabIndex = 0;
            this.btnGetAllEtag.Text = "GetAllEtag";
            this.btnGetAllEtag.UseVisualStyleBackColor = true;
            this.btnGetAllEtag.Click += new System.EventHandler(this.btnGetAllEtag_Click);
            // 
            // btnConfigPayment
            // 
            this.btnConfigPayment.Location = new System.Drawing.Point(12, 201);
            this.btnConfigPayment.Name = "btnConfigPayment";
            this.btnConfigPayment.Size = new System.Drawing.Size(110, 48);
            this.btnConfigPayment.TabIndex = 0;
            this.btnConfigPayment.Text = "ConfigPayment";
            this.btnConfigPayment.UseVisualStyleBackColor = true;
            this.btnConfigPayment.Click += new System.EventHandler(this.btnConfigPayment_Click);
            // 
            // btnTriggerPayment
            // 
            this.btnTriggerPayment.Location = new System.Drawing.Point(12, 263);
            this.btnTriggerPayment.Name = "btnTriggerPayment";
            this.btnTriggerPayment.Size = new System.Drawing.Size(110, 48);
            this.btnTriggerPayment.TabIndex = 0;
            this.btnTriggerPayment.Text = "Trigger Payment";
            this.btnTriggerPayment.UseVisualStyleBackColor = true;
            this.btnTriggerPayment.Click += new System.EventHandler(this.btnTriggerPayment_Click);
            // 
            // btnCheckTransaction
            // 
            this.btnCheckTransaction.Location = new System.Drawing.Point(12, 325);
            this.btnCheckTransaction.Name = "btnCheckTransaction";
            this.btnCheckTransaction.Size = new System.Drawing.Size(110, 48);
            this.btnCheckTransaction.TabIndex = 0;
            this.btnCheckTransaction.Text = "Check Transaction";
            this.btnCheckTransaction.UseVisualStyleBackColor = true;
            this.btnCheckTransaction.Click += new System.EventHandler(this.btnCheckTransaction_Click);
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(347, 263);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(361, 226);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 6;
            this.picQR.TabStop = false;
            // 
            // btnGenQR
            // 
            this.btnGenQR.Location = new System.Drawing.Point(150, 226);
            this.btnGenQR.Name = "btnGenQR";
            this.btnGenQR.Size = new System.Drawing.Size(75, 23);
            this.btnGenQR.TabIndex = 5;
            this.btnGenQR.Text = "GenQR";
            this.btnGenQR.UseVisualStyleBackColor = true;
            this.btnGenQR.Click += new System.EventHandler(this.btnGenQR_Click);
            // 
            // txbQR
            // 
            this.txbQR.Location = new System.Drawing.Point(150, 263);
            this.txbQR.Multiline = true;
            this.txbQR.Name = "txbQR";
            this.txbQR.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbQR.Size = new System.Drawing.Size(168, 226);
            this.txbQR.TabIndex = 4;
            // 
            // frmVETCtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 524);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.btnGenQR);
            this.Controls.Add(this.txbQR);
            this.Controls.Add(this.txbEtag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbEtagSocket);
            this.Controls.Add(this.btnCheckConnect);
            this.Controls.Add(this.btnFakeEtag);
            this.Controls.Add(this.btnCheckTransaction);
            this.Controls.Add(this.btnTriggerPayment);
            this.Controls.Add(this.btnConfigPayment);
            this.Controls.Add(this.btnGetAllEtag);
            this.Controls.Add(this.btnCheckOut);
            this.Name = "frmVETCtest";
            this.Text = "frmVETCtest";
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCheckOut;
        private TextBox txbEtagSocket;
        private Button btnCheckConnect;
        private Label label1;
        private Button btnFakeEtag;
        private TextBox txbEtag;
        private Button btnGetAllEtag;
        private Button btnConfigPayment;
        private Button btnTriggerPayment;
        private Button btnCheckTransaction;
        private PictureBox picQR;
        private Button btnGenQR;
        private TextBox txbQR;
    }
}