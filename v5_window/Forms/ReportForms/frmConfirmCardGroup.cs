﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Forms.ReportForms
{
    public partial class frmConfirmCardGroup : Form
    {
        public frmConfirmCardGroup(string plate, string oldGroup, string newGroup)
        {
            InitializeComponent();
            lblPlate.Text = plate;
            lblOld.Text = oldGroup;
            lblNew.Text = newGroup;
        }
    }
}