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
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Số lượng", typeof(int));
            table.Columns.Add("Giá mua", typeof(decimal));
            table.Columns.Add("Giá bán", typeof(decimal));
            table.Columns.Add("Mã loại", typeof(string));
            table.Columns.Add("Mã NCC", typeof(string));
            table.Columns.Add("Ảnh", typeof(byte[]));
            sp.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.MASP;
                rowDT["Tên"] = x.TENSP;
                rowDT["Số lượng"] = x.SOLUONG;
                rowDT["Giá mua"] = x.GIAMUA;
                rowDT["Giá bán"] = x.GIABAN;
                rowDT["Mã loại"] = x.MALSP;
                rowDT["Mã NCC"] = x.MANCC;
                rowDT["Ảnh"] = x.HinhAnh;
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
