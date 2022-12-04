using WatchStoreManage.Model;
using System.IO;
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
    public partial class CF_ProcductManage : Form
    {
        public CF_ProcductManage()
        {
            InitializeComponent();
        }
        public void Show_Add_Edit_Product()
        {
            guna2PictureBox_Product.Enabled = true;
            guna2PictureBox_Product.Image = global::WatchStoreManage.Properties.Resources.icons8_picture_100;
            txtName.FillColor = Color.White;
            txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtName.ReadOnly = false;
            txtType.Visible = false;
            cbType.Visible = true;
            txtProducer.Visible = false;
            cbProduce.Visible = true;
            txtPurchaseprice.FillColor = Color.White;
            txtPurchaseprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtPurchaseprice.ReadOnly = false;
            txtPrice.FillColor = Color.White;
            txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtPrice.ReadOnly = false;
            txtQuanity.Visible = false;
            nbQuanity.Visible = true;
            btnSave_Add.Visible = true;
        }
        public void Show_ViewProduct()
        {
            guna2PictureBox_Product.Enabled = true;
            txtName.FillColor = System.Drawing.SystemColors.Control;
            txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtName.ReadOnly = true;
            txtType.Visible = true;
            cbType.Visible = false;
            txtProducer.Visible = true;
            cbProduce.Visible = false;
            txtPurchaseprice.FillColor = System.Drawing.SystemColors.Control;
            txtPurchaseprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtPurchaseprice.ReadOnly = true;
            txtPrice.FillColor = System.Drawing.SystemColors.Control;
            txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtPrice.ReadOnly = true;
            txtQuanity.Visible = true;
            nbQuanity.Visible = true;
            btnSave_Add.Visible = false;
            btnSave_Edit.Visible = false;
        }
        public void Show_ViewProductIF_Load()
        {
            List<SANPHAM> sp1 = Program.context.SANPHAMs.ToList();
            List<LOAISANPHAM> TypeSp = Program.context.LOAISANPHAMs.ToList();
            List<NHACUNGCAP> Nhacc = Program.context.NHACUNGCAPs.ToList();
            string tmp = DataGridView_Product.Rows[0].Cells[0].Value.ToString();
            foreach (SANPHAM sp in sp1)
            {
                if (sp.MASP == tmp)
                {
                    txtID.Text = sp.MASP;
                    txtName.Text = sp.TENSP;

                    foreach (LOAISANPHAM type in TypeSp)
                    {
                        if (sp.MALSP == type.MALSP)
                        {
                            txtType.Text = type.TENLSP;
                            cbType.Text = type.TENLSP;
                            break;
                        }

                    }
                    foreach (NHACUNGCAP ncc in Nhacc)
                    {
                        if (sp.MANCC == ncc.MANCC)
                        {
                            txtProducer.Text = ncc.TENNCC;
                            cbProduce.Text = ncc.TENNCC;
                            break;
                        }

                    }
                    txtPurchaseprice.Text = sp.GIAMUA.ToString();
                    txtPrice.Text = sp.GIABAN.ToString();
                    txtQuanity.Text = sp.SOLUONG.ToString();
                    guna2PictureBox_Product.Image = byteArrayToImage(sp.HinhAnh);
                    break;

                }
            }
        }
        public void Clear_Text()
        {
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtPurchaseprice.Clear();
        }
        public void initTable(List<SANPHAM> sp)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Quanity", typeof(int));
            sp.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["ID"] = x.MASP;
                rowDT["Name"] = x.TENSP;
                rowDT["Quanity"] = x.SOLUONG;
                table.Rows.Add(rowDT);
            });
            DataGridView_Product.DataSource = table;
        }

        //ảnh -> byte[]
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        //byte[] -> ảnh
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Show_Add_Edit_Product();
            Clear_Text();
        }

        private void CF_ProcductManage_Load(object sender, EventArgs e)
        {
            List<SANPHAM> sp1 = Program.context.SANPHAMs.ToList();
            initTable(sp1);
            Show_ViewProductIF_Load();
            var produce = Program.context.NHACUNGCAPs.ToList();
            cbProduce.DataSource = produce;
            cbProduce.DisplayMember = "TENNCC";
            var type = Program.context.LOAISANPHAMs.ToList();
            cbType.DataSource = type;
            cbType.DisplayMember = "TENLSP";
        }

        private void DataGridView_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<SANPHAM> sp1 = Program.context.SANPHAMs.ToList();
            List<LOAISANPHAM> TypeSp = Program.context.LOAISANPHAMs.ToList();
            List<NHACUNGCAP> Nhacc = Program.context.NHACUNGCAPs.ToList();
            string tmp = DataGridView_Product.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (SANPHAM sp in sp1)
            {
                if (sp.MASP == tmp)
                {
                    txtID.Text = sp.MASP;
                    txtName.Text = sp.TENSP;

                    foreach (LOAISANPHAM type in TypeSp)
                    {
                        if (sp.MALSP == type.MALSP)
                        {
                            txtType.Text = type.TENLSP;
                            cbType.Text = type.TENLSP;
                            break;
                        }

                    }
                    foreach (NHACUNGCAP ncc in Nhacc)
                    {
                        if (sp.MANCC == ncc.MANCC)
                        {
                            txtProducer.Text = ncc.TENNCC;
                            cbProduce.Text = ncc.TENNCC;
                            break;
                        }

                    }
                    txtPurchaseprice.Text = sp.GIAMUA.ToString();
                    txtPrice.Text = sp.GIABAN.ToString();
                    txtQuanity.Text = sp.SOLUONG.ToString();
                    guna2PictureBox_Product.Image = byteArrayToImage(sp.HinhAnh);
                    break;

                }
            }

        }

        private void guna2PictureBox_Product_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select Picture";
            openFileDialog1.Filter = "Windows Bitmap|*.bmp|JPEG Image|*.jpg|All Files|*.*";
            DialogResult result = openFileDialog1.ShowDialog();

            //Kiểm tra xem người dùng đã chọn file chưa
            if (result == DialogResult.OK)
            {
                // Lấy hình ảnh
                Image img = Image.FromFile(openFileDialog1.FileName);
                guna2PictureBox_Product.Image = img;
            }
        }

        private void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nội dung tìm kiếm trống!");
                return;
            }
            else if (Program.context.SANPHAMs.Count(n => n.TENSP == txtSearch.Text) == 0)
            {
                MessageBox.Show("Sản phẩm không tồn tại!");
                return;
            }
            else
            {

                List<SANPHAM> listsp = Program.context.SANPHAMs.Where(n => n.TENSP.Contains(txtSearch.Text)).OrderBy(n => n.TENSP).ToList();
                initTable(listsp);
                Show_ViewProduct();
                Show_ViewProductIF_Load();
            }
        }

        private void btnSave_Edit_Click(object sender, EventArgs e)
        {
            LOAISANPHAM lsp = Program.context.LOAISANPHAMs.FirstOrDefault(n => n.TENLSP == cbType.Text);
            NHACUNGCAP ncc = Program.context.NHACUNGCAPs.FirstOrDefault(n => n.TENNCC == cbProduce.Text);
            SANPHAM sp = Program.context.SANPHAMs.FirstOrDefault(n => n.MASP == txtID.Text);
            sp.MALSP = lsp.MALSP;
            sp.MANCC = ncc.MANCC;
            sp.TENSP = txtName.Text;
            sp.SOLUONG = Convert.ToInt32(nbQuanity.Value);
            sp.GIABAN = Convert.ToDecimal(txtPrice.Text);
            sp.GIAMUA = Convert.ToDecimal(txtPurchaseprice.Text);
            sp.HinhAnh = imageToByteArray(guna2PictureBox_Product.Image);
            Program.context.SaveChanges();
            MessageBox.Show("Sửa thành công");
            List<SANPHAM> listsp = Program.context.SANPHAMs.ToList();
            initTable(listsp);
            Show_ViewProduct();
            Show_ViewProductIF_Load();
        }

        private void btnSave_Add_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cbType.Text == "" || cbProduce.Text == "" || txtPurchaseprice.Text == "" || txtPrice.Text == "" || nbQuanity.Value == 0)
            {
                MessageBox.Show("Không được để trống trường nào");
            }
            else
            {
                btnSave_Add.Visible = true;
                btnSave_Edit.Visible = false;
                LOAISANPHAM lsp = Program.context.LOAISANPHAMs.FirstOrDefault(n => n.TENLSP == cbType.Text);
                NHACUNGCAP ncc = Program.context.NHACUNGCAPs.FirstOrDefault(n => n.TENNCC == cbProduce.Text);
                SANPHAM sp = new SANPHAM();
                sp.MASP = txtID.Text;
                sp.MALSP = lsp.MALSP;
                sp.MANCC = ncc.MANCC;
                sp.TENSP = txtName.Text;
                sp.SOLUONG = Convert.ToInt32(nbQuanity.Value);
                sp.GIABAN = Convert.ToDecimal(txtPrice.Text);
                sp.GIAMUA = Convert.ToDecimal(txtPurchaseprice.Text);
                sp.HinhAnh = imageToByteArray(guna2PictureBox_Product.Image);
                Program.context.SANPHAMs.Add(sp);
                Program.context.SaveChanges();
                MessageBox.Show("Thêm thành công");
                List<SANPHAM> listsp = Program.context.SANPHAMs.ToList();
                initTable(listsp);
                Show_ViewProduct();
                Show_ViewProductIF_Load();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Program.context.CTHDs.Count(n => n.MASP == txtID.Text) > 0)
            {
                MessageBox.Show("Sản phẩm tồn tại trong chi tiết hóa đơn. Xóa sản phẩm trong chi tiết hóa đơn trước");
                return;
            }
            SANPHAM sp = Program.context.SANPHAMs.FirstOrDefault(n => n.MASP == txtID.Text);
            Program.context.SANPHAMs.Remove(sp);
            Program.context.SaveChanges();
            MessageBox.Show("Xóa thành công");
            List<SANPHAM> listsp = Program.context.SANPHAMs.ToList();
            initTable(listsp);
            Show_ViewProduct();
            Show_ViewProductIF_Load();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Show_Add_Edit_Product();
            btnSave_Add.Visible = false;
            btnSave_Edit.Visible = true;
        }

        private void btnSort_All_Click(object sender, EventArgs e)
        {
            List<SANPHAM> sp1 = Program.context.SANPHAMs.ToList();
            initTable(sp1);
            Show_ViewProductIF_Load();
        }

        private void btnSort_Asc_Click(object sender, EventArgs e)
        {
            List<SANPHAM> sp = Program.context.SANPHAMs.OrderBy(n => n.SOLUONG).ToList();
            initTable(sp);
            Show_ViewProductIF_Load();
        }

        private void btnSort_Dec_Click(object sender, EventArgs e)
        {
            List<SANPHAM> sp = Program.context.SANPHAMs.OrderByDescending(n => n.SOLUONG).ToList();
            initTable(sp);
            Show_ViewProductIF_Load();
        }

        private void nbQuanity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPurchaseprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
