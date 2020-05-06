using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launcher
{
    public partial class MainForm : Form
    {
        private string dest;
        private string unzipDest = "unzip";
        private Launcher launcher;

        public MainForm(Launcher launcher, WebClient client, Uri uri, string dest)
        {
            InitializeComponent();
            this.Text = "PyMODA launcher";

            this.launcher = launcher; 
            this.dest = dest;

            this.Download(client, uri, dest);
        }

        private void Download(WebClient client, Uri uri, string dest)
        {
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnProgressChanged);
            client.DownloadFileAsync(uri, dest);
        }

        private void OnProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progress.Value = e.ProgressPercentage;
        }

        private void OnDownloadCompleted(object sender, AsyncCompletedEventArgs a)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (s, e) =>
            {
                this.Extract();
                this.Cleanup();
            };

            worker.RunWorkerCompleted += (s, e) =>
            {
                this.LaunchPyMODA();
                this.Close();
            };

            this.labelStatus.Text = "Installing...";
            this.progress.Style = ProgressBarStyle.Marquee;

            worker.RunWorkerAsync();
        }

        private void Extract()
        {
            if (Directory.Exists(this.unzipDest))
            {
                Directory.Delete(this.unzipDest, true);
            }

            // First, unzip to a temporary directory.
            ZipFile.ExtractToDirectory(this.dest, this.unzipDest);

            // Then rename the directory. This prevents a possible problem where the 
            // program is killed while halfway through the extraction process.
            Directory.Move(Path.Combine(this.unzipDest, "PyMODA"), "PyMODA");
        }

        private void Cleanup()
        {
            File.Delete(this.dest);
            Directory.Delete(this.unzipDest, true);
        }

        private void LaunchPyMODA()
        {
            this.launcher.LaunchPyMODA();
        }
    }
}
