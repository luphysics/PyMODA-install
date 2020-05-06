using System.Diagnostics;
using System.IO;

namespace launcher
{
    public class Launcher
    {
        private readonly string installDir;
        private readonly string[] args;

        public Launcher(string installDir, string[] args)
        {
            this.installDir = installDir;
            this.args = args;
        }

        public void LaunchPyMODA()
        {
            var path = Path.Combine(this.installDir, "PyMODA.exe");

            var proc = new Process();
            proc.StartInfo.FileName = path;
            proc.StartInfo.Arguments = string.Join(" ", args);

            proc.Start();
        }
    }
}