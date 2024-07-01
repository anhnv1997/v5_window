﻿using IdentityModel.OidcClient;
using iParkingv5.ApiManager.KzParkingv5Apis;
using iParkingv5.ApiManager;
using iParkingv5.Objects.Datas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iParkingv5.Objects.Databases;
using iParkingv5.Objects;
using System.Globalization;

namespace iParkingv5.FeeTest
{
    public partial class frmFeeCalculate : Form
    {
        List<FeeTest_Model> LstTest = new List<FeeTest_Model>();
        public static iParkingApi ApiServer = new KzParkingv5ApiHelper();
        private List<IdentityGroup> IdentityGroups = new List<IdentityGroup>();
        private string Tin
        {
            get { return TimeIn.Value.ToString("HH:mm:ss"); }
        }
        private string Tout
        {
            get { return TimeOut.Value.ToString("HH:mm:ss"); }
        }
        private string CardGroupID
        {
            get
            {
                if (cbbIdentityGroup.Text == "")
                    return "";
                return ((ListItem)cbbIdentityGroup.SelectedItem).Value;
            }

        }
        public frmFeeCalculate()
        {
            InitializeComponent();

            DayIn.Value = DateTime.Now;
            DayOut.Value = DateTime.Now;
            TimeIn.Value = DateTime.Now;
            TimeOut.Value = DateTime.Now;
            dgvShow.AutoSize = true;
            //DataSet();

            LoadCT();
        }
        private void DataSet()
        {
            dgvShow.DataSource = null;
            dgvShow.DataSource = LstTest;
            dgvShow.Columns["FeeName"].HeaderText = "Tên biểu phí"; dgvShow.Columns["FeeName"].Width = 130;
            dgvShow.Columns["CardGroupName"].HeaderText = "Nhóm thẻ"; dgvShow.Columns["CardGroupName"].Width = 220;
            dgvShow.Columns["TimeIn_List"].HeaderText = "Giờ vào"; dgvShow.Columns["TimeIn_List"].Width = 130;
            dgvShow.Columns["TimeOut_List"].HeaderText = "Giờ ra"; dgvShow.Columns["TimeOut_List"].Width = 130;
            dgvShow.Columns["Monney_List"].HeaderText = "Số tiền"; dgvShow.Columns["Monney_List"].Width = 150;

            dgvShow.Columns["Monney_List"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private async void LoadCT()
        {
            IdentityGroups = (await ApiServer.GetIdentityGroupsAsync())?.Item1 ?? new List<IdentityGroup>();
            var listItems = new List<ListItem>();
            foreach (var item in IdentityGroups)
            {
                listItems.Add(new ListItem
                {
                    Value = item.Id.ToString(),
                    Name = item.Name
                });
            }

            cbbIdentityGroup.DataSource = listItems;
            cbbIdentityGroup.DisplayMember = "Name";
            cbbIdentityGroup.ValueMember = "Value";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public class FeeTest_Model
        {
            public int Stt { get; set; }
            public string FeeName { get; set; }
            public string CardGroupName { get; set; }
            public string TimeIn_List { get; set; }
            public string TimeOut_List { get; set; }
            public string Monney_List { get; set; }
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                txbMoney.Text = "";
                var dateTimeIn = DateTime.Parse(DayIn.Value.ToString("yyyy/MM/dd ") + Tin);
                var dateTimeOut = DateTime.Parse(DayOut.Value.ToString("yyyy/MM/dd ") + Tout);


                string dateTimeInUTC = dateTimeIn.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                string dateTimeOutUTC = dateTimeOut.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");


                if (String.IsNullOrEmpty(CardGroupID))
                {
                    MessageBox.Show("Vui lòng Chọn nhóm thẻ", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (dateTimeIn > dateTimeOut)
                {
                    MessageBox.Show("Thời gian không hợp lệ", "Error", MessageBoxButtons.OK);
                    return;
                }

                string feeMoney = await ApiServer.GetFeeCalculate(dateTimeInUTC, dateTimeOutUTC, cbbIdentityGroup.SelectedValue.ToString());
                NumberFormatInfo num = new CultureInfo("de-DE", false).NumberFormat;
                if(feeMoney != "")
                {
                    if (decimal.TryParse(feeMoney, out decimal feeAmount))
                    {
                        txbMoney.Text = feeAmount.ToString("N0", num);
                    }
                    else
                    {
                        txbMoney.Text = "Invalid fee amount";
                    }
                    FeeTest_Model newResult = new FeeTest_Model()
                    {
                        Stt = dgvShow.Rows.Count + 1,
                        FeeName = "XuanCuong",
                        CardGroupName = cbbIdentityGroup.Text,
                        TimeIn_List = dateTimeIn.ToString("dd/MM/yyyy HH:mm:ss"),
                        TimeOut_List = dateTimeOut.ToString("dd/MM/yyyy HH:mm:ss"),
                        Monney_List = feeAmount.ToString("N0", num),
                    };
                    //LstTest.Add(newResult);

                    dgvShow.Rows.Add(dgvShow.Rows.Count + 1, "XuanCuong", newResult.CardGroupName, newResult.TimeIn_List, newResult.TimeOut_List, newResult.Monney_List);
                    //DataSet();
                }
                else
                {
                    txbMoney.Text = "Mời thử lại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra. {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //LstTest.Clear();
            //dgvShow.DataSource = null;
            if (dgvShow.Rows.Count > 1)
            {
                // Lặp ngược từ hàng cuối đến hàng thứ hai và xóa từng hàng
                for (int i = dgvShow.Rows.Count-1; i >= 0; i--)
                {
                    dgvShow.Rows.RemoveAt(i);
                }
            }
        }

        private void frmFeeCalculate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
        }

        private void dgvShow_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra nếu chỉ số hàng hoặc cột là -1 thì không làm gì
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                // Hủy bỏ hành động chọn ô
                return;

                //dataGridView1.ClearSelection();
            }
        }
    }
}