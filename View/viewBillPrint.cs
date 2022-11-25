using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchStoreManage.View
{
    public partial class viewBillPrint : Form
    {
        public viewBillPrint()
        {
            InitializeComponent();
        }

        private void viewBillPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUANLYCUAHANGDHDataSet.CTHD' table. You can move, or remove it, as needed.
            this.cTHDTableAdapter.Fill(this.qUANLYCUAHANGDHDataSet.CTHD);

            this.reportViewer1.RefreshReport();
        }
    }
}
