
namespace WatchStoreManage.View
{
    partial class viewBillPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.qUANLYCUAHANGDHDataSet = new WatchStoreManage.QUANLYCUAHANGDHDataSet();
            this.qUANLYCUAHANGDHDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cTHDTableAdapter = new WatchStoreManage.QUANLYCUAHANGDHDataSetTableAdapters.CTHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qUANLYCUAHANGDHDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUANLYCUAHANGDHDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTHDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.cTHDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WatchStoreManage.View.viewBillPrint.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // qUANLYCUAHANGDHDataSet
            // 
            this.qUANLYCUAHANGDHDataSet.DataSetName = "QUANLYCUAHANGDHDataSet";
            this.qUANLYCUAHANGDHDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qUANLYCUAHANGDHDataSetBindingSource
            // 
            this.qUANLYCUAHANGDHDataSetBindingSource.DataSource = this.qUANLYCUAHANGDHDataSet;
            this.qUANLYCUAHANGDHDataSetBindingSource.Position = 0;
            // 
            // cTHDBindingSource
            // 
            this.cTHDBindingSource.DataMember = "CTHD";
            this.cTHDBindingSource.DataSource = this.qUANLYCUAHANGDHDataSetBindingSource;
            // 
            // cTHDTableAdapter
            // 
            this.cTHDTableAdapter.ClearBeforeFill = true;
            // 
            // viewBillPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewBillPrint";
            this.Text = "viewBillPrint";
            this.Load += new System.EventHandler(this.viewBillPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qUANLYCUAHANGDHDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUANLYCUAHANGDHDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTHDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QUANLYCUAHANGDHDataSet qUANLYCUAHANGDHDataSet;
        private System.Windows.Forms.BindingSource qUANLYCUAHANGDHDataSetBindingSource;
        private System.Windows.Forms.BindingSource cTHDBindingSource;
        private QUANLYCUAHANGDHDataSetTableAdapters.CTHDTableAdapter cTHDTableAdapter;
    }
}