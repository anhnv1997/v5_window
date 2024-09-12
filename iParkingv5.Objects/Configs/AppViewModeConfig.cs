using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    public class AppViewModeConfig
    {
        public enum EmAppViewMode
        {
            Optional = 0,
            Horizontal = 1,
            Vertical = 2,
        }
        public int ViewMode { get; set; } = 1;
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
    }
}
