namespace ALSE.UserControls
{
    public partial class ucGridview<T> : UserControl where T : Control
    {
        private List<T> children;
        private int maxWidth;
        private double ratioHeightPerWidth;
        private int crossAxisSpacing;
        private int mainAxisSpacing;
        private int padding = 10;

        public ucGridview(int maxWidth, int crossAxisSpacing, int mainAxisSpacing, int padding = 10)
        {
            InitializeComponent();
            this.children = new List<T>();
            this.maxWidth = maxWidth;
            if (typeof(T) == typeof(ucControllerConnection))
            {
                this.ratioHeightPerWidth = ucControllerConnection.GetPreferRatio();
            }
            this.crossAxisSpacing = crossAxisSpacing;
            this.mainAxisSpacing = mainAxisSpacing;
            this.padding = padding;

            panelGridview.Padding = new Padding(padding);
            this.SuspendLayout();

            this.MinimumSize = new Size(padding * 2 + mainAxisSpacing, crossAxisSpacing);
            panelGridview.AutoScroll = true;
            this.ResumeLayout();

            this.SizeChanged += UcGridview_SizeChanged;
        }
        private void UcGridview_SizeChanged(object? sender, EventArgs? e)
        {
            this.SuspendLayout();
            if (panelGridview.VerticalScroll.Visible)
            {
                panelGridview.VerticalScroll.Value = 0;
            }

            if (panelGridview.HorizontalScroll.Visible)
            {
                panelGridview.HorizontalScroll.Value = 0;
            }

            int clientWidth = this.Width - this.padding * 2;
            int maxControlInRow = clientWidth / (maxWidth + mainAxisSpacing / 2) + 1;

            int childWidth = (clientWidth - (maxControlInRow - 1) * mainAxisSpacing) / (maxControlInRow);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Width = childWidth;
                children[i].Height = (int)(childWidth * this.ratioHeightPerWidth);

                int rowIndex = i / maxControlInRow;
                int columnIndex = i % maxControlInRow;

                int xLocation = padding + columnIndex * children[i].Width + columnIndex * mainAxisSpacing;
                int yLocation = padding + rowIndex * children[i].Height + rowIndex * crossAxisSpacing;

                children[i].Location = new Point(xLocation, yLocation);
            }
            this.ResumeLayout();
            panelGridview.PerformLayout();
        }
        public void RemoveItem(T child)
        {
            this.children.Remove(child);
            panelGridview.Controls.Remove(child);
            UcGridview_SizeChanged(null, null);
        }
        public void AddItem(T child)
        {
            this.children.Add(child);
            child.MaximumSize = new Size(this.maxWidth, (int)(maxWidth * ratioHeightPerWidth));
            panelGridview.Controls.Add(child);
            UcGridview_SizeChanged(null, null);
        }
    }
}
