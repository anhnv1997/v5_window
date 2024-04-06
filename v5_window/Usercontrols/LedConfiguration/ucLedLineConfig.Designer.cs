
using iPakrkingv5.Controls.Controls.Buttons;

namespace iParkingv5_window.Usercontrols
{
    partial class ucLedLineConfig
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
            lblStepName = new Label();
            panel2 = new Panel();
            label2 = new Label();
            numDelayTime = new NumericUpDown();
            label1 = new Label();
            btnCancel1 = new BtnDelete();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDelayTime).BeginInit();
            SuspendLayout();
            // 
            // lblStepName
            // 
            lblStepName.BorderStyle = BorderStyle.Fixed3D;
            lblStepName.Dock = DockStyle.Left;
            lblStepName.Location = new Point(0, 0);
            lblStepName.Name = "lblStepName";
            lblStepName.Size = new Size(68, 92);
            lblStepName.TabIndex = 1;
            lblStepName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(numDelayTime);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(68, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 5, 0, 0);
            panel2.Size = new Size(332, 38);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Right;
            label2.Location = new Point(289, 5);
            label2.Name = "label2";
            label2.Size = new Size(43, 33);
            label2.TabIndex = 2;
            label2.Text = "ms";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numDelayTime
            // 
            numDelayTime.Dock = DockStyle.Fill;
            numDelayTime.Location = new Point(71, 5);
            numDelayTime.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numDelayTime.Name = "numDelayTime";
            numDelayTime.Size = new Size(261, 27);
            numDelayTime.TabIndex = 1;
            numDelayTime.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 5);
            label1.Name = "label1";
            label1.Size = new Size(71, 33);
            label1.TabIndex = 0;
            label1.Text = "Delay";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel1
            // 
            btnCancel1.AutoSize = true;
            btnCancel1.Dock = DockStyle.Right;
            btnCancel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnCancel1.ForeColor = Color.Black;
            btnCancel1.Location = new Point(400, 0);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(46, 92);
            btnCancel1.TabIndex = 3;
            btnCancel1.Text = "Xóa";
            // 
            // ucLedLineConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panel2);
            Controls.Add(lblStepName);
            Controls.Add(btnCancel1);
            Margin = new Padding(0);
            Name = "ucLedLineConfig";
            Size = new Size(446, 92);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDelayTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblStepName;
        private Panel panel2;
        private Label label2;
        private NumericUpDown numDelayTime;
        private Label label1;
        private BtnDelete btnCancel1;
    }
}
