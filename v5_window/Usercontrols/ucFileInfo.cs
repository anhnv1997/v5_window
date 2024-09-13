using IPaking.Ultility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iParkingv5_window.Usercontrols
{
    public partial class ucFileInfo : UserControl
    {
        private string filePath = string.Empty;
        // Expose properties to design mode
        [Browsable(true)]
        [Category("Custom Message")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", typeof(UITypeEditor))]
        [Description("Sets the text of the Label")]
        public string FilePath
        {
            get { return filePath; }
            set
            {
                this.filePath = value;
                if (File.Exists(filePath))
                {
                    var fileInfo = new FileInfo(filePath);
                    string ultilityVersion = FileVersionInfo.GetVersionInfo(filePath).FileVersion!.ToString();
                    lblVersion.Message = ultilityVersion;
                    lblUpdateDate.Text = fileInfo.LastWriteTime.ToVNTime();
                }
                else
                {
                    lblVersion.Message = "version";
                    lblUpdateDate.Text = "update_date";
                }
                this.Refresh();
            }
        }
        public ucFileInfo()
        {
            InitializeComponent();
        }
    }
}
