using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Usercontrols
{
    public class lblPageIndex : Label
    {
        public int PageIndex { get; set; }
        public lblPageIndex(int index)
        {
            this.PageIndex = index;
            this.Text = index.ToString();
            //this.Font = new Font(this.Font, FontStyle.Underline);
            //this.ForeColor = Color.Navy;
            this.AutoSize = false;
            this.Padding = new Padding(3);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = this.PreferredWidth;
            this.Height = this.PreferredHeight;
            this.MouseEnter += LblPageIndex_MouseEnter;
            this.MouseLeave += LblPageIndex_MouseLeave;
        }

        private void LblPageIndex_MouseLeave(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void LblPageIndex_MouseEnter(object? sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
