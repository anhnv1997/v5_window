using iParkingv5.Objects.Configs;
using iParkingv6.Objects.Datas;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucViewGrid : UserControl
    {
        #region Properties
        public int RowsCount { get; set; } = 2;
        public int ColumnsCount { get; set; } = 2;
        private bool isMoving = false;
        private Point StartArrangeLocation = new Point(0, 0);
        private Point EndArrangeLocation = new Point(0, 0);
        TableLayoutPanel? table;
        #endregion End Properties

        #region Forms
        public ucViewGrid()
        {
            InitializeComponent();
        }
        #endregion End Forms

        #region Controls In Form
        private void Table_MouseDown(object? sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.isMoving = true;
            StartArrangeLocation = e.Location;
        }
        private void Table_MouseUp(object? sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.isMoving = false;
            EndArrangeLocation = e.Location;
            ArrageControl(StartArrangeLocation, EndArrangeLocation);
        }
        private void Table_MouseMove(object? sender, MouseEventArgs e)
        {
            if (this.isMoving == true)
                this.Cursor = Cursors.NoMove2D;
        }
        #endregion End Controls In Form

        #region Public Function
        public void UpdateRowSetting(int row, int column)
        {
            this.RowsCount = row;
            this.ColumnsCount = column;
            this.Controls.Clear();
            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = column;
            table.RowCount = row;
            table.Padding = new Padding(3);
            for (int i = 0; i < column; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / column));
            }
            for (int i = 0; i < row; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / row));
            }
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            table.MouseDown += Table_MouseDown;
            table.MouseUp += Table_MouseUp;
            table.MouseMove += Table_MouseMove;
            this.Controls.Add(table);
        }
        public void UpdateSelectLocation(Control? control)
        {
            if (control == null) return;
            table.Controls.Add(control);
        }
        public List<string> GetOrderConfig()
        {
            List<string> orderLanes = new List<string>();
            Dictionary<string, int[]> viewDetail = new Dictionary<string, int[]>();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    string laneId = table.GetControlFromPosition(j, i) != null ? (table.GetControlFromPosition(j, i) as iLane)!.lane.id : string.Empty;
                    orderLanes.Add(laneId);
                }
            }
            return orderLanes;
        }
        #endregion

        #region Private Function
        private Point GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int findCOlumnIndex = 0;
            int findRowIndex = 0;

            if (point.X < widths[0])
            {
                findCOlumnIndex = 0;
            }
            else
            {
                findCOlumnIndex = point.X / widths[0] >= widths.Length ? widths.Length - 1 : point.X / widths[0];
            }

            int[] heights = tlp.GetRowHeights();
            if (point.Y < heights[0])
            {
                findRowIndex = 0;
            }
            else
            {
                findRowIndex = point.Y / heights[0] >= heights.Length ? heights.Length - 1 : point.Y / heights[0];
            }

            return new Point(findCOlumnIndex, findRowIndex);
        }
        private void ArrageControl(Point startLocation, Point endLocation)
        {
            Point startCell = GetRowColIndex(table, startLocation);
            Point endCell = GetRowColIndex(table, endLocation);

            Control startControl = table.GetControlFromPosition(startCell.X, startCell.Y);
            Control endControl = table.GetControlFromPosition(endCell.X, endCell.Y);

            if (startControl != null)
            {
                table.SetCellPosition(startControl, new TableLayoutPanelCellPosition(endCell.X, endCell.Y));
            }

            if (endControl != null)
            {
                table.SetCellPosition(endControl, new TableLayoutPanelCellPosition(startCell.X, startCell.Y));
            }
            table.Refresh();
            this.SuspendLayout();
            for (int i = 0; i < table.Controls.Count; i++)
            {
                Control control = table.GetControlFromPosition(i, 0);
                if (control is ucLaneIn)
                {
                    table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 40);
                }
                else
                {
                    table.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, 60);
                }
            }
            this.ResumeLayout();
        }
        #endregion End Private Function
    }
}
