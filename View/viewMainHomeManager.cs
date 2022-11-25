using WatchStoreManage.Model;
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
    public partial class viewMainHomeManager : Form
    {
        public viewMainHomeManager()
        {
            InitializeComponent();
        }

        private void viewMainHomeManager_Load(object sender, EventArgs e)
        {
            initTableFrom();
            initTableTo();
            initComboBoxPosition();
        }
        public void initTableFrom()
        {
            List<MESSAGE> ms = Program.context.MESSAGEs.Where(n => n.NGGUI == "QLCH000").OrderByDescending(n => n.THOIGIAN).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Đến", typeof(string));
            table.Columns.Add("Thời gian", typeof(DateTime));
            ms.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.SOTN;
                rowDT["Đến"] = x.NGNHAN;
                rowDT["Thời gian"] = x.THOIGIAN;
                table.Rows.Add(rowDT);
            });
            tblSent.DataSource = table;
        }
        public void initTableTo()
        {
            List<MESSAGE> ms = Program.context.MESSAGEs.Where(n => n.NGNHAN == "QLCH000").OrderByDescending(n => n.THOIGIAN).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Từ", typeof(string));
            table.Columns.Add("Thời gian", typeof(DateTime));
            ms.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.SOTN;
                rowDT["Từ"] = x.NGGUI;
                rowDT["Thời gian"] = x.THOIGIAN;
                table.Rows.Add(rowDT);
            });
            tblTo.DataSource = table;
        }
        public void initComboBoxPosition()
        {
            List<NHANVIEN> nv = Program.context.NHANVIENs.Where(n => n.MANV != "QLCH000").ToList();
            nv.ForEach(x =>
            {
                cbPick.Items.Add(x.MANV);
            });
        }
        private void tblSent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = tblSent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTo.Text = tblSent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTime1.Text = tblSent.Rows[e.RowIndex].Cells[2].Value.ToString();
            MESSAGE ms = Program.context.MESSAGEs.FirstOrDefault(n => n.SOTN.ToString() == id);
            txtContent1.Text = ms.NOIDUNG.ToString();
        }

        private void tblTo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = tblTo.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFrom.Text = tblTo.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTime2.Text = tblTo.Rows[e.RowIndex].Cells[2].Value.ToString();
            MESSAGE ms = Program.context.MESSAGEs.FirstOrDefault(n => n.SOTN.ToString() == id);
            txtContent2.Text = ms.NOIDUNG.ToString();
        }

        private void cbPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => n.MANV == cbPick.SelectedItem.ToString());
            txtNameP.Text = nv.TENNV + "-" + nv.CHUCVU;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cbPick.SelectedIndex == -1 && txtContent3.Text == "")
            {
                MessageBox.Show("Hãy kiểm tra lại thông tin");
                return;
            }
            else
            {
                MESSAGE ms = new MESSAGE
                {
                    NGGUI = "QLCH000",
                    NGNHAN = cbPick.SelectedItem.ToString(),
                    NOIDUNG = txtContent3.Text,
                    THOIGIAN = DateTime.Now
                };
                Program.context.MESSAGEs.Add(ms);
                Program.context.SaveChanges();
                MessageBox.Show("Đã gửi");
            }
        }
    }
}
