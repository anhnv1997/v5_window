using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_CustomerRegister.Forms.SystemForms
{
    public partial class frmShowResult : Form
    {
        #region Properties
        private List<Tuple<string, string, string>> results;
        #endregion End Properties
        #region Forms
        public frmShowResult(List<Tuple<string, string, string>> results)
        {
            InitializeComponent();
            this.results = results;
            this.Load += FrmShowResult_Load;
        }

        private void FrmShowResult_Load(object? sender, EventArgs e)
        {
            foreach (var item in this.results)
            {
                string customerName = item.Item1;
                string controllerName = item.Item2;
                string result = item.Item3;

                dgvData.Rows.Add(dgvData.RowCount + 1, customerName, controllerName, result);
            }
        }
        #endregion End Forms

        #region Controls In Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Function

        #region Public Function

        #endregion End Public Function

    }
}
