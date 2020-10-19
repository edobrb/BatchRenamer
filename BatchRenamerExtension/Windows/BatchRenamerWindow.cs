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
        private PathContainer sourceFilenames;
        private PathContainer destFilenames;
        private TextStyle grayStyle = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);
        private TextStyle orangeStyle = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        private TextStyle redStyle = new TextStyle(Brushes.Red, null, FontStyle.Underline);
        private TextStyle greenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        private TextStyle regexStyle = new TextStyle(null, Brushes.LightBlue, FontStyle.Bold);
        private const string PATH_REGEX = @"(^(.+)\\)";
        private const string FILENAME_REGEX = @"[^\\]+$";
        private RegexWindow regexWindow = null;
        private string renameRegex = null;
        public BatchRenamerWindow(IEnumerable<string> files)
        {
            InitializeComponent();
            sourceFilenames = new PathContainer(files);
            destFilenames = new PathContainer(files);
            Assembly assembly = Assembly.GetAssembly(typeof(BatchRenamerExtension));
            Bitmap icon = new Bitmap(assembly.GetManifestResourceStream("BatchRenamerExtension.Resources.icon.png"));
            Icon = Icon.FromHandle(icon.GetHicon());

            if (sourceFilenames.Count() == 0)
            {
                this.Close();
            }
            if (destFilenames.Count() > 100)
            {
                chkCheckPaths.Checked = false;
            }

            txbFiles.TextChanged += TxbFiles_TextChanged;
            ReprintFilenames();
        }
        private void ReprintFilenames()
        {
            txbFiles.Text = destFilenames.ToString(chkShowpathDest.Checked);
        }

        private void TxbFiles_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbFiles.Text))
            {
                return;
            }

            bool reprint = false;
            if (chkShowpathDest.Checked)
            {
                destFilenames = new PathContainer(txbFiles.Lines);
            }
            else
            {
                if (!string.IsNullOrEmpty(txbFiles.Text))
                {
                    for (int i = 0; i < txbFiles.Lines.Count && i < destFilenames.Count(); i++)
                    {
                        destFilenames.ChangeOnlyName(i, txbFiles.Lines[i]);
                        if (txbFiles.Lines[i] != destFilenames[i].ToString(false))
                        {
                            reprint = true;
                        }
                    }
                }
            }

            txbFiles.Range.ClearStyle(grayStyle, redStyle, orangeStyle, greenStyle, regexStyle);

            if (chkCheckPaths.Checked && !reprint)
            {
                for (int i = 0; i < txbFiles.Lines.Count && i < destFilenames.Count() && i < sourceFilenames.Count(); i++)
                {
                    int s = 0;
                    for (int j = 0; j < i; j++) s += txbFiles.Lines[j].Length + 2;
                    int f = 0;
                    for (int j = 0; j <= i; j++) f += txbFiles.Lines[j].Length + 2;
                    if (!string.IsNullOrEmpty(renameRegex))
                    {
                        try
                        {
                            txbFiles.GetRange(s, f).SetStyle(regexStyle, renameRegex);
                        }
                        catch { }
                    }
                    else if (sourceFilenames[i].ExistsAsDirectory)
                    {
                        if (destFilenames[i].IsValidAsDirectory(sourceFilenames[i].Value))
                        {
                            txbFiles.GetRange(s, f).SetStyle(grayStyle, PATH_REGEX);
                            if (destFilenames[i].ExistsAsDirectory)
                            {
                                txbFiles.GetRange(s, f).SetStyle(orangeStyle, FILENAME_REGEX);
                            }
                            else
                            {
                                txbFiles.GetRange(s, f).SetStyle(greenStyle, FILENAME_REGEX);
                            }
                        }
                        else
                        {
                            txbFiles.GetRange(s, f).SetStyle(redStyle);
                        }

                    }
                    else
                    {
                        if (destFilenames[i].IsValidAsFile)
                        {
                            txbFiles.GetRange(s, f).SetStyle(grayStyle, PATH_REGEX);
                            if (destFilenames[i].ExistsAsFile)
                            {
                                txbFiles.GetRange(s, f).SetStyle(orangeStyle, FILENAME_REGEX);
                            }
                            else
                            {
                                txbFiles.GetRange(s, f).SetStyle(greenStyle, FILENAME_REGEX);
                            }
                        }
                        else
                        {
                            txbFiles.GetRange(s, f).SetStyle(redStyle);
                        }
                    }

                }
            }
            else if (!chkCheckPaths.Checked && !reprint)
            {
                if (!string.IsNullOrEmpty(renameRegex))
                {
                    try
                    {
                        txbFiles.Range.SetStyle(regexStyle, renameRegex, RegexOptions.Multiline);
                    }
                    catch { }
                }
                else
                {
                    txbFiles.Range.SetStyle(grayStyle, PATH_REGEX, RegexOptions.Multiline);
                }
            }

            if (reprint)
            {
                ReprintFilenames();
            }
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool AskConfirmation(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        private void chkCheckPaths_CheckedChanged(object sender, EventArgs e)
        {
            ReprintFilenames();
        }

        private void chkShowpathDest_CheckedChanged(object sender, EventArgs e)
        {
            ReprintFilenames();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var result = Renamer.Rename(sourceFilenames, destFilenames, ShowError, AskConfirmation);
            if (result.Item2)
            {
                this.Close();
            }
            else
            {
                sourceFilenames = new PathContainer(this.sourceFilenames.Where(x => result.Item1.All(y => x.Value != y.Value)));
                destFilenames = new PathContainer(sourceFilenames);
                ReprintFilenames();
            }
        }

        private void btnRegex_Click(object sender, EventArgs e)
        {
            if (regexWindow == null)
            {
                regexWindow = new RegexWindow(this);
                regexWindow.chkShowMatches.Checked = destFilenames.Count() < 100;
                regexWindow.Closing += (sender2, e2) =>
                {
                    renameRegex = null;
                    regexWindow = null;
                    ReprintFilenames();
                };
                regexWindow.txbFrom.TextChanged += (sender2, e2) =>
                {
                    if (regexWindow.chkShowMatches.Checked)
                    {
                        renameRegex = regexWindow.txbFrom.Text;
                        ReprintFilenames();
                    }
                };
                regexWindow.chkShowMatches.CheckedChanged += (sender2, e2) =>
                {
                    if (regexWindow.chkShowMatches.Checked)
                    {
                        renameRegex = regexWindow.txbFrom.Text;
                    }
                    else
                    {
                        renameRegex = null;
                    }
                    ReprintFilenames();
                };
                regexWindow.btnApply.Click += (sender2, e2) =>
                {
                    if (!string.IsNullOrEmpty(regexWindow.txbFrom.Text))
                    {
                        try
                        {
                            for (int i = 0; i < destFilenames.Count(); i++)
                            {
                                if (chkShowpathDest.Checked)
                                {
                                    destFilenames[i].Value = Regex.Replace(destFilenames[i].Value,
                                        regexWindow.txbFrom.Text,
                                        regexWindow.txbTo.Text);
                                }
                                else
                                {
                                    destFilenames[i].ChangeOnlyName(Regex.Replace(destFilenames[i].OnlyName,
                                        regexWindow.txbFrom.Text,
                                        regexWindow.txbTo.Text));
                                }
                            }
                            regexWindow.Close();
                            regexWindow = null;
                        }
                        catch
                        {
                            ShowError("Invalid regex", "The regex '"+ regexWindow.txbFrom.Text + "' is invalid.");
                        }
                        ReprintFilenames();
                    }
                };
            }
            regexWindow.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            destFilenames = new PathContainer(sourceFilenames);
            ReprintFilenames();
        }
    }
}
