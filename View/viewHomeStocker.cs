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
    public partial class viewHomeStocker : Form
    {
        bool Product_Menu_Child;
        private Form current;
        private Guna.UI2.WinForms.Guna2GradientButton buttonHienHanh;
        public viewHomeStocker()
        {
            InitializeComponent();
        }
        private void buttonHoatDong(object btnSender, Guna.UI2.WinForms.Guna2Panel panel)
        {
            if (btnSender != null)
            {
                if (buttonHienHanh != (Guna.UI2.WinForms.Guna2GradientButton)btnSender)
                {
                    voHieuHoaButton(panel);
                    buttonHienHanh = (Guna.UI2.WinForms.Guna2GradientButton)btnSender;
                    buttonHienHanh.FillColor = Color.FromArgb(72, 87, 171);
                    buttonHienHanh.FillColor2 = Color.FromArgb(72, 87, 171);
                    buttonHienHanh.ForeColor = Color.White;
                }
            }
        }
        private void voHieuHoaButton(Guna.UI2.WinForms.Guna2Panel panel)
        {
            foreach (Control truocButton in panel.Controls)
            {
                if (truocButton.GetType() == typeof(Guna.UI2.WinForms.Guna2GradientButton))
                {
                    Guna.UI2.WinForms.Guna2GradientButton a;
                    a = (Guna.UI2.WinForms.Guna2GradientButton)truocButton;
                    truocButton.ForeColor = Color.Black;
                    a.FillColor = Color.FromArgb(85, 103, 201);
                    a.FillColor2 = Color.FromArgb(85, 103, 201);
                }
            }
        }
        private void Show_Child_Form(Form ChildForm)
        {
            if (current != null)
            {
                current.Close();
            }
            current = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.Dock = DockStyle.Fill;
            guna2Panel_Content.Controls.Add(ChildForm);
            guna2Panel_Content.Tag = ChildForm;
            guna2Panel_Content.BringToFront();
            ChildForm.Show();

        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
        bool enumExpended = false;
        private void DetectMouse_Tick(object sender, EventArgs e)
        {
            if (!guna2Transition1.IsCompleted) return;
            if (panelMenu.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            {
                if (!enumExpended)
                {
                    enumExpended = true;
                    panelMenu.Width = 190;
                }
            }
            else
            {
                if (enumExpended)
                {
                    enumExpended = false;
                    panelMenu.Visible = false;
                    panelMenu.Width = 63;
                    guna2Transition1.Show(panelMenu);
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Visible = true;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Visible = false;
        }

        private void Open_Menu_ChildProduct()
        {
            guna2Panel_Control_CProduct.Height += 110;
            if (guna2Panel_Control_CProduct.Height == guna2Panel_Control_CProduct.MaximumSize.Height)
            {
                Product_Menu_Child = false;
                Timer_Product.Stop();
            }
        }
        private void Close_Menu_ChildProduct()
        {
            guna2Panel_Control_CProduct.Height -= 110;
            if (guna2Panel_Control_CProduct.Height == guna2Panel_Control_CProduct.MinimumSize.Height)
            {
                Product_Menu_Child = true;
                Timer_Product.Stop();
            }
        }
        private void Timer_Product_Tick(object sender, EventArgs e)
        {
            if (Product_Menu_Child)
            {
                Open_Menu_ChildProduct();

            }
            else
            {
                Close_Menu_ChildProduct();
            }
        }

        private void guna2GradientButton_Product_Click(object sender, EventArgs e)
        {
            Timer_Product.Start();
            buttonHoatDong(sender, guna2Panel_Control_Big);
        }

        private void guna2GradientButton_Home_Click(object sender, EventArgs e)
        {
            Close_Menu_ChildProduct();
            buttonHoatDong(sender, guna2Panel_Control_Big);
        }

        private void guna2GradientButton_Report_Click(object sender, EventArgs e)
        {
            Close_Menu_ChildProduct();
            buttonHoatDong(sender, guna2Panel_Control_Big);
        }

        private void guna2GradientButton_ProductManage_Click(object sender, EventArgs e)
        {
            buttonHoatDong(sender, guna2Panel_Control_CProduct);
            Show_Child_Form(new View.CF_ProcductManage());
        }

        private void guna2GradientButton_DealProduct_Click(object sender, EventArgs e)
        {
            buttonHoatDong(sender, guna2Panel_Control_CProduct);
            Show_Child_Form(new View.CF_DealProduct());
        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }
    }
}
