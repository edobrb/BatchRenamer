using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using SharpShell.SharpIconHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchRenamerExtension
{
    //Thank to Dave Kerr
    //https://www.codeproject.com/Articles/512956/NET-Shell-Extensions-Shell-Context-Menus
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFilesAndFolders)]
    public class BatchRenamerExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
           // List<string> files = SelectedItemPaths.ToList();
            ContextMenuStrip menu = new ContextMenuStrip();
            Assembly assembly = Assembly.GetAssembly(typeof(BatchRenamerExtension));
            Bitmap icon = new Bitmap(assembly.GetManifestResourceStream("BatchRenamerExtension.Resources.icon.png"));
            var itemCountLines = new ToolStripMenuItem
            {
                Text = "Rename batch",
                Image = icon
            };
            itemCountLines.Click += (sender, args) =>
            {
                BatchRenamerWindow renamer = new BatchRenamerWindow(SelectedItemPaths);
                renamer.Show();
            };
            menu.Items.Add(itemCountLines);
            return menu;
        }
    }
}
