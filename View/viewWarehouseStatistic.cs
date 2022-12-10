using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchStoreManage.Model;

namespace WatchStoreManage.View
{
    public partial class viewWarehouseStatistic : Form
    {
        public viewWarehouseStatistic()
        {
            InitializeComponent();
        }
        public void initSupplier()
        {
            stackedBarData.DataPoints.Clear();
            doughnutData.DataPoints.Clear();
            List<NHACUNGCAP> ncc = Program.context.NHACUNGCAPs.ToList();
            int[] amount = null;
            amount = Program.context.Database.SqlQuery<int>("select count(sp.MASP) as Amount from SANPHAM sp group by sp.MANCC").ToArray();
            int i = 0;
            ncc.ForEach(x =>
            {
                stackedBarData.DataPoints.Add(x.MANCC, amount[i]);
                doughnutData.DataPoints.Add(x.MANCC, amount[i]);
                i++;
            });
        }
        public void initProduct()
        {
            barChartData.DataPoints.Clear();
            List<SANPHAM> sp = null;
            if (cbPrice.SelectedIndex == 0)
            {
                sp = Program.context.SANPHAMs.OrderByDescending(n => n.GIAMUA).ToList();
            }else sp = Program.context.SANPHAMs.OrderBy(n => n.GIAMUA).ToList();
        }
        private void viewWarehouseStatistic_Load(object sender, EventArgs e)
        {
            cbPrice.SelectedIndex = 0;
            initSupplier();
            initProduct();
        }

        private void cbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            initProduct();
        }
    }
}
