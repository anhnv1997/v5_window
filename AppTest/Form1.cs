namespace AppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
          
        }

        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            string baseUrl = txtUrl.Text;
            string plateNumber = txtPlate.Text;
            string cardNumber = txtCardNumber.Text;
            if (string.IsNullOrEmpty(cardNumber))
            {
                MessageBox.Show("Hãy nhập mã thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string url = baseUrl + "Parking/CheckOut";
            var data = new
            {
                id = "",
                PlateNumber = plateNumber,
                CardNumbers = new List<string>() { cardNumber }
            };
            var response = await ApiHelper.ApiHelpers.GeneralJsonAPI(url, data, new Dictionary<string, string>(), new Dictionary<string, string>(), 5000, RestSharp.Method.Delete);
            MessageBox.Show(response.Content);
        }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            string baseUrl = txtUrl.Text;
            string plateNumber = txtPlate.Text;
            string cardNumber = txtCardNumber.Text;
            if (string.IsNullOrEmpty(cardNumber))
            {
                MessageBox.Show("Hãy nhập mã thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string url = baseUrl + "Parking/CheckIn";
            var data = new
            {
                id = "",
                PlateNumber = plateNumber,
                CardNumbers = new List<string>() { cardNumber }
            };
            var response = await ApiHelper.ApiHelpers.GeneralJsonAPI(url, data, new Dictionary<string, string>(), new Dictionary<string, string>(), 5000, RestSharp.Method.Post);
            MessageBox.Show(response.Content);
        }
    }
}
