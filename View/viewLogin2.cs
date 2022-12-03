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
    public partial class viewLogin2 : Form
    {
        public viewLogin2()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[camPick.SelectedIndex].MonikerString);
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
                txtcode.Invoke(new MethodInvoker(delegate ()
                {
                    txtcode.Text = result.ToString();
                }));
            }
            pic.Image = bitmap;
        }

        private void viewLogin_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                camPick.Items.Add(device.Name);
            camPick.SelectedIndex = 0;
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
        private void viewLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            turnOffCamera();
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            NHANVIEN nv = Program.context.NHANVIENs.FirstOrDefault(n => viewLogin.DecodeFrom64(n.PASSWORDS) == txtcode.Text);
            if (nv != null)
            {
                viewLogin.EmployeeId = nv.MANV;
                switch (nv.MANV.Substring(0, 4))
                {
                    case "NVTN":
                        {
                            viewHomeStaff vhs = new viewHomeStaff();
                            vhs.Show();
                            Hide();
                            turnOffCamera();
                        }
                        break;
                    case "NVTK":
                        {
                            viewHomeStocker vhs = new viewHomeStocker();
                            vhs.Show();
                            Hide();
                            turnOffCamera();
                        }
                        break;
                    case "QLCH":
                        {
                            viewHomeManager vhm = new viewHomeManager();
                            vhm.Show();
                            Hide();
                            turnOffCamera();
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
                MessageBox.Show("Không tìm thấy người dùng");
            }
        }
    }
}
