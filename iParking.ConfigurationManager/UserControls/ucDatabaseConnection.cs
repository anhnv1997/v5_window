using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Databases;
using Kztek.Tool.Cryptors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iParkingv5.Objects.Enums.PrintHelpers;

namespace iParking.ConfigurationManager.UserControls
{
    public partial class ucDatabaseConnection : UserControl
    {
        #region Properties
        SQLConn? sqlConfig = null;
        SqlConnection? connection;
        #endregion End Properties

        #region Forms
        public ucDatabaseConnection(SQLConn? sqlConfig)
        {
            InitializeComponent();
            this.sqlConfig = sqlConfig;
            cbAuthenMode.Items.Add("Windows Authentication");
            cbAuthenMode.Items.Add("SQL Server Authentication");
            if (this.sqlConfig != null)
            {
                txtServerName.Text = this.sqlConfig.SQLServerName;
                cbAuthenMode.SelectedIndex = cbAuthenMode.FindStringExact(this.sqlConfig.SQLAuthentication);
                txtUsername.Text = this.sqlConfig.SQLUserName;
                txtPassword.Text = CryptorEngine.Decrypt(this.sqlConfig.SQLPassword, true);

                cbDatabase.Items.Add(this.sqlConfig.SQLDatabase);
                cbDatabase.SelectedIndex = 0;
            }
            btnCheckConnection.Click += BtnCheckConnection_Click;
        }

        private async void BtnCheckConnection_Click(object? sender, EventArgs e)
        {
            string oldaDatabaseName = cbDatabase.Text;
            connection = new SqlConnection(GetConnectStr(txtServerName.Text, "master", cbAuthenMode.Text, txtUsername.Text, txtPassword.Text));
            try
            {
                connection.Open();
                List<string> validDatabases = new List<string>();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT [name] from sys.databases order by [name]";
                SqlDataReader dataReader = cmd.ExecuteReader();
                cbDatabase.Items.Clear();
                while (dataReader.Read())
                {
                    string databaseName = dataReader["name"].ToString();
                    cbDatabase.Items.Add(databaseName);
                }
                cbDatabase.SelectedIndex = cbDatabase.FindStringExact(oldaDatabaseName);
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại, vui lòng kiểm tra lại thông tin và thử lại! " + ex.Message);
            }
        }
        #endregion End Forms

        #region Controls In Form

        #endregion End Controls In Form

        #region Public Function
        public SQLConn? GetSqlConfig()
        {
            string serverName = txtServerName.Text;
            string login = txtUsername.Text;
            string password = txtPassword.Text;
            string databaseName = cbDatabase.Text;
            string authenticationMode = cbAuthenMode.Text;
            bool isUseDatabase = chbIsUseDatabase.Checked;
            if (isUseDatabase)
            {
                if (string.IsNullOrEmpty(serverName))
                {
                    MessageBox.Show("Tên máy chủ không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                if (string.IsNullOrEmpty(databaseName))
                {
                    MessageBox.Show("Tên máy chủ không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                if (authenticationMode == "SQL Server Authentication" && string.IsNullOrEmpty(login))
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                SQLConn sqlconn = new SQLConn("", serverName, databaseName, login, CryptorEngine.Encrypt(password, true), authenticationMode, true);
                return sqlconn;
            }
            return new SQLConn("", serverName, databaseName, login, CryptorEngine.Encrypt(password, true), authenticationMode, false);
        }
        #endregion

        #region Private Function
        private string GetConnectStr(string serverName, string databaseName, string authentication, string username, string password)
        {
            if (authentication == "Windows Authentication")
            {
                return $"data source={serverName};initial Catalog ={databaseName}; Integrated Security=True";

            }
            return $"data source={serverName};initial Catalog ={databaseName}; user id ={username};password={password}";
        }

        #endregion End Private Function

    }
}
