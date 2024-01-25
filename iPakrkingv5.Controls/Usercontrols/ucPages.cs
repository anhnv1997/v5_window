namespace iPakrkingv5.Controls.Usercontrols
{
    public delegate void OnpageSelect(int pageIndex);
    public partial class ucPages : UserControl
    {
        #region Properties
        private int maxPage = 0;
        private int currentPage = 0;
        public event OnpageSelect OnpageSelect;
        #endregion

        #region Forms
        public ucPages()
        {
            InitializeComponent();
            panelPages.Font = new Font(this.Font, FontStyle.Underline);
            panelPages.Height = 44;
            panelPages.MinimumSize = new System.Drawing.Size(0, 44);
        }
        #endregion End Forms

        #region Public Function
        public void UpdateMaxPage(int maxPage)
        {
            this.SuspendLayout();
            panelPages.SuspendLayout();
            this.maxPage = maxPage;
            foreach (Control item in panelPages.Controls)
            {
                if (item is lblPageIndex lbl)
                {
                    lbl.Click -= LblPageIndex_Click;
                    lbl.Dispose();
                }
            }

            panelPages.Controls.Clear();
            panelPages.AutoScroll = false;
            for (int i = 0; i < maxPage; i++)
            {
                lblPageIndex lblPageIndex = new lblPageIndex(i + 1);
                lblPageIndex.BackColor = Color.Transparent;
                lblPageIndex.Click += LblPageIndex_Click;
                panelPages.Controls.Add(lblPageIndex);
                lblPageIndex.Dock = DockStyle.Left;
                lblPageIndex.BringToFront();
                if (i == 0)
                {
                    lblPageIndex.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            currentPage = 0;
            panelPages.AutoScroll = true;
            this.Height = panelPages.Height;
            this.ResumeLayout();
            panelPages.ResumeLayout();
        }

        private void LblPageIndex_Click(object? sender, EventArgs e)
        {
            lblPageIndex lblPageIndex = (sender as lblPageIndex)!;
            foreach (lblPageIndex item in panelPages.Controls)
            {
                if (item.BorderStyle == BorderStyle.Fixed3D)
                {
                    if (currentPage != lblPageIndex.PageIndex)
                    {
                        item.BorderStyle = BorderStyle.None;
                    }
                    break;
                }
            }
            lblPageIndex.BorderStyle = BorderStyle.Fixed3D;
            lblPageIndex.Size = lblPageIndex.PreferredSize;
            panelPages.Refresh();
            OnpageSelect?.Invoke(lblPageIndex!.PageIndex);
        }
        #endregion End Public Function
    }
}
