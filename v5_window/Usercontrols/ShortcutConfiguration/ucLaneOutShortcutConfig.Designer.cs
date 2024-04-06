using iPakrkingv5.Controls.Controls.Buttons;
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
            picChangeConfirmPlateKey = new BtnSetting();
            picWriteOut = new BtnSetting();
            picReserveLane = new BtnSetting();
            picReSnapshot = new BtnSetting();
            lblReSnapshotLaneKey = new Label();
            label4 = new Label();
            label5 = new Label();
            lblPrintKey = new Label();
            picPrint = new BtnSetting();
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
            lblConfirmPlateKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
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
            lblWriteOutKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
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
            lblReserveLaneKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
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
            picChangeConfirmPlateKey.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
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
            picWriteOut.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
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
            picReserveLane.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            picReserveLane.ForeColor = Color.Black;
            picReserveLane.Image = (Image)resources.GetObject("picReserveLane.Image");
            picReserveLane.Location = new Point(465, 105);
            picReserveLane.Name = "picReserveLane";
            picReserveLane.Size = new Size(55, 38);
            picReserveLane.TabIndex = 5;
            picReserveLane.Text = " ";
            // 
            // picReSnapshot
            // 
            picReSnapshot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picReSnapshot.AutoSize = true;
            picReSnapshot.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            picReSnapshot.ForeColor = Color.Black;
            picReSnapshot.Image = (Image)resources.GetObject("picReSnapshot.Image");
            picReSnapshot.Location = new Point(465, 146);
            picReSnapshot.Name = "picReSnapshot";
            picReSnapshot.Size = new Size(55, 38);
            picReSnapshot.TabIndex = 8;
            picReSnapshot.Text = " ";
            // 
            // lblReSnapshotLaneKey
            // 
            lblReSnapshotLaneKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblReSnapshotLaneKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            lblReSnapshotLaneKey.ForeColor = Color.Navy;
            lblReSnapshotLaneKey.Location = new Point(160, 146);
            lblReSnapshotLaneKey.Name = "lblReSnapshotLaneKey";
            lblReSnapshotLaneKey.Size = new Size(291, 34);
            lblReSnapshotLaneKey.TabIndex = 7;
            lblReSnapshotLaneKey.Text = "label4";
            lblReSnapshotLaneKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 155);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 6;
            label4.Text = "Chụp lại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 202);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 6;
            label5.Text = "In Vé Xe";
            // 
            // lblPrintKey
            // 
            lblPrintKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPrintKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            lblPrintKey.ForeColor = Color.Navy;
            lblPrintKey.Location = new Point(160, 193);
            lblPrintKey.Name = "lblPrintKey";
            lblPrintKey.Size = new Size(291, 34);
            lblPrintKey.TabIndex = 7;
            lblPrintKey.Text = "label4";
            lblPrintKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // picPrint
            // 
            picPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picPrint.AutoSize = true;
            picPrint.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            picPrint.ForeColor = Color.Black;
            picPrint.Image = (Image)resources.GetObject("picPrint.Image");
            picPrint.Location = new Point(465, 193);
            picPrint.Name = "picPrint";
            picPrint.Size = new Size(55, 38);
            picPrint.TabIndex = 8;
            picPrint.Text = " ";
            // 
            // ucLaneOutShortcutConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(picPrint);
            Controls.Add(picReSnapshot);
            Controls.Add(lblPrintKey);
            Controls.Add(label5);
            Controls.Add(lblReSnapshotLaneKey);
            Controls.Add(label4);
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
            Size = new Size(523, 281);
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
        private BtnSetting picChangeConfirmPlateKey;
        private BtnSetting picWriteOut;
        private BtnSetting picReserveLane;
        private BtnSetting picReSnapshot;
        private Label lblReSnapshotLaneKey;
        private Label label4;
        private Label label5;
        private Label lblPrintKey;
        private BtnSetting picPrint;
    }
}
