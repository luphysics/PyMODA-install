using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var pymodaFolder = Path.Combine(appData, "PyMODA");

            Directory.SetCurrentDirectory(pymodaFolder);
            Launcher launcher; 

            var normalInstalledFolder = Path.Combine(pymodaFolder, "PyMODA");

            // If the directory exists, PyMODA is already installed.
            if (Directory.Exists(normalInstalledFolder)) 
            {
                launcher = new Launcher(normalInstalledFolder, args);

                launcher.LaunchPyMODA();
                return;
            }

            launcher = new Launcher(normalInstalledFolder, args); // TODO

            var client = new WebClient();

            var uri = new Uri("https://github.com/luphysics/PyMODA/releases/latest/download/PyMODA-win64.zip");
            var dest = "pymoda.zip";

            var form = new MainForm(launcher, client, uri, dest);
            form.StartPosition = FormStartPosition.CenterScreen;

            Application.Run(form);
        }
    }
}
