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
        public event OnpageSelect OnpageSelect;

        private int maxPage = 0;
        // Expose properties to design mode
        [Browsable(true)]
        [Category("Custom maxPage")]
        [Description("Sets the text of the Label")]
        public int MaxPage
        {
            get { return maxPage; }
            set
            {
                this.maxPage = value;
                lblMaxPage.Message = value.ToString();
                this.Refresh();
            }
        }

        private int currentPage = 0;
        // Expose properties to design mode
        [Browsable(true)]
        [Category("Custom current page")]
        [Description("Sets the text of the Label")]
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (value <= 1)
                {
                    this.currentPage = 1;
                }
                else
                {
                    if (value <= maxPage)
                    {
                        this.currentPage = value;
                    }
                }
                if (this.currentPage == 1)
                {
                    EnableFirstPageMode();
                }
                else if (this.currentPage == maxPage)
                {
                    EnableLastPageMode();
                }
                else
                {
                    EnableNormalPageMode();
                }

                txtCurrentPage.Text = this.currentPage.ToString();
                txtCurrentPage.Refresh();
                OnpageSelect?.Invoke(int.Parse(txtCurrentPage.Text.Trim()));
            }
        }

        private void EnableNormalPageMode()
        {
            picLast.Enabled = true;
            picNext.Enabled = true;
            picFirst.Enabled = true;
            picBack.Enabled = true;
            picLast.BackColor = SystemColors.ButtonHighlight;
            picNext.BackColor = SystemColors.ButtonHighlight;
            picFirst.BackColor = SystemColors.ButtonHighlight;
            picBack.BackColor = SystemColors.ButtonHighlight;
        }

        private void EnableLastPageMode()
        {
            picLast.Enabled = false;
            picNext.Enabled = false;
            picFirst.Enabled = true;
            picBack.Enabled = true;
            picLast.BackColor = SystemColors.Control;
            picNext.BackColor = SystemColors.Control;
            picFirst.BackColor = SystemColors.ButtonHighlight;
            picBack.BackColor = SystemColors.ButtonHighlight;
        }

        private void EnableFirstPageMode()
        {
            picFirst.Enabled = false;
            picBack.Enabled = false;
            picLast.Enabled = true;
            picNext.Enabled = true;
            picFirst.BackColor = SystemColors.Control;
            picBack.BackColor = SystemColors.Control;
            picLast.BackColor = SystemColors.ButtonHighlight;
            picNext.BackColor = SystemColors.ButtonHighlight;
        }

        #endregion

        #region Forms
        public ucPages()
        {
            InitializeComponent();
            txtCurrentPage.KeyDown += TxtCurrentPage_KeyDown;
            this.ToggleDoubleBuffered(true);
            //panelPages.ToggleDoubleBuffered(true);
            //panelPages.Font = new Font(this.Font, FontStyle.Underline);
            //panelPages.Height = 44;
            this.BackColor = SystemColors.Control;
            this.MinimumSize = new Size(0, 44);
        }

        private void TxtCurrentPage_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int pageIndex = 0;
                int.TryParse(txtCurrentPage.Text.Trim(), out pageIndex);
                this.currentPage = pageIndex;
            }
        }
        #endregion End Forms

        #region Public Function
        public void UpdateMaxPage(int maxPage)
        {
            this.maxPage = maxPage;
            this.currentPage = 1;
            txtCurrentPage.Text = "1";
            lblMaxPage.Message = maxPage.ToString();
            EnableFirstPageMode();
        }
        #endregion End Public Function

        #region Controls In Form
        private void picNext_Click(object sender, EventArgs e)
        {
            this.CurrentPage++;
        }
        private void picLast_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.maxPage;
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.CurrentPage--;
        }
        private void picFirst_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
        }
        #endregion End Controls In Form
    }
}
