using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchRenamerExtension
{
    public partial class RegexWindow : Form
    {
        private Form parent;
        private PathContainerView view, preview;
        public RegexWindow(Form parent, PathContainerView view, PathContainerView preview)
        {
            InitializeComponent();
            this.parent = parent;
            this.view = view;
            this.preview = preview;
        }

        private void RegexWindow_Load(object sender, EventArgs e)
        {
            Activate();
            Focus();
            txbFrom.Focus();
            Rectangle screen = Screen.FromControl(this).Bounds;
            if (screen.Width > parent.Location.X + parent.Width + Width)
            {
                Location = new Point(parent.Location.X + parent.Width, parent.Location.Y);
            }
            else
            {
                Location = new Point(parent.Location.X - Width, parent.Location.Y);
            }
        }

        private void txbFrom_TextChanged(object sender, EventArgs e)
        {
            if (chkShowMatches.Checked) view.RenameRegex = txbFrom.Text;
            RefreshPreview();
        }

        private void txbTo_TextChanged(object sender, EventArgs e)
        {
            RefreshPreview();
        }

        private void chkShowMatches_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowMatches.Checked) view.RenameRegex = txbFrom.Text;
            else view.RenameRegex = null;

            if (chkShowMatches.Checked) chkPreview.Checked = false;
        }

        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {
            preview.Visible = chkPreview.Checked;
            RefreshPreview();

            if (chkPreview.Checked) chkShowMatches.Checked = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (view.ApplyRegex(txbFrom.Text, txbTo.Text)) this.Close();
        }

        private void RegexWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            view.RenameRegex = null;
            preview.SetPaths(new PathContainer());
            preview.Visible = false;
            preview.Visible = false;
        }

        private void RefreshPreview()
        {
            if (!chkPreview.Checked) return;
            preview.SetPaths(view.SourceFilenames, string.IsNullOrEmpty(txbFrom.Text));
            preview.ApplyRegex(txbFrom.Text, txbTo.Text, false);
            preview.ClearUndo();
        }

        public void ShowFullpathChanged()
        {
            RefreshPreview();
        }
    }
}
