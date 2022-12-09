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
    public partial class viewHomeManager : Form
    {
        public viewHomeManager()
        {
            InitializeComponent();
        }
        private void viewHomeManager_Load(object sender, EventArgs e)
        {
            openChildForm(new viewMainHomeManager());
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new viewMainHomeManager());
        }

        private void btnProMana_Click(object sender, EventArgs e)
        {
            openChildForm(new viewEmployeeManage());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAccMana_Click(object sender, EventArgs e)
        {
            openChildForm(new viewAccountManage());
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            viewLogin viewLogin = new viewLogin();
            viewLogin.Show();
            Hide();
        }

        private void btnReportProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new viewReportManage());
        }

        private void btnReportBill_Click(object sender, EventArgs e)
        {
            openChildForm(new viewBillReportManage());
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
    }
}