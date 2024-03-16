using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;


namespace QrUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WebClient webClient = new WebClient();
            var client = new WebClient();

            try
            {
                System.Threading.Thread.Sleep(5000);
                File.Delete(@".\QrApp.exe");
                client.DownloadFile("https://tearing-sky.000webhostapp.com/update/Qrappupdate.zip", @"Qrappupdate.zip");
                string zipPath = @".\Qrappupdate.zip";
                string extractPath = @".\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete(@".\Qrappupdate.zip");
                Process.Start(@".\QrApp.exe");
                this.Close();
            }
            catch
            {
                Process.Start("QrApp.exe");
                this.Close();
            }
        }
    }
}
