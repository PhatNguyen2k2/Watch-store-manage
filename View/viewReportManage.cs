using WatchStoreManage.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WatchStoreManage.View
{
    public partial class viewReportManage : Form
    {
        public viewReportManage()
        {
            InitializeComponent();
        }

        private void viewReportManage_Load(object sender, EventArgs e)
        {
            int i = 0;
            initProduct();
            List<HOADON> hd = Program.context.HOADONs.OrderBy(n => n.NGAYLAPHOADON).ToList();
            hd.ForEach(x =>
            {
                if (!cbYear.Items.Contains(x.NGAYLAPHOADON.Year))
                {
                    cbYear.Items.Add(x.NGAYLAPHOADON.Year);
                }
                else
                {
                    i++;
                }
            });
            cbMonth.Hide();
            initTable();
        }
        public void initProduct()
        {
            List<SANPHAM> sp = null;
            sp = Program.context.SANPHAMs.OrderBy(n => n.MASP).ToList();
            sp.ForEach(n =>
            {
                productBarData.DataPoints.Add(n.MASP, n.SOLUONG);
                productPieData.DataPoints.Add(n.MASP, n.SOLUONG);
            });
        }
        public void initTable()
        {
            List<SANPHAM> sp = null;
            if (txtFind.Text != "")
            {
                sp = Program.context.SANPHAMs.Where(n => n.MASP.Contains(txtFind.Text) || n.TENSP.Contains(txtFind.Text)).ToList();
            }
            else sp = Program.context.SANPHAMs.ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Amount", typeof(int));
            table.Columns.Add("Price in", typeof(decimal));
            table.Columns.Add("Price out", typeof(decimal));
            table.Columns.Add("Type id", typeof(string));
            table.Columns.Add("Supplier id", typeof(string));
            table.Columns.Add("Image", typeof(byte[]));
            sp.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.MASP;
                rowDT["Name"] = x.TENSP;
                rowDT["Amount"] = x.SOLUONG;
                rowDT["Price in"] = x.GIAMUA;
                rowDT["Price ount"] = x.GIABAN;
                rowDT["Type idi"] = x.MALSP;
                rowDT["Supplier id"] = x.MANCC;
                rowDT["Image"] = x.HinhAnh;
                table.Rows.Add(rowDT);
            });
            tblProduct.DataSource = table;
        }
        public void statisticProduct()
        {
            productLineData.DataPoints.Clear();
            String[] id = null;
            int[] amount = null;
            id = Program.context.Database.SqlQuery<String>("SELECT CTHD.MASP as Masp FROM CTHD, SANPHAM, HOADON WHERE CTHD.MASP = SANPHAM.MASP AND CTHD.SOHD = HOADON.SOHD AND MONTH(NGAYLAPHOADON) = @Thang AND YEAR(NGAYLAPHOADON) = @Nam GROUP BY CTHD.MASP, CTHD.SOLUONG ORDER BY SUM(CTHD.SOLUONG)", new SqlParameter("@Thang", Convert.ToInt32(cbMonth.SelectedItem.ToString())), new SqlParameter("@Nam", Convert.ToInt32(cbYear.SelectedItem.ToString()))).ToArray();
            amount = Program.context.Database.SqlQuery<int>("SELECT SUM(CTHD.SOLUONG) as Sl FROM CTHD, SANPHAM, HOADON WHERE CTHD.MASP = SANPHAM.MASP AND CTHD.SOHD = HOADON.SOHD AND MONTH(NGAYLAPHOADON) = @Thang AND YEAR(NGAYLAPHOADON) = @Nam GROUP BY CTHD.MASP, CTHD.SOLUONG ORDER BY SUM(CTHD.SOLUONG)", new SqlParameter("@Thang", Convert.ToInt32(cbMonth.SelectedItem.ToString())), new SqlParameter("@Nam", Convert.ToInt32(cbYear.SelectedItem.ToString()))).ToArray();
            for (int i = 0; i < id.Length; i++)
            {
                productLineData.DataPoints.Add(id[i], amount[i]);
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMonth.Show();
            cbMonth.Items.Clear();
            List<HOADON> hd = Program.context.HOADONs.Where(n => n.NGAYLAPHOADON.Year.ToString() == cbYear.SelectedItem.ToString()).ToList();
            hd.ForEach(x =>
            {
                if (!cbMonth.Items.Contains(x.NGAYLAPHOADON.Month))
                {
                    cbMonth.Items.Add(x.NGAYLAPHOADON.Month);
                }
            });
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            statisticProduct();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            initTable();
        }
    }
}
