using WatchStoreManage.Model;
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

namespace WatchStoreManage.View
{
    public partial class viewBillReportManage : Form
    {
        public viewBillReportManage()
        {
            InitializeComponent();
        }

        private void viewBillReportManage_Load(object sender, EventArgs e)
        {
            int i = 0;
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
        }
        public void initIncome()
        {
            incomeBarData.DataPoints.Clear();
            incomePolarData.DataPoints.Clear();
            int[] days = null;
            decimal[] amount = null;
            decimal[] sum = null;
            days = Program.context.Database.SqlQuery<int>("SELECT DAY(NGAYLAPHOADON) FROM HOADON WHERE YEAR(NGAYLAPHOADON) = @Nam AND MONTH(NGAYLAPHOADON) = @Thang", new SqlParameter("@Thang", Convert.ToInt32(cbMonth.SelectedItem.ToString())), new SqlParameter("@Nam", Convert.ToInt32(cbYear.SelectedItem.ToString()))).ToArray();
            amount = Program.context.Database.SqlQuery<decimal>("SELECT THANHTIENHD FROM HOADON WHERE YEAR(NGAYLAPHOADON) = @Nam AND MONTH(NGAYLAPHOADON) = @Thang", new SqlParameter("@Thang", Convert.ToInt32(cbMonth.SelectedItem.ToString())), new SqlParameter("@Nam", Convert.ToInt32(cbYear.SelectedItem.ToString()))).ToArray();
            sum = Program.context.Database.SqlQuery<decimal>("SELECT SUM(THANHTIENHD) FROM HOADON WHERE YEAR(NGAYLAPHOADON) = @Nam AND MONTH(NGAYLAPHOADON) = @Thang GROUP BY YEAR(NGAYLAPHOADON), MONTH(NGAYLAPHOADON)", new SqlParameter("@Thang", Convert.ToInt32(cbMonth.SelectedItem.ToString())), new SqlParameter("@Nam", Convert.ToInt32(cbYear.SelectedItem.ToString()))).ToArray();
            for (int i = 0; i < days.Length; i++)
            {
                incomeBarData.DataPoints.Add(days[i].ToString(), (double)amount[i]);
                incomePolarData.DataPoints.Add(days[i].ToString(), (double)amount[i]);
            }
            txtSum.Text = sum[0].ToString();
        }
        public void initTable()
        {
            List<HOADON> hd = Program.context.HOADONs.Where(n => n.NGAYLAPHOADON.Year.ToString() == cbYear.SelectedItem.ToString() && n.NGAYLAPHOADON.Month.ToString() == cbMonth.SelectedItem.ToString()).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Số HĐ", typeof(string));
            table.Columns.Add("Mã NV", typeof(string));
            table.Columns.Add("Mã KH", typeof(string));
            table.Columns.Add("Ngày lập", typeof(DateTime));
            table.Columns.Add("Thành tiền", typeof(decimal));
            table.Columns.Add("Trạng thái", typeof(string));
            hd.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Số HĐ"] = x.SOHD;
                rowDT["Mã NV"] = x.MANV;
                rowDT["Mã KH"] = x.MAKH;
                rowDT["Ngày lập"] = x.NGAYLAPHOADON;
                rowDT["Thành tiền"] = x.THANHTIENHD;
                rowDT["Trạng thái"] = x.TRANGTHAI;
                table.Rows.Add(rowDT);
            });
            tblBill.DataSource = table;
        }
        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            initIncome();
            initTable();
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

        private void tblBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = tblBill.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void tblBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (txtId.Text == "") return;
                List<CTHD> cthd = Program.context.CTHDs.Where(n => n.SOHD.ToString() == txtId.Text).ToList();
                cthd.ForEach(x =>
                {
                    Program.context.CTHDs.Remove(x);
                });
                Program.context.SaveChanges();
                HOADON hd = Program.context.HOADONs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text);
                Program.context.HOADONs.Remove(hd);
                Program.context.SaveChanges();
                txtId.Text = "";
            }
        }
    }
}
