using AForge.Video;
using AForge.Video.DirectShow;
using WatchStoreManage.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace WatchStoreManage.View
{
    public partial class viewLogin : Form
    {
        public static String EmployeeId = "";
        public viewLogin()
        {
            InitializeComponent();
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
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        private void viewLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnQr_Click(object sender, EventArgs e)
        {
            openChildForm(new viewLogin2());
        }

        private void chbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = chbShowPass.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" && txtPass.Text == "")
            {
                MessageBox.Show("please fill username and password");
                return;
            }
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => n.MANV == txtId.Text);
            if (nv != null)
            {
                EmployeeId = nv.MANV;
                if (txtPass.Text == DecodeFrom64(nv.PASSWORDS))
                {
                    switch (nv.MANV.Substring(0, 4))
                    {
                        case "NVTN":
                            {
                                viewHomeStaff vhs = new viewHomeStaff();
                                vhs.Show();
                                Hide();
                            }
                            break;
                        case "NVTK":
                            {
                                viewHomeStocker vhs = new viewHomeStocker();
                                vhs.Show();
                                Hide();
                            }
                            break;
                        case "QLCH":
                            {
                                viewHomeManager vhm = new viewHomeManager();
                                vhm.Show();
                                Hide();
                            }
                            break;
                        default:
                            {
                                return;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong password");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Can not find this user");
                return;
            }
        }
            
    }
}
