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
    public partial class HelpWindow : Form
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        public void SetColor(PathContainerView view)
        {
            txbEg.Range.SetStyle(view.FilenameOkStyle, "This file or directory can be renamed");
            txbEg.Range.SetStyle(view.FileLockedStyle, "This file is used by another program");
            txbEg.Range.SetStyle(view.FileOverwriteStyle, "This file or directory already exists");
            txbEg.Range.SetStyle(view.WrongFilenameStyle, "This path is invalid");
        }
    }
}
