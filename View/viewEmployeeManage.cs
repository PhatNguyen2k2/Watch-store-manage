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
    public partial class viewEmployeeManage : Form
    {
        public viewEmployeeManage()
        {
            InitializeComponent();
        }
        public void initTable()
        {
            //tbl.DataSource = null;
            List<NHANVIEN> nv = null;
            if (txtFindId.Text != "")
            {
                nv = Program.context.NHANVIENs.Where(n => n.MANV.Contains(txtFindId.Text) || n.TENNV.Contains(txtFindId.Text)).OrderBy(n => n.TENNV).ToList();
            }
            else nv = Program.context.NHANVIENs.OrderBy(n => n.TENNV).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Ngày sinh", typeof(DateTime));
            table.Columns.Add("SĐT", typeof(string));
            table.Columns.Add("Chức vụ", typeof(string));
            table.Columns.Add("Địa chỉ", typeof(string));
            table.Columns.Add("Ngày vào", typeof(DateTime));
            table.Columns.Add("Lương", typeof(decimal));
            nv.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.MANV;
                rowDT["Tên"] = x.TENNV;
                rowDT["Ngày sinh"] = x.NGAYSINH;
                rowDT["SĐT"] = x.SDT;
                rowDT["Chức vụ"] = x.CHUCVU;
                rowDT["Địa chỉ"] = x.DIACHI;
                rowDT["Ngày vào"] = x.NGAYVAOLAM;
                rowDT["Lương"] = x.LUONG;
                table.Rows.Add(rowDT);
            });
            tbl.DataSource = table;
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.TextLength > 10)
            {
                MessageBox.Show("Không hơn 10 kí tự");
                txtId.Text = "";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.TextLength > 200)
            {
                MessageBox.Show("Không hơn 200 kí tự");
                txtName.Text = "";
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.TextLength > 11 || txtPhone.Text.Substring(0, 1) != "0")
            {
                MessageBox.Show("SĐT không hợp lí\nHint: 10 hoặc 11 số và số 0 ở đầu :>");
                txtPhone.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || cbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Không được để trống trường nào");
            }
            else if (dateTimeBirth.Value >= dateTimeIn.Value)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày vào làm");
            }
            else if (Program.context.NHANVIENs.Count(n => n.MANV == txtId.Text) == 1)
            {
                MessageBox.Show("Tồn tại mã NV này");
            }
            else
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = txtId.Text;
                nv.TENNV = txtName.Text;
                nv.NGAYSINH = dateTimeBirth.Value;
                nv.SDT = txtPhone.Text;
                nv.CHUCVU = cbPosition.SelectedItem.ToString();
                nv.DIACHI = txtAddress.Text;
                nv.NGAYVAOLAM = dateTimeIn.Value;
                nv.LUONG = salary.Value;
                Program.context.NHANVIENs.Add(nv);
                Program.context.SaveChanges();
                MessageBox.Show("Thêm thành công");
                initTable();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => n.MANV == txtId.Text);
            nv.TENNV = txtName.Text;
            nv.NGAYSINH = dateTimeBirth.Value;
            nv.SDT = txtPhone.Text;
            nv.CHUCVU = cbPosition.SelectedItem.ToString();
            nv.DIACHI = txtAddress.Text;
            nv.NGAYVAOLAM = dateTimeIn.Value;
            nv.LUONG = salary.Value;
            Program.context.SaveChanges();
            MessageBox.Show("Sửa thành công");
            initTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Program.context.HOADONs.Count(n => n.MANV == txtId.Text) > 0)
            {
                MessageBox.Show("Nhân viên tồn tại trong Hóa đơn. Hãy xóa Hóa đơn trước");
                return;
            }
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => n.MANV == txtId.Text);
            Program.context.NHANVIENs.Remove(nv);
            Program.context.SaveChanges();
            MessageBox.Show("Xóa thành công");
            initTable();
        }

        private void txtFindId_TextChanged(object sender, EventArgs e)
        {
            initTable();
        }

        private void viewEmployeeManage_Load(object sender, EventArgs e)
        {
            initTable();
        }

        private void tbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = tbl.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = tbl.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimeBirth.Value = (DateTime)tbl.Rows[e.RowIndex].Cells[2].Value;
            txtPhone.Text = tbl.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbPosition.SelectedItem = tbl.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAddress.Text = tbl.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimeIn.Value = (DateTime)tbl.Rows[e.RowIndex].Cells[6].Value;
            salary.Value = (decimal)tbl.Rows[e.RowIndex].Cells[7].Value;
            btnAdd.Hide();
        }

        private void txtId_MouseClick(object sender, MouseEventArgs e)
        {
            btnAdd.Show();
        }
    }
}
