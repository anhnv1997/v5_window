namespace iPakrkingv5.Controls.Usercontrols
{
    partial class ucPages
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
            panelPages = new Panel();
            SuspendLayout();
            // 
            // panelPages
            // 
            panelPages.AutoScroll = true;
            panelPages.Dock = DockStyle.Fill;
            panelPages.Location = new Point(0, 0);
            panelPages.Margin = new Padding(4, 3, 4, 3);
            panelPages.Name = "panelPages";
            panelPages.Size = new Size(693, 43);
            panelPages.TabIndex = 0;
            // 
            // ucPages
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(panelPages);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucPages";
            Size = new Size(693, 43);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPages;
    }
}
