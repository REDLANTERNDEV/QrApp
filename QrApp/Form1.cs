using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Linq.Expressions;

namespace QrApp
{
    public partial class Form1 : MaterialForm
    {
        


        public Form1()
        {
            

            InitializeComponent();
            WebClient webClient = new WebClient();
            try
            {
                if (!webClient.DownloadString("https://raw.githubusercontent.com/REDLANTERNx/deneme/main/update.txt").Contains("1.0.0.0"))
                {
                    if (MessageBox.Show("Görünüşe gore bir güncellemen var! İndirmek ister misin?", "QrApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        using (var client = new WebClient())
                        {
                            Process.Start("QrUpdater.exe");
                            this.Close();
                        }
                }
            }
            catch
            {

            }
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow600, Primary.Grey900, Primary.Yellow600, Accent.Teal700, TextShade.WHITE);


            

            
        }
        FilterInfoCollection filter;
        VideoCaptureDevice captureDevice;
        private void Form1_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo filterInfo in filter)
                comboBox1.Items.Add(filterInfo.Name);
            
            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch
            {
                
            }

            if (comboBox1.SelectedIndex == -1)
            {
                materialButton5.Enabled = false;
            }

            materialTabControl1 = new MaterialTabControl();
            

        }
        

        /***
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Yazi kutusunu bos biraktiniz", "Hata",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                    encoder.QRCodeScale = 14;
                    Bitmap bmp=encoder.Encode(textBox1.Text);
                    pictureBox1.Image = bmp;
                    bmp.Save(sfd.FileName,ImageFormat.Jpeg);
                }
            }
        }
        ***/
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    pictureBox2.Image=Image.FromFile(ofd.FileName);
                    MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder= new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                    textBox2.Text=decoder.Decode(new QRCodeBitmapImage(pictureBox2.Image as Bitmap));
                }
            }
        } 
        */
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Yazi kutusunu bos biraktiniz", "Hata",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var options = new QrCodeEncodingOptions
            {

                Height = pictureBox1.Height,
                Width = pictureBox1.Width

            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options=options;
            var text = textBox1.Text;
            var result = writer.Write(text);
            pictureBox1.Image = result;
            
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"JPG|*.jpg;*.jpeg|PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog() { Filter = @"JPG|*.jpg;*.jpeg|PNG|*.png" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var reader = new BarcodeReader();
                var imgfile = Image.FromFile(dialog.FileName) as Bitmap;
                pictureBox2.Image = imgfile;
                var result = reader.Decode(imgfile);
                textBox4.Text = result.Text;
            }
        }

        private void materialTabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void materialTabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void materialTabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void materialTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void materialTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
            
        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            this.materialTabControl1.SelectedTab = this.tabPage3;
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://discord.gg/z4VT5QY",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.materialTabControl1.SelectedTab = this.tabPage3;
            }
        }


        private void tabPage3_Enter(object sender, EventArgs e)
        {
            
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(materialMaskedTextBox1.Text))
            {
                MessageBox.Show("Yazi kutusunu bos biraktiniz", "Hata",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
            picBarcode.Image=writer.Write(materialMaskedTextBox1.Text);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"JPG|*.jpg;*.jpeg|PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picBarcode.Image.Save(saveFileDialog.FileName);
                }
            }



        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = @"JPG|*.jpg;*.jpeg|PNG|*.png" })
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    picbarcodereader.Image=Image.FromFile(ofd.FileName);
                    BarcodeReader reader =new BarcodeReader();
                    var result =reader.Decode((Bitmap)picbarcodereader.Image);
                    if (result != null)
                    materialMaskedTextBox2.Text = result.ToString();

                    
                    
                }
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedIndex == -1)
                {

                    if (MessageBox.Show("Lutfen kameranizi takin.Uygulama yeniden baslasin mi?", "Hata", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                        this.Close();
                        return;
                    }
                    
                }
                else
                {
                    captureDevice = new VideoCaptureDevice(filter[comboBox1.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += CaptureDevice_newframe;
                    captureDevice.Start();
                    timer1.Start();
                }
            }
            catch  
            {
                
            }
            

        }

        private void CaptureDevice_newframe(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox3.Image=(Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox3.Image != null)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result =barcode.Decode((Bitmap)pictureBox3.Image);
                if(result != null)
                {
                    materialMultiLineTextBox21.Text= result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();

                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
                Task.Delay(5000);
                pictureBox3.Image = null;
                pictureBox3.Update();
                materialMultiLineTextBox21.Clear();
                materialButton4.PerformClick();

            
            
        }

        private void tabPage6_Leave(object sender, EventArgs e)
        {
            try
            {
                captureDevice.Stop();
                pictureBox3.InitialImage = null;
                pictureBox3.Image = null;
                VideoCaptureDevice videoCaptureDevice = new VideoCaptureDevice();
                videoCaptureDevice.Stop();
                if (captureDevice.IsRunning)
                {
                    pictureBox3.InitialImage = null;
                    pictureBox3.Image = null;
                    captureDevice.Stop();
                    videoCaptureDevice.Stop();
                }
                else
                {
                    return;
                }
                if (pictureBox3.Enabled)
                {
                    pictureBox3.InitialImage = null;
                    pictureBox3.Image = null;
                    captureDevice.Stop();
                    videoCaptureDevice.Stop();
                }
                else
                {
                    return;
                }
            }
            catch
            {


            }
        }
    }
}
