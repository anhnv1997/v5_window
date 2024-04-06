using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols.Payments
{
    public partial class ucPayment : UserControl
    {
        #region Properties

        #endregion End Properties

        #region Forms
        public ucPayment()
        {
            InitializeComponent();
        }
        #endregion End Forms

        #region Controls In Form

        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Function

        #region Public Function

        public void LoadPayment(string eventId, long cost)
        {
            if (cost < 0)
            {
                this.Enabled = false;
            }
        }
        #endregion End Public Function
    }
}
