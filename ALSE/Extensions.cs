
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace ALSE
{
    public static class Extensions
    {
        
        public static void EnableFastLoadGridView(this DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        public static void DisableFastLoadGridView(this DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        public static string Id(this DataGridView dgv)
        {
            var drv = dgv.CurrentRow;
            try
            {
                var selectedId = drv != null && drv.Cells["_ID"].Value == null ? "" : drv?.Cells["_ID"].Value.ToString() ?? "";
                return selectedId;
            }
            catch (Exception)
            {
                var selectedId = drv != null && drv.Cells[0].Value == null ? "" : drv?.Cells[0].Value.ToString() ?? "";
                return selectedId;
            }

        }
    }

}
