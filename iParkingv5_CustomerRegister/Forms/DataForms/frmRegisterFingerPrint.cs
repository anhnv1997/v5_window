using iParkingv5_CustomerRegister.Databases;
using System.Text;

namespace iParkingv5_CustomerRegister.Forms
{
    public partial class frmRegisterFingerPrint : Form
    {
        public enum EmOperatorType
        {
            Add,
            Modify
        }
        #region Properties
        private bool isConnect = false;
        string gImagePath = "Finger.bmp";
        BRNETLH.PARA_TABLE fpParaTable = new BRNETLH.PARA_TABLE();
        //UInt16 gAlgCharSize = 0;
        public const ushort CHAR_XALG_SIZE = 810;
        byte[] gMBIndex = new byte[100];
        bool gCancel = false;
        public string FingerCharStr = string.Empty;

        private ushort fingerId;
        private EmOperatorType operatorType;
        public ushort registerIndex = 0;
        #endregion End Properties

        #region Form
        public frmRegisterFingerPrint(ushort fingerId, EmOperatorType operatorType)
        {
            InitializeComponent();
            btnEnroll.Enabled = false;
            btnSaveFinger.Enabled = false;
            this.fingerId = fingerId;
            this.operatorType = operatorType;
        }
        protected override void OnClosed(EventArgs e)
        {
            if (this.isConnect)
            {
                BRNETLH.Close();
            }
            base.OnClosed(e);
        }
        #endregion End Form

        #region Controls In Form
        private void btn_ConnectDevice_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                if (!(BRNETLH.Open()))
                {
                    UpdateMessage("Không kết nối được tới thiết bị đăng ký vân tay", true);
                    return;
                }
                if (!BRNETLH.CmdReadParaTable(ref fpParaTable))
                {
                    UpdateMessage("Không lấy được thông tin thiết bị", true);
                    return;
                }
                btnConnect.Text = "Ngắt kết nối";
                isConnect = true;
                UpdateMessage("Kết nối tới thiết bị thành công");
                btnEnroll.Enabled = true;
                isConnect = true;
                btnEnroll.Focus();
            }
            else
            {
                btnConnect.Text = "Kết nối thiết bị";
                UpdateMessage("Ngắt kết nối thiết bị");
                BRNETLH.Close();
                btnEnroll.Enabled = false;
                btnSaveFinger.Enabled = false;
                isConnect = false;
            }
        }
        private async void btnEnroll_Click(object sender, EventArgs e)
        {
            btnEnroll.Enabled = false;
            UInt32 step = 1;
            gCancel = false;

            if (this.operatorType == EmOperatorType.Add)
            {
                gMBIndex = new byte[fpParaTable.dwFingerNum];

                Array.Clear(gMBIndex, 0, gMBIndex.Length);
                if (!BRNETLH.CmdGetMBIndex(gMBIndex))
                {
                    UpdateMessage("Không đọc được thông tin đăng ký", true);
                    return;
                }

                int enrolled = 0;
                for (int i = 0; i < gMBIndex.Length; i++)
                {
                    if (gMBIndex[i] != 0)
                    {
                        enrolled++;
                    }
                }
                UpdateMessage("Số lượng vân tay đã đăng ký: " + enrolled.ToString());

                ushort freeindex = 0;
                for (freeindex = 0; freeindex < gMBIndex.Length; freeindex++)
                {
                    if (gMBIndex[freeindex] == 0)
                    {
                        break;
                    }
                }
                registerIndex = freeindex;
                UpdateMessage("Đăng ký người dùng mới: " + (registerIndex + 1).ToString());
            }
            else
            {
                registerIndex = this.fingerId;
                UpdateMessage("Cập nhật thông tin vân tay: " + (registerIndex + 1).ToString());
            }


            await Task.Run(() =>
             {
                 while (step <= 3)
                 {
                     if (gCancel)
                         return;

                     CapAndShowFingerForOperation();

                     if (!BRNETLH.CmdGenChar(step))
                     {
                         UpdateMessage("Đọc đặc điểm vân tay lỗi: " + BRNETLH.GetLastErrorMessage(), true);
                         Application.DoEvents();
                         continue;
                     }
                     UpdateMessage("Đọc đặc điểm vân tay thành công " + (step).ToString());
                     Application.DoEvents();

                     step++;
                 }

                 // Merge 
                 if (!BRNETLH.CmdMergeChar())
                 {
                     UpdateMessage("Tổng hợp vân tay lỗi", true);
                     return;
                 }
                 UpdateMessage("Tổng hợp vân tay thành công");
             });
            btnSaveFinger.Enabled = true;
            btnEnroll.Enabled = true;
            btnSaveFinger.Focus();
        }
        private void btnSaveFinger_Click(object sender, EventArgs e)
        {
            if (this.operatorType == EmOperatorType.Modify)
            {
                UInt16 _RetMbIndex = 0;
                if (BRNETLH.CmdSearchChar(3, ref _RetMbIndex))
                {
                    if (_RetMbIndex != registerIndex)
                    {
                        UpdateMessage("Vân tay đã được đăng ký trước đó : " + (_RetMbIndex + 1), true);
                        return;
                    }
                    else
                    {
                        BRNETLH.CmdDelChar(registerIndex);
                    }
                }
            }
           
            if (!BRNETLH.CmdStoreChar(registerIndex))
            {
                string lastErrorMessage = BRNETLH.GetLastErrorMessage();
                UpdateMessage("Lưu thông tin vân tay lỗi: " + lastErrorMessage, true);
                return;
            }
            else
            {
                MessageBox.Show("Lưu thông tin vân tay: " + (registerIndex + 1) + " thành công!");
                byte[] _FingerChar = new byte[CHAR_XALG_SIZE];
                BRNETLH.GetFingerData(registerIndex, _FingerChar, CHAR_XALG_SIZE);
                this.FingerCharStr = string.Join(" ", _FingerChar);
                if (this.operatorType == EmOperatorType.Add)
                {
                    tblFingerprint.InsertFinger(this.registerIndex, this.FingerCharStr);
                }
                else
                {
                    tblFingerprint.UpdateFinger(this.registerIndex, this.FingerCharStr);
                }
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion End Controls In Form

        #region Private Function
        private void CapAndShowFingerForOperation()
        {
            do
            {
                int ires = 0;
                ires = CapImage();
                switch (ires)
                {
                    case 0:
                        UpdateMessage("Phát hiện hình ảnh vân tay");
                        ires = UploadImage();
                        return;
                    case 1:
                        UpdateMessage("Vui lòng đặt vân tay vào vị trí đăng ký");
                        break;
                    default:
                        UpdateMessage("Đọc dữ liệu lỗi", true);
                        break;
                }
            } while (!gCancel);
        }

        private int CapImage()
        {
            UInt16 _Err = 0;
            bool res = BRNETLH.GetRedressImage(ref _Err);
            if (res != true)
            {
                return 2;
            }

            if (_Err == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private int UploadImage()
        {
            bool res = BRNETLH.UploadImage();
            this.ShowImage(gImagePath);
            return 0;
        }
        public void ShowImage(string imagePath)
        {
            //pb.Image = Image.FromFile(imagePath);
            this.Invoke(new Action(() =>
            {
                FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                pb.Image = Image.FromStream(fileStream);
                fileStream.Close();
                fileStream.Dispose();
            }));
        }

        private void UpdateMessage(string message, bool isError = false)
        {
            dgvStatus.Invoke(new Action(() =>
            {
                if (dgvStatus.RowCount > 0)
                {
                    string lastMessage = dgvStatus.Rows[0].Cells[1]?.Value?.ToString() ?? "";
                    if (lastMessage == message)
                    {
                        return;
                    }
                }
                dgvStatus.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), message);
                if (isError)
                {
                    dgvStatus.Rows[0].DefaultCellStyle.ForeColor = Color.DarkRed;
                    dgvStatus.Rows[0].DefaultCellStyle.Font = new Font(dgvStatus.DefaultCellStyle.Font, FontStyle.Bold);
                }
                if (dgvStatus.RowCount > 200)
                {
                    dgvStatus.Rows.RemoveAt(200);
                }
                Application.DoEvents();
            }));
        }
        #endregion End Private Function
    }
}
