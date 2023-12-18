using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Usercontrols
{
    public class ViewSetting
    {
        public int RowsCount { get; set; } = 0;
        public int ColumnsCount { get; set; } = 0;

        public Dictionary<string, int[]> ViewSettingDetails { get; set; } = new Dictionary<string, int[]>();
    }
}
