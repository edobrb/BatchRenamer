using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchRenamerExtension
{
    public partial class BatchRenamerWindow : Form
    {
        private PathContainer initialPaths;
        private RegexWindow regexWindow;
        public BatchRenamerWindow(IEnumerable<string> files)
        {
            InitializeComponent();
            
            Assembly assembly = Assembly.GetAssembly(typeof(BatchRenamerExtension));
            Bitmap icon = new Bitmap(assembly.GetManifestResourceStream("BatchRenamerExtension.Resources.icon.png"));
            Icon = Icon.FromHandle(icon.GetHicon());

            if (files.Count() == 0) this.Close();
            initialPaths = new PathContainer(files);
            pathContainerView.SetPaths(initialPaths);
            if (files.Count() > 100) chkCheckPaths.Checked = false;
        }

        private void chkCheckPaths_CheckedChanged(object sender, EventArgs e)
        {
            pathContainerView.CheckPathSanity = chkCheckPaths.Checked;
            pathContainerPreview.CheckPathSanity = chkCheckPaths.Checked;
        }
        private void chkShowpathDest_CheckedChanged(object sender, EventArgs e)
        {
            pathContainerView.ShowFullpath = chkShowpathDest.Checked;
            pathContainerPreview.ShowFullpath = chkShowpathDest.Checked;
            if (regexWindow != null) regexWindow.ShowFullpathChanged();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            var result = Renamer.Rename(initialPaths, pathContainerView.DestFilenames, FormUtils.ShowError, FormUtils.AskConfirmation);
            if (result.Item2 || result.Item1.Count > 0)
            {
                this.Close();
            }
        }
        private void btnRegex_Click(object sender, EventArgs e)
        {
            if (regexWindow == null)
            {
                regexWindow = new RegexWindow(this, pathContainerView, pathContainerPreview);
                regexWindow.Closing += (sender2, e2) => regexWindow = null;
            }
            regexWindow.Hide();
            regexWindow.Show();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            pathContainerView.SetPaths(initialPaths);
        }
    }
}
