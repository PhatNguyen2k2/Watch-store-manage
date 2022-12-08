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
    public partial class viewCustomerManage : Form
    {
        public viewCustomerManage()
        {
            InitializeComponent();
        }
        
        public void initTable()
        {
            List<KHACHHANG> nv = null;
            if (txtFindId.Text != "")
            {
                nv = Program.context.KHACHHANGs.Where(n => n.MAKH.ToString().Contains(txtFindId.Text) || n.TENKH.Contains(txtFindId.Text)).OrderBy(n => n.MAKH).ToList();
            }
            else nv = Program.context.KHACHHANGs.OrderBy(n => n.MAKH).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Birthday", typeof(DateTime));
            table.Columns.Add("Phone", typeof(string));
            table.Columns.Add("Address", typeof(string));
            nv.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.MAKH;
                rowDT["Name"] = x.TENKH;
                rowDT["Birthday"] = x.NGSINH;
                rowDT["Phone"] = x.SDT;
                rowDT["Address"] = x.DIACHI;
                table.Rows.Add(rowDT);
            });
            tblCustomer.DataSource = table;
        }

        private void viewCustomerManage_Load(object sender, EventArgs e)
        {
            initTable();
        }

        private void tblCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = tblCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = tblCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimeBirth.Value = (DateTime)tblCustomer.Rows[e.RowIndex].Cells[2].Value;
            txtPhone.Text = tblCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = tblCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = new KHACHHANG
            {
                TENKH = "NULL",
                NGSINH = DateTime.Now,
                SDT = "0000000000",
                DIACHI = "NULL"
            };
            Program.context.KHACHHANGs.Add(kh);
            Program.context.SaveChanges();
            kh = Program.context.KHACHHANGs.OrderByDescending(n => n.MAKH).First();
            txtId.Text = kh.MAKH.ToString();
            txtName.Text = kh.TENKH;
            dateTimeBirth.Value = kh.NGSINH;
            txtPhone.Text = kh.SDT;
            txtAddress.Text = kh.DIACHI;
            initTable();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Substring(0, 1) != "0" || txtPhone.Text.Length < 10)
            {
                MessageBox.Show("SĐT không hợp lệ");
            }else if(txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Không được để trống trường nào");
            }
            else
            {
                KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.MAKH.ToString() == txtId.Text);
                kh.TENKH = txtName.Text;
                kh.NGSINH = dateTimeBirth.Value;
                kh.SDT = txtPhone.Text;
                kh.DIACHI = txtAddress.Text;
                Program.context.SaveChanges();
                initTable();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Program.context.HOADONs.Count(n => n.MAKH.ToString() == txtId.Text) > 0)
            {
                MessageBox.Show("Khách hàng tồn tại trong Hóa đơn. Hãy xóa Hóa đơn trước");
                return;
            }
            KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.MAKH.ToString() == txtId.Text);
            Program.context.KHACHHANGs.Remove(kh);
            Program.context.SaveChanges();
            MessageBox.Show("Xóa thành công");
            txtId.Text = "";
            txtName.Text = "";
            dateTimeBirth.Value = DateTime.Today;
            txtPhone.Text = "";
            txtAddress.Text = "";
            initTable();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.TextLength > 11)
            {
                MessageBox.Show("SĐT không hợp lí\nHint: 10 hoặc 11 số :>");
                txtPhone.Text = "";
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.TextLength > 200)
            {
                MessageBox.Show("Không hơn 200 kí tự");
                txtAddress.Text = "";
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

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    {
                        KHACHHANG kh = new KHACHHANG
                        {
                            TENKH = "NULL",
                            NGSINH = DateTime.Now,
                            SDT = "0000000000",
                            DIACHI = "NULL"
                        };
                        Program.context.KHACHHANGs.Add(kh);
                        Program.context.SaveChanges();
                        kh = Program.context.KHACHHANGs.OrderByDescending(n => n.MAKH).First();
                        txtId.Text = kh.MAKH.ToString();
                        txtName.Text = kh.TENKH;
                        dateTimeBirth.Value = kh.NGSINH;
                        txtPhone.Text = kh.SDT;
                        txtAddress.Text = kh.DIACHI;
                        initTable();
                    }
                    break;
                case Keys.S:
                    {
                        if (txtPhone.Text.Substring(0, 1) != "0" || txtPhone.Text.Length < 10)
                        {
                            MessageBox.Show("SĐT không hợp lệ");
                        }
                        else if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
                        {
                            MessageBox.Show("Không được để trống trường nào");
                        }
                        else
                        {
                            KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.MAKH.ToString() == txtId.Text);
                            kh.TENKH = txtName.Text;
                            kh.NGSINH = dateTimeBirth.Value;
                            kh.SDT = txtPhone.Text;
                            kh.DIACHI = txtAddress.Text;
                            Program.context.SaveChanges();
                            initTable();
                        }
                    }
                    break;
                case Keys.Delete:
                    {
                        if (Program.context.HOADONs.Count(n => n.MAKH.ToString() == txtId.Text) > 0)
                        {
                            MessageBox.Show("Khách hàng tồn tại trong Hóa đơn. Hãy xóa Hóa đơn trước");
                            return;
                        }
                        KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.MAKH.ToString() == txtId.Text);
                        Program.context.KHACHHANGs.Remove(kh);
                        Program.context.SaveChanges();
                        MessageBox.Show("Xóa thành công");
                        txtId.Text = "";
                        txtName.Text = "";
                        dateTimeBirth.Value = DateTime.Today;
                        txtPhone.Text = "";
                        txtAddress.Text = "";
                        initTable();
                    }
                    break;
                default: return;
            }
        }

        private void txtFindId_TextChanged(object sender, EventArgs e)
        {
            initTable();
        }
    }
}
