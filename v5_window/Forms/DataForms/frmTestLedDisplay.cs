using iParkingv5.LedDisplay.LEDs;

namespace iParkingv5_window.Forms.DataForms
{
    public partial class frmTestLedDisplay : Form
    {
        public ParkingData TestData
        {
            get
            {
                string cardNumber = txtCardNumber.Text;
                string cardNo = txtCardNo.Text;
                string cardType = txtCardType.Text;
                string eventStatus = txtEventStatus.Text;
                string plate = txtPlateNumber.Text;
                DateTime datetimeIn = dtpStartTime.Value;
                DateTime datetimeOut = dtpEndTime.Value;
                string money = txtMoney.Text;
                return new ParkingData(cardNumber, cardNo, cardType, eventStatus, plate, datetimeIn, datetimeOut, money);
            }
        }
        public frmTestLedDisplay()
        {
            InitializeComponent();
            this.Load += FrmTestLedDisplay_Load;
        }

        private void FrmTestLedDisplay_Load(object? sender, EventArgs e)
        {
            btnOk1.InitControl(BtnOk1_Click);
            btnCancel1.InitControl(BtnCancel1_Click);
        }
        private void BtnOk1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel1_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
