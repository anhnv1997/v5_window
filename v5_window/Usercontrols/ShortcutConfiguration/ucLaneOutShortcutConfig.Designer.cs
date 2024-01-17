using System.Windows.Forms;
using System.Xml.Linq;

namespace iParkingv5_window.Usercontrols.ShortcutConfiguration
{
    partial class ucLaneOutShortcutConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLaneOutShortcutConfig));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblConfirmPlateKey = new Label();
            lblWriteOutKey = new Label();
            lblReserveLaneKey = new Label();
            picChangeConfirmPlateKey = new Controls.Buttons.LblSetting();
            picWriteOut = new Controls.Buttons.LblSetting();
            picReserveLane = new Controls.Buttons.LblSetting();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 28);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Xác nhận sửa biển số";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 73);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 0;
            label2.Text = "Ghi vé ra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 114);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 0;
            label3.Text = "Đảo làn";
            // 
            // lblConfirmPlateKey
            // 
            lblConfirmPlateKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblConfirmPlateKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblConfirmPlateKey.ForeColor = Color.Navy;
            lblConfirmPlateKey.Location = new Point(171, 20);
            lblConfirmPlateKey.Name = "lblConfirmPlateKey";
            lblConfirmPlateKey.Size = new Size(280, 34);
            lblConfirmPlateKey.TabIndex = 1;
            lblConfirmPlateKey.Text = "label4";
            lblConfirmPlateKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWriteOutKey
            // 
            lblWriteOutKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWriteOutKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblWriteOutKey.ForeColor = Color.Navy;
            lblWriteOutKey.Location = new Point(171, 65);
            lblWriteOutKey.Name = "lblWriteOutKey";
            lblWriteOutKey.Size = new Size(280, 34);
            lblWriteOutKey.TabIndex = 1;
            lblWriteOutKey.Text = "label4";
            lblWriteOutKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblReserveLaneKey
            // 
            lblReserveLaneKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblReserveLaneKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblReserveLaneKey.ForeColor = Color.Navy;
            lblReserveLaneKey.Location = new Point(171, 106);
            lblReserveLaneKey.Name = "lblReserveLaneKey";
            lblReserveLaneKey.Size = new Size(280, 34);
            lblReserveLaneKey.TabIndex = 1;
            lblReserveLaneKey.Text = "label4";
            lblReserveLaneKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // picChangeConfirmPlateKey
            // 
            picChangeConfirmPlateKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picChangeConfirmPlateKey.AutoSize = true;
            picChangeConfirmPlateKey.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            picChangeConfirmPlateKey.ForeColor = Color.Black;
            picChangeConfirmPlateKey.Image = (Image)resources.GetObject("picChangeConfirmPlateKey.Image");
            picChangeConfirmPlateKey.Location = new Point(465, 19);
            picChangeConfirmPlateKey.Name = "picChangeConfirmPlateKey";
            picChangeConfirmPlateKey.Size = new Size(55, 38);
            picChangeConfirmPlateKey.TabIndex = 3;
            picChangeConfirmPlateKey.Text = " ";
            // 
            // picWriteOut
            // 
            picWriteOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picWriteOut.AutoSize = true;
            picWriteOut.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            picWriteOut.ForeColor = Color.Black;
            picWriteOut.Image = (Image)resources.GetObject("picWriteOut.Image");
            picWriteOut.Location = new Point(465, 61);
            picWriteOut.Name = "picWriteOut";
            picWriteOut.Size = new Size(55, 38);
            picWriteOut.TabIndex = 4;
            picWriteOut.Text = " ";
            // 
            // picReserveLane
            // 
            picReserveLane.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picReserveLane.AutoSize = true;
            picReserveLane.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            picReserveLane.ForeColor = Color.Black;
            picReserveLane.Image = (Image)resources.GetObject("picReserveLane.Image");
            picReserveLane.Location = new Point(465, 105);
            picReserveLane.Name = "picReserveLane";
            picReserveLane.Size = new Size(55, 38);
            picReserveLane.TabIndex = 5;
            picReserveLane.Text = " ";
            // 
            // ucLaneOutShortcutConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(picReserveLane);
            Controls.Add(picWriteOut);
            Controls.Add(picChangeConfirmPlateKey);
            Controls.Add(lblReserveLaneKey);
            Controls.Add(lblWriteOutKey);
            Controls.Add(lblConfirmPlateKey);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucLaneOutShortcutConfig";
            Size = new Size(523, 155);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblConfirmPlateKey;
        private Label lblWriteOutKey;
        private Label lblReserveLaneKey;
        private Controls.Buttons.LblSetting picChangeConfirmPlateKey;
        private Controls.Buttons.LblSetting picWriteOut;
        private Controls.Buttons.LblSetting picReserveLane;
    }
}
