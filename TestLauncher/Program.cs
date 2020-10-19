using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLauncher
{
    static class Program
    {
        const int NUMBER_OF_TEST_FILES = 1000;
        const int NUMBER_OF_TEST_DIRECTORY = 1000;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<string> files = new List<string>();
            if (!Directory.Exists("test"))
            {
                Directory.CreateDirectory("test");
            }
            else
            {
                foreach (var f in Directory.GetFiles("test"))
                {
                    File.Delete(f);
                }
                foreach (var d in Directory.GetDirectories("test"))
                {
                    Directory.Delete(d);
                }
            }
            for (int i = 1; i <= NUMBER_OF_TEST_FILES; i++)
            {
                var filename = "test\\" + i + ".txt";
                File.WriteAllText(filename, i.ToString());
                files.Add(new FileInfo(filename).FullName);
            }
            for (int i = 1; i <= NUMBER_OF_TEST_FILES; i++)
            {
                var directoryName = "test\\d" + i + "";
                Directory.CreateDirectory(directoryName);
                files.Add(new FileInfo(directoryName).FullName);
            }
            Application.Run(new BatchRenamerExtension.BatchRenamerWindow(files));
        }
    }
}
