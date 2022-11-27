using AForge.Video;
using AForge.Video.DirectShow;
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
using ZXing;

namespace WatchStoreManage.View
{
    public partial class viewBillPaying : Form
    {
        public static String billId = "";
        int customerId;
        public viewBillPaying()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void viewBillPaying_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                cbCamera.Items.Add(device.Name);
            cbCamera.SelectedIndex = 1;
            cbStatus.SelectedIndex = 1;
            initTableBill();
            time.Start();
        }
        public void initTableBillDetail()
        {
            List<CTHD> cthd = Program.context.CTHDs.Where(n => n.SOHD.ToString() == txtId.Text).ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Đơn giá", typeof(decimal));
            table.Columns.Add("Số lượng", typeof(int));
            cthd.ForEach(x =>
            {
                SANPHAM sp = Program.context.SANPHAMs.FirstOrDefault(n => n.MASP == x.MASP);
                var rowDT = table.NewRow();
                rowDT["Id"] = x.MASP;
                rowDT["Tên"] = sp.TENSP;
                rowDT["Đơn giá"] = sp.GIABAN;
                rowDT["Số lượng"] = x.SOLUONG;
                table.Rows.Add(rowDT);
            });
            tblBillDetail.DataSource = table;
        }
        public void initTableBill()
        {
            List<HOADON> hd = null;
            if (txtFind != null)
            {
                hd = Program.context.HOADONs.Where(n => n.TRANGTHAI == "Chưa thanh toán" && (n.SOHD.ToString().Contains(txtFind.Text) || n.MANV.Contains(txtFind.Text) || n.MAKH.ToString().Contains(txtFind.Text))).ToList();
            }
            else hd = Program.context.HOADONs.Where(n => n.TRANGTHAI == "Chưa thanh toán").ToList();
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("NV", typeof(string));
            table.Columns.Add("KH", typeof(string));
            table.Columns.Add("Thời gian", typeof(DateTime));
            hd.ForEach(x =>
            {
                var rowDT = table.NewRow();
                rowDT["Id"] = x.SOHD;
                rowDT["NV"] = x.MANV;
                rowDT["KH"] = x.MAKH;
                rowDT["Thời gian"] = x.NGAYLAPHOADON;
                table.Rows.Add(rowDT);
            });
            tblBill.DataSource = table;
        }
        public void turnOffCamera()
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    videoCaptureDevice = null;
                }
            }
        }
        private void pic_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            if (result != null)
            {
                barcode.Invoke(new MethodInvoker(delegate ()
                {
                    barcode.Text = result.ToString();
                }));
            }
            pic.Image = bitmap;
        }

        private void viewBillPaying_FormClosing(object sender, FormClosingEventArgs e)
        {
            turnOffCamera();
        }
        private void pic_DoubleClick(object sender, EventArgs e)
        {
            turnOffCamera();
        }
        private void barcode_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;
            if (Program.context.SANPHAMs.Count(n => n.MASP == barcode.Text) == 0) return;
            CTHD cthd = Program.context.CTHDs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text && n.MASP == barcode.Text);
            if (cthd != null)
            {
                cthd.SOLUONG += 1;
                Program.context.SaveChanges();
            }
            else
            {
                CTHD newDetail = new CTHD
                {
                    SOHD = Convert.ToInt32(txtId.Text),
                    MASP = barcode.Text,
                    SOLUONG = 1
                };
                Program.context.CTHDs.Add(newDetail);
                Program.context.SaveChanges();
            }
            initTableBillDetail();
            using (var sqlConnection = new SqlConnection(Program.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand("SELECT THANHTIENHD FROM HOADON WHERE SOHD = @id", sqlConnection);
                sql.Parameters.Add(new SqlParameter("id", Convert.ToInt32(txtId.Text)));
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtSum.Text = reader[0].ToString();
                    }
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CTHD hd = Program.context.CTHDs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text && n.MASP == txtProductId.Text);
            hd.SOLUONG = (int)nudAmount.Value;
            Program.context.SaveChanges();
        }

        private void tblBillDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = tblBillDetail.Rows[e.RowIndex].Cells[0].Value.ToString();
            nudAmount.Value = (int)tblBillDetail.Rows[e.RowIndex].Cells[3].Value;
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;
            if (nudAmount.Value == 0) return;
            CTHD cthd = Program.context.CTHDs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text && n.MASP == txtProductId.Text);
            cthd.SOLUONG = (int)nudAmount.Value;
            Program.context.SaveChanges();
            initTableBillDetail();
        }

        private void tblBillDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CTHD cthd = Program.context.CTHDs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text && n.MASP == txtProductId.Text);
                Program.context.CTHDs.Remove(cthd);
                Program.context.SaveChanges();
                txtProductId.Text = "";
                nudAmount.Value = 0;
                using (var sqlConnection = new SqlConnection(Program.connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sql = new SqlCommand("SELECT THANHTIENHD FROM HOADON WHERE SOHD = @id", sqlConnection);
                    sql.Parameters.Add(new SqlParameter("id", Convert.ToInt32(txtId.Text)));
                    using (SqlDataReader reader = sql.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtSum.Text = reader[0].ToString();
                        }
                    }
                }
            }
            else return;
        }

        private void tblBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = tblBill.Rows[e.RowIndex].Cells[0].Value.ToString();
            HOADON hd = Program.context.HOADONs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text);
            KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.MAKH == hd.MAKH);
            txtPhone.Text = kh.SDT;
            tblBillDetail.DataSource = null;
            initTableBillDetail();
            using (var sqlConnection = new SqlConnection(Program.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand("SELECT THANHTIENHD FROM HOADON WHERE SOHD = @id", sqlConnection);
                sql.Parameters.Add(new SqlParameter("id", Convert.ToInt32(txtId.Text)));
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtSum.Text = reader[0].ToString();
                    }
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            initTableBill();
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    {
                        HOADON newBill = new HOADON
                        {
                            MAKH = 9,
                            MANV = viewLogin.EmployeeId,
                            NGAYLAPHOADON = DateTime.Now,
                            TRANGTHAI = cbStatus.SelectedItem.ToString()
                        };
                        Program.context.HOADONs.Add(newBill);
                        Program.context.SaveChanges();
                        HOADON hd = Program.context.HOADONs.OrderByDescending(n => n.SOHD).First();
                        txtId.Text = hd.SOHD.ToString();
                        barcode.Text = "";
                        txtProductId.Text = "";
                        nudAmount.Value = 0;
                        txtPhone.Text = "";
                        txtSum.Text = "";
                        tblBillDetail.DataSource = null;
                        initTableBill();
                    }
                    break;
                case Keys.S:
                    {
                        if (txtId.Text == "") return;
                        if(txtPhone.Text != "")
                        {
                            KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.SDT == txtPhone.Text);
                            if(kh == null)
                            {
                                MessageBox.Show("Không có Khách hàng này");
                                return;
                            }
                            customerId = kh.MAKH;
                            HOADON hd = Program.context.HOADONs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text);
                            hd.TRANGTHAI = cbStatus.SelectedItem.ToString();
                            hd.NGAYLAPHOADON = DateTime.Now;
                            hd.MAKH = customerId;
                            Program.context.SaveChanges();
                        }
                        else {
                            HOADON hd = Program.context.HOADONs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text);
                            hd.TRANGTHAI = cbStatus.SelectedItem.ToString();
                            hd.NGAYLAPHOADON = DateTime.Now;
                            Program.context.SaveChanges();
                        }
                        initTableBill();
                    }
                    break;
                case Keys.Delete:
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
                        txtProductId.Text = "";
                        nudAmount.Value = 0;
                        barcode.Text = "";
                        txtPhone.Text = "";
                        txtSum.Text = "";
                        tblBillDetail.DataSource = null;
                        initTableBill();
                    }
                    break;
                case Keys.P:
                    {
                        if (txtId.Text == "") return;
                        if (txtPhone.Text != "")
                        {
                            KHACHHANG kh = Program.context.KHACHHANGs.FirstOrDefault(n => n.SDT == txtPhone.Text);
                            if (kh == null)
                            {
                                MessageBox.Show("Không có Khách hàng này");
                                return;
                            }
                            customerId = kh.MAKH;
                            HOADON hd1 = Program.context.HOADONs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text);
                            hd1.TRANGTHAI = cbStatus.SelectedItem.ToString();
                            hd1.NGAYLAPHOADON = DateTime.Now;
                            hd1.MAKH = customerId;
                            Program.context.SaveChanges();
                        }
                        billId = txtId.Text;
                        HOADON hd = Program.context.HOADONs.FirstOrDefault(n => n.SOHD.ToString() == txtId.Text);
                        hd.TRANGTHAI = cbStatus.SelectedItem.ToString();
                        hd.NGAYLAPHOADON = DateTime.Now;
                        Program.context.SaveChanges();
                        viewBillPrint viewBillPrint = new viewBillPrint();
                        viewBillPrint.Show();
                    }
                    break;
                default:
                    {
                        return;
                    }
            }
        }

        private void time_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.TextLength > 11 )
            {
                MessageBox.Show("SĐT không hợp lí\nHint: 10 hoặc 11 số :>");
                txtPhone.Text = "";
            }
        }
    }
}
