
namespace WatchStoreManage.View
{
    partial class viewBillReportManage
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
            Guna.Charts.WinForms.ChartFont chartFont33 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont34 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont35 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont36 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid13 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick13 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont37 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid14 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick14 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont38 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid15 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel5 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont39 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick15 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont40 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont41 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont42 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont43 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont44 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid16 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick16 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont45 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid17 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick17 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont46 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid18 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel6 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont47 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick18 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont48 = new Guna.Charts.WinForms.ChartFont();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.incomeBar = new Guna.Charts.WinForms.GunaChart();
            this.incomeBarData = new Guna.Charts.WinForms.GunaHorizontalBarDataset();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.incomePolar = new Guna.Charts.WinForms.GunaChart();
            this.incomePolarData = new Guna.Charts.WinForms.GunaPolarAreaDataset();
            this.cbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.tblBill = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtSum = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tblBill)).BeginInit();
            this.SuspendLayout();
            // 
            // incomeBar
            // 
            this.incomeBar.BackColor = System.Drawing.Color.White;
            this.incomeBar.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] {
            this.incomeBarData});
            chartFont33.FontName = "Arial";
            this.incomeBar.Legend.LabelFont = chartFont33;
            this.incomeBar.Location = new System.Drawing.Point(12, 132);
            this.incomeBar.Name = "incomeBar";
            this.incomeBar.Size = new System.Drawing.Size(515, 260);
            this.incomeBar.TabIndex = 52;
            chartFont34.FontName = "Arial";
            chartFont34.Size = 12;
            chartFont34.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.incomeBar.Title.Font = chartFont34;
            chartFont35.FontName = "Arial";
            this.incomeBar.Tooltips.BodyFont = chartFont35;
            chartFont36.FontName = "Arial";
            chartFont36.Size = 9;
            chartFont36.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.incomeBar.Tooltips.TitleFont = chartFont36;
            this.incomeBar.XAxes.GridLines = grid13;
            chartFont37.FontName = "Arial";
            tick13.Font = chartFont37;
            this.incomeBar.XAxes.Ticks = tick13;
            this.incomeBar.YAxes.GridLines = grid14;
            chartFont38.FontName = "Arial";
            tick14.Font = chartFont38;
            this.incomeBar.YAxes.Ticks = tick14;
            this.incomeBar.ZAxes.GridLines = grid15;
            chartFont39.FontName = "Arial";
            pointLabel5.Font = chartFont39;
            this.incomeBar.ZAxes.PointLabels = pointLabel5;
            chartFont40.FontName = "Arial";
            tick15.Font = chartFont40;
            this.incomeBar.ZAxes.Ticks = tick15;
            // 
            // incomeBarData
            // 
            this.incomeBarData.Label = "Bar chart";
            this.incomeBarData.TargetChart = this.incomeBar;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(372, 17);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(225, 40);
            this.guna2HtmlLabel1.TabIndex = 51;
            this.guna2HtmlLabel1.Text = "Income Statistic";
            // 
            // incomePolar
            // 
            this.incomePolar.BackColor = System.Drawing.Color.White;
            this.incomePolar.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] {
            this.incomePolarData});
            chartFont41.FontName = "Arial";
            this.incomePolar.Legend.LabelFont = chartFont41;
            this.incomePolar.Location = new System.Drawing.Point(533, 132);
            this.incomePolar.Name = "incomePolar";
            this.incomePolar.Size = new System.Drawing.Size(407, 260);
            this.incomePolar.TabIndex = 55;
            this.incomePolar.Title.Display = false;
            chartFont42.FontName = "Arial";
            chartFont42.Size = 12;
            chartFont42.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.incomePolar.Title.Font = chartFont42;
            chartFont43.FontName = "Arial";
            this.incomePolar.Tooltips.BodyFont = chartFont43;
            chartFont44.FontName = "Arial";
            chartFont44.Size = 9;
            chartFont44.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.incomePolar.Tooltips.TitleFont = chartFont44;
            this.incomePolar.XAxes.Display = false;
            this.incomePolar.XAxes.GridLines = grid16;
            chartFont45.FontName = "Arial";
            tick16.Font = chartFont45;
            this.incomePolar.XAxes.Ticks = tick16;
            this.incomePolar.YAxes.Display = false;
            this.incomePolar.YAxes.GridLines = grid17;
            chartFont46.FontName = "Arial";
            tick17.Font = chartFont46;
            this.incomePolar.YAxes.Ticks = tick17;
            this.incomePolar.ZAxes.GridLines = grid18;
            chartFont47.FontName = "Arial";
            pointLabel6.Font = chartFont47;
            this.incomePolar.ZAxes.PointLabels = pointLabel6;
            chartFont48.FontName = "Arial";
            tick18.Font = chartFont48;
            this.incomePolar.ZAxes.Ticks = tick18;
            // 
            // incomePolarData
            // 
            this.incomePolarData.Label = "PolarArea1";
            this.incomePolarData.TargetChart = this.incomePolar;
            // 
            // cbYear
            // 
            this.cbYear.BackColor = System.Drawing.Color.Transparent;
            this.cbYear.BorderRadius = 5;
            this.cbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbYear.ItemHeight = 30;
            this.cbYear.Location = new System.Drawing.Point(12, 80);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(166, 36);
            this.cbYear.TabIndex = 54;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.Color.Transparent;
            this.cbMonth.BorderRadius = 5;
            this.cbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbMonth.ItemHeight = 30;
            this.cbMonth.Location = new System.Drawing.Point(263, 80);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(166, 36);
            this.cbMonth.TabIndex = 53;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(434, 708);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(108, 15);
            this.guna2HtmlLabel6.TabIndex = 60;
            this.guna2HtmlLabel6.Text = null;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DefaultAutoSize = true;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(782, 416);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(144, 34);
            this.guna2Button1.TabIndex = 59;
            this.guna2Button1.Text = "Xóa hóa đơn";
            // 
            // tblBill
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.tblBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.tblBill.ColumnHeadersHeight = 19;
            this.tblBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblBill.DefaultCellStyle = dataGridViewCellStyle9;
            this.tblBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tblBill.Location = new System.Drawing.Point(12, 456);
            this.tblBill.Name = "tblBill";
            this.tblBill.RowHeadersVisible = false;
            this.tblBill.RowHeadersWidth = 51;
            this.tblBill.RowTemplate.Height = 24;
            this.tblBill.Size = new System.Drawing.Size(928, 246);
            this.tblBill.TabIndex = 58;
            this.tblBill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tblBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblBill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblBill.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblBill.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tblBill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tblBill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblBill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblBill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tblBill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tblBill.ThemeStyle.HeaderStyle.Height = 19;
            this.tblBill.ThemeStyle.ReadOnly = false;
            this.tblBill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblBill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblBill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblBill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tblBill.ThemeStyle.RowsStyle.Height = 24;
            this.tblBill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tblBill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txtSum
            // 
            this.txtSum.BorderRadius = 5;
            this.txtSum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSum.DefaultText = "";
            this.txtSum.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSum.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSum.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSum.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSum.Location = new System.Drawing.Point(771, 80);
            this.txtSum.Name = "txtSum";
            this.txtSum.PasswordChar = '\0';
            this.txtSum.PlaceholderText = "";
            this.txtSum.ReadOnly = true;
            this.txtSum.SelectedText = "";
            this.txtSum.Size = new System.Drawing.Size(169, 36);
            this.txtSum.TabIndex = 56;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(716, 92);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(71, 24);
            this.guna2HtmlLabel2.TabIndex = 57;
            this.guna2HtmlLabel2.Text = "Tổng:";
            // 
            // viewBillReportManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(972, 633);
            this.Controls.Add(this.incomeBar);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.incomePolar);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.tblBill);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewBillReportManage";
            this.Text = "viewBillReportManage";
            this.Load += new System.EventHandler(this.viewBillReportManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.Charts.WinForms.GunaChart incomeBar;
        private Guna.Charts.WinForms.GunaHorizontalBarDataset incomeBarData;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.Charts.WinForms.GunaChart incomePolar;
        private Guna.Charts.WinForms.GunaPolarAreaDataset incomePolarData;
        private Guna.UI2.WinForms.Guna2ComboBox cbYear;
        private Guna.UI2.WinForms.Guna2ComboBox cbMonth;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DataGridView tblBill;
        private Guna.UI2.WinForms.Guna2TextBox txtSum;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}