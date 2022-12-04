using System;
using WatchStoreManage.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WatchStoreManage.View
{
    public partial class CF_DealProduct : Form
    {
        public CF_DealProduct()
        {
            InitializeComponent();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            txtNewprice.Visible = true;
            DataGridView_Product_Inventory.Visible = true;
            DataGridView_Product_Deal.Visible = false;
        }

        private void btnListdeal_Click(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
            txtNewprice.Visible = true;
            DataGridView_Product_Inventory.Visible = false;
            DataGridView_Product_Deal.Visible = true;
        }
        public void initTable(List<SANPHAM> sp)
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("ID", typeof(string));
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Quanity", typeof(int));
            sp.ForEach(x =>
            {
                var rowDT = tb.NewRow();
                rowDT["ID"] = x.MASP;
                rowDT["Name"] = x.TENSP;
                rowDT["Quanity"] = x.SOLUONG;
                tb.Rows.Add(rowDT);
            });
            DataGridView_Product_Inventory.DataSource = tb;
        }

        private void CF_DealProduct_Load(object sender, EventArgs e)
        {
            List<SANPHAM> sp2 = Program.context.SANPHAMs.Where(n => n.SOLUONG >= 50).ToList();
            initTable(sp2);
        }

        private void guna2Panel_ShowProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView_Product_Deal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<SANPHAM> sp1 = Program.context.SANPHAMs.ToList();
            List<LOAISANPHAM> TypeSp = Program.context.LOAISANPHAMs.ToList();
            List<NHACUNGCAP> Nhacc = Program.context.NHACUNGCAPs.ToList();
            string tmp = DataGridView_Product_Inventory.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (SANPHAM sp in sp1)
            {
                if (sp.MASP == tmp)
                {
                    txtName.Text = sp.TENSP;
                    foreach (LOAISANPHAM type in TypeSp)
                    {
                        if (sp.MALSP == type.MALSP)
                        {
                            txtType.Text = type.TENLSP;
                            break;
                        }

                    }
                    foreach (NHACUNGCAP ncc in Nhacc)
                    {
                        if (sp.MANCC == ncc.MANCC)
                        {
                            txtProducer.Text = ncc.TENNCC;
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

        private void txtNewprice_IconRightClick(object sender, EventArgs e)
        {
            SANPHAM sp = Program.context.SANPHAMs.FirstOrDefault(n => n.TENSP == txtName.Text);
            sp.GIABAN = Convert.ToDecimal(txtNewprice.Text);
            Program.context.SaveChanges();
            MessageBox.Show("Sửa thành công");
            List<SANPHAM> listsp = Program.context.SANPHAMs.Where(n => n.SOLUONG >= 50).ToList();
            initTable(listsp);
        }

        private void DataGridView_Product_Inventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<SANPHAM> sp1 = Program.context.SANPHAMs.Where(n => n.SOLUONG >= 50).ToList();
            List<LOAISANPHAM> TypeSp = Program.context.LOAISANPHAMs.ToList();
            List<NHACUNGCAP> Nhacc = Program.context.NHACUNGCAPs.ToList();
            string tmp = DataGridView_Product_Inventory.Rows[e.RowIndex].Cells[0].Value.ToString();
            foreach (SANPHAM sp in sp1)
            {
                if (sp.MASP == tmp)
                {
                    txtName.Text = sp.TENSP;
                    foreach (LOAISANPHAM type in TypeSp)
                    {
                        if (sp.MALSP == type.MALSP)
                        {
                            txtType.Text = type.TENLSP;
                            break;
                        }

                    }
                    foreach (NHACUNGCAP ncc in Nhacc)
                    {
                        if (sp.MANCC == ncc.MANCC)
                        {
                            txtProducer.Text = ncc.TENNCC;
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
    }
}
