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
        public RegexWindow(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void RegexWindow_Load(object sender, EventArgs e)
        {
            var screen = Screen.FromControl(this).Bounds;
            if (screen.Width > parent.Location.X + parent.Width + this.Width)
            {
                this.Location = new Point(parent.Location.X + parent.Width, parent.Location.Y);
            }
            else
            {
                this.Location = new Point(parent.Location.X - this.Width, parent.Location.Y);
            }
        }
    }
}
