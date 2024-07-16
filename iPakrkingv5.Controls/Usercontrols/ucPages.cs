using iPakrkingv5.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.ToggleDoubleBuffered(true);
            panelPages.ToggleDoubleBuffered(true);
            panelPages.Font = new Font(this.Font, FontStyle.Underline);
            panelPages.Height = 44;
            panelPages.MinimumSize = new Size(0, 44);
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
            Control[] list = new Control[maxPage];
            for (int i = 0; i < maxPage; i++)
            {
                lblPageIndex lblPageIndex = new lblPageIndex(maxPage - i);
                lblPageIndex.Click += LblPageIndex_Click;
                lblPageIndex.Dock = DockStyle.Left;
                //lblPageIndex.BackColor = Color.Transparent;
                if (i == maxPage - 1)
                {
                    lblPageIndex.BorderStyle = BorderStyle.Fixed3D;
                    lblPageIndex.ForeColor = Color.FromArgb(253, 149, 40);
                }
                list[i] = lblPageIndex;
            }
            panelPages.Controls.AddRange(list.ToArray());
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
                        item.ForeColor = Color.Black;
                    }
                    break;
                }
            }
            lblPageIndex.BorderStyle = BorderStyle.Fixed3D;
            lblPageIndex.ForeColor = Color.FromArgb(253, 149, 40);
            lblPageIndex.Size = lblPageIndex.PreferredSize;
            panelPages.Refresh();
            OnpageSelect?.Invoke(lblPageIndex!.PageIndex);
        }
        #endregion End Public Function
    }
}
