using ALS_BacNinh;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using ALSE.Objects;

namespace ALSE
{
    public partial class frmSetting : Form
    {
        #region Properties
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Tab))
            {
                if (tabControl1.SelectedIndex == tabControl1.TabPages.Count - 1)
                {
                    tabControl1.SelectTab(tabControl1.TabPages[0]);
                }
                else
                    tabControl1.SelectTab(tabControl1.TabPages[tabControl1.SelectedIndex + 1]);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public frmSetting()
        {
            InitializeComponent();
            this.Load += FrmSetting_Load;
        }

        private void FrmSetting_Load(object? sender, EventArgs e)
        {
            dgvController.Rows.Clear();
            foreach (Controller item in AppDatas.controllers)
            {
                dgvController.Rows.Add(item.id, dgvController.Rows.Count + 1, item.name, item.code, item.description, item.type.ToString(), item.comport, item.baudrate);
            }

            //dgvCard.Rows.Clear();
            //foreach (Card item in AppDatas.cards)
            //{
            //    dgvCard.Rows.Add(item.id, dgvCard.Rows.Count + 1, item.cardNumber, item.customerName);
            //}

        }


        #endregion End Properties

        #region Controls In Form
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            ToolStripButton? btn = sender as ToolStripButton;
            bool isAddSuccess = false;
            DataGridView dgv = new DataGridView();
            if (btn != null)
            {
                if (btn.Tag.ToString() == "CONTROLLER")
                {
                    dgv = dgvController;
                    frmController frm = new frmController("");
                    isAddSuccess = frm.ShowDialog() == DialogResult.OK;

                }
                if (isAddSuccess)
                {
                    tsbRefresh_Click(sender, e);
                    try
                    {
                        dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[1];
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ToolStripButton? btn = sender as ToolStripButton;
            bool isUpdateSuccess = false;
            DataGridView dgv = new DataGridView();
            if (btn != null)
            {
                if (btn.Tag.ToString() == "CONTROLLER")
                {
                    dgv = dgvController;
                    var selectedId = dgvController.Id();
                    if (string.IsNullOrEmpty(selectedId))
                    {
                        MessageBox.Show("Hãy Chọn Bản Ghi Cần Chỉnh Sửa");
                        return;
                    }
                    frmController frm = new frmController(dgvController.Id());
                    isUpdateSuccess = frm.ShowDialog() == DialogResult.OK;
                }
            }
            if (isUpdateSuccess)
            {
                int currentRow = dgv.CurrentRow.Index;
                tsbRefresh_Click(sender, e);
                try
                {
                    dgv.CurrentCell = dgv.Rows[currentRow].Cells[1];
                }
                catch
                {
                }
            }
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            ToolStripButton? btn = sender as ToolStripButton;
            bool isDeleteSuccess = false;
            DataGridView dgv = new DataGridView();
            if (btn != null)
            {
                string selectedId;
                if (btn.Tag.ToString() == "CONTROLLER")
                {
                    dgv = dgvController;
                    selectedId = dgvController.Id();
                    if (string.IsNullOrEmpty(selectedId))
                    {
                        MessageBox.Show("Hãy Chọn Bản Ghi Cần Chỉnh Sửa");
                        return;
                    }
                    if (tblController.DeleteControllerById(selectedId))
                    {
                        MessageBox.Show("Xóa Bản Ghi Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AppDatas.controllers.RemoveById(selectedId);
                        isDeleteSuccess = true;
                    }
                    else
                    {
                        MessageBox.Show("Xóa Bản Ghi Thất Bại, Xin Hãy Thử Lại Sau Giây Lát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (isDeleteSuccess)
            {
                int currentRow = dgv.CurrentRow.Index;
                tsbRefresh_Click(sender, e);
                try
                {
                    if (dgv.RowCount > currentRow)
                    {
                        dgv.CurrentCell = dgv.Rows[currentRow].Cells[1];
                    }
                    else if (dgv.RowCount > 0)
                    {
                        dgv.CurrentCell = dgv.Rows[currentRow - 1].Cells[1];
                    }
                }
                catch
                {
                }
            }
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            ToolStripButton? btn = sender as ToolStripButton;
            if (btn != null)
            {
                if (btn.Tag.ToString() == "CONTROLLER")
                {
                    dgvController.Rows.Clear();
                    foreach (Controller item in AppDatas.controllers)
                    {
                        dgvController.Rows.Add(item.id, dgvController.Rows.Count + 1, item.name, item.code, item.description, item.type.ToString(), item.comport, item.baudrate);
                    }
                }
            }
        }
        private void dgvController_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isUpdateSuccess = false;
            var selectedId = dgvController.Id();
            if (string.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Hãy Chọn Bản Ghi Cần Chỉnh Sửa");
                return;
            }
            frmController frm = new frmController(dgvController.Id());
            isUpdateSuccess = frm.ShowDialog() == DialogResult.OK;
            if (isUpdateSuccess)
            {
                dgvController.Rows.Clear();
                foreach (Controller item in AppDatas.controllers)
                {
                    dgvController.Rows.Add(item.id, dgvController.Rows.Count + 1, item.name, item.code, item.description, item.type.ToString(), item.comport, item.baudrate);
                }
            }
        }
        #endregion


        private async void tsbImport_Click(object sender, EventArgs e)
        {
            //var ofd = new OpenFileDialog();
            //ofd.Filter = @"Excel Files|*.xls;*.xlsx;*.xlsm";
            //ofd.Title = @"Please select an excel file to read.";
            //ofd.RestoreDirectory = true;
            //if (ofd.ShowDialog() != DialogResult.OK) return;
            //using var doc = new SLDocument(ofd.FileName, "Sheet1");
            //var stats1 = doc.GetWorksheetStatistics();
            //const char startChar = 'A';
            //var data = new List<List<string>>();
            //for (var row = stats1.NumberOfRows; row >= 3; row--)
            //{
            //    var rowData = new List<string>();
            //    for (var column = 0; column < stats1.NumberOfColumns; column++)
            //    {
            //        var columnName = ((char)(startChar + column));
            //        rowData.Add(doc.GetCellValueAsString(columnName.ToString() + row));
            //    }
            //    data.Add(rowData);
            //}
            //var insertData = new List<Card>();
            //var errorData = new Dictionary<Card, string>();

            //foreach (var d in data.Select(LoadDataImport))
            //{
            //    if (d != null)
            //    {
            //        insertData.Add(d);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Thông tin mã thẻ không được để trống, vui lòng kiểm tra lại thông tin nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            //var errorList = await tblCard.InsertMultipleData(insertData);
            //if (errorList.Count > 0)
            //{
            //    MessageBox.Show("Gặp lỗi trong quá trình thêm dữ liệu, vui lòng xem chi tiết thông tin lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    new frmErrorList(errorList).Show(this);
            //}
            //else
            //{
            //    MessageBox.Show(@"Nhập dữ liệu Thành Công", "Thông baó", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //dgvCard.Rows.Clear();
            //foreach (Card item in AppDatas.cards)
            //{
            //    dgvCard.Rows.Add(item.id, dgvCard.Rows.Count + 1, item.cardNumber, item.customerName);
            //}
        }
        //private static Card? LoadDataImport(List<string> rowData)
        //{
        //    string cardNumber = rowData[1];
        //    string customerName = rowData[2];
        //    if (string.IsNullOrEmpty(cardNumber.Trim()))
        //    {
        //        return null;
        //    }
        //    return new Card()
        //    {
        //        cardNumber = cardNumber.Trim().ToUpper(),
        //        customerName = customerName,
        //    };
        //}

        private void tsbExport_Click(object sender, EventArgs e)
        {
         //   ExcelTools.CreatReportFile(dgvCard, "Danh Sách Thẻ");
        }
    }
}
