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
    public partial class viewMainHomeStaff : Form
    {
        public viewMainHomeStaff()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            panelUser.Hide();
            initTableFrom();
            initTableTo();
            initComboBoxPosition();
            tabControlMess.Show();
        }
        public void initTableFrom()
        {
            List<MESSAGE> ms = Program.context.MESSAGEs.Where(n => n.NGGUI == viewLogin.EmployeeId).OrderByDescending(n => n.THOIGIAN).ToList();
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
            List<MESSAGE> ms = Program.context.MESSAGEs.Where(n => n.NGNHAN == viewLogin.EmployeeId).OrderByDescending(n => n.THOIGIAN).ToList();
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
            List<NHANVIEN> nv = Program.context.NHANVIENs.Where(n => n.MANV != viewLogin.EmployeeId && n.MANV != "NVTNK00" && n.MANV != "NVTKK00").ToList();
            nv.ForEach(x =>
            {
                cbPick.Items.Add(x.MANV);
            });
        }
        public void initUserDetail()
        {
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => n.MANV == viewLogin.EmployeeId);
            txtName.Text = nv.TENNV;
            dateTimeBirth.Value = nv.NGAYSINH;
            txtPhone.Text = nv.SDT;
            txtAddress.Text = nv.DIACHI;
        }
        private void tblSent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = tblSent.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTo.Text = tblSent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTime1.Text = tblSent.Rows[e.RowIndex].Cells[2].Value.ToString();
            MESSAGE ms = Program.context.MESSAGEs.FirstOrDefault(n => n.SOTN.ToString() == id);
            txtContent1.Text = viewLogin.DecodeFrom64(ms.NOIDUNG.ToString());
        }

        private void tblTo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = tblTo.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFrom.Text = tblTo.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTime2.Text = tblTo.Rows[e.RowIndex].Cells[2].Value.ToString();
            MESSAGE ms = Program.context.MESSAGEs.FirstOrDefault(n => n.SOTN.ToString() == id);
            txtContent2.Text = viewLogin.DecodeFrom64(ms.NOIDUNG.ToString());
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
                    NGGUI = viewLogin.EmployeeId,
                    NGNHAN = cbPick.SelectedItem.ToString(),
                    NOIDUNG = viewLogin.EncodePasswordToBase64(txtContent3.Text),
                    THOIGIAN = DateTime.Now
                };
                Program.context.MESSAGEs.Add(ms);
                Program.context.SaveChanges();
                MessageBox.Show("Đã gửi");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            tabControlMess.Hide();
            panelUser.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            tabControlMess.Hide();
            panelUser.Hide();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            tabControlMess.Hide();
            panelUser.Hide();
        }

        private void viewMainHomeStaff_Load(object sender, EventArgs e)
        {
            tabControlMess.Hide();
            panelUser.Hide();
            if(viewLogin.EmployeeId == "NVTNK00")
            {
                User.Hide();
                guna2CirclePictureBox1.Hide();
            }
        }

        private void User_Click(object sender, EventArgs e)
        {
            tabControlMess.Hide();
            initUserDetail();
            panelUser.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => n.MANV == viewLogin.EmployeeId);
            if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Không được để trống trường nào");
            }
            else if (txtPhone.Text.Substring(0, 1) != "0" || txtPhone.Text.Length < 10)
            {
                MessageBox.Show("SĐT không hợp lệ");
            }
            else if (dateTimeBirth.Value >= nv.NGAYVAOLAM)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày vào làm");
            }
            else
            {
                nv.TENNV = txtName.Text;
                nv.NGAYSINH = dateTimeBirth.Value;
                nv.SDT = txtPhone.Text;
                nv.DIACHI = txtAddress.Text;
                Program.context.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 200)
            {
                MessageBox.Show("Quá kí tự");
                txtName.Text = "";
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length > 11)
            {
                MessageBox.Show("Quá kí tự");
                txtPhone.Text = "";
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length > 200)
            {
                MessageBox.Show("Quá kí tự");
                txtAddress.Text = "";
            }
        }
    }
}
