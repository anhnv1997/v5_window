namespace iPakrkingv5.Controls.Usercontrols
{
    public class lblPageIndex : Label
    {
        public int PageIndex { get; set; }
        public lblPageIndex(int index)
        {
            this.PageIndex = index;
            this.Text = index.ToString();
            this.ForeColor = Color.Navy;
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
