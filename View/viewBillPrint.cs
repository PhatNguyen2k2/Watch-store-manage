using Microsoft.Reporting.WinForms;
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
    public partial class viewBillPrint : Form
    {
        public viewBillPrint()
        {
            InitializeComponent();
        }

        private void viewBillPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUANLYCUAHANGDHDataSet.CTHD' table. You can move, or remove it, as needed.
            this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("billId", viewBillPaying.billId));
            using (var sqlConnection = new SqlConnection(Program.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sql1 = new SqlCommand("select THANHTIENHD, TRANGTHAI, NGAYLAPHOADON, MAKH, MANV from HOADON WHERE SOHD = @Id", sqlConnection);
                sql1.Parameters.Add(new SqlParameter("Id", Convert.ToInt32(viewBillPaying.billId)));
                using (SqlDataReader reader = sql1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Sum", reader[0].ToString()));
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Status", reader[1].ToString()));
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Time", reader[2].ToString()));
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("customerId", reader[3].ToString()));
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Cashier", reader[4].ToString()));
                    }
                }
            }
            var sql = "select sp.TENSP as Name, CTHD.SOLUONG as Amount, CTHD.THANHTIENSP as Price from SANPHAM sp, CTHD where sp.MASP = CTHD.MASP AND CTHD.SOHD = @Id";
            var tableAdapter = new System.Data.SqlClient.SqlDataAdapter(sql, Program.connectionString);
            tableAdapter.SelectCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(viewBillPaying.billId)));
            var dataTable = new DataTable();
            tableAdapter.Fill(dataTable);
            ReportDataSource rds = new ReportDataSource("DataSet1", dataTable);
            this.reportViewer.LocalReport.DataSources.Add(rds);
            this.reportViewer.RefreshReport();
        }
    }
}
