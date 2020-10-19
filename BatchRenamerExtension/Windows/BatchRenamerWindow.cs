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
            sourceFilenames = new PathContainer(files/*.OrderBy(v => v)*/);
            destFilenames = new PathContainer(files/*.OrderBy(v => v)*/);
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
            ReprintFilenames(false);
            txbFiles.ClearUndo();
        }
        private void ReprintFilenames(bool updateDestination = true)
        {
            if(!updateDestination) txbFiles.TextChanged -= TxbFiles_TextChanged;
            txbFiles.Text = destFilenames.ToString(chkShowpathDest.Checked);
            if (!updateDestination)
            {
                txbFiles.TextChanged += TxbFiles_TextChanged;
                ReprintColoration(txbFiles.Range);
            }
        }
        private void TxbFiles_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbFiles.Text))
            {
                return;
            }
            UpdateDestinatinoPath(e.ChangedRange);
            ReprintColoration(e.ChangedRange);
        }
        private void UpdateDestinatinoPath(Range range)
        {
            if (chkShowpathDest.Checked)
            {
                for (int i = 0; i < txbFiles.Lines.Count && i < destFilenames.Count(); i++)
                {
                    if (i < range.Start.iLine || i > range.End.iLine) continue;
                    if (destFilenames[i].CompletePath == txbFiles.Lines[i]) continue;
                    destFilenames[i].CompletePath = txbFiles.Lines[i];
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txbFiles.Text))
                {
                    for (int i = 0; i < txbFiles.Lines.Count && i < destFilenames.Count(); i++)
                    {
                        if (i < range.Start.iLine || i > range.End.iLine) continue;
                        if (destFilenames[i].OnlyName == txbFiles.Lines[i]) continue;
                        destFilenames[i].OnlyName = txbFiles.Lines[i];
                        if (destFilenames[i].OnlyName != txbFiles.Lines[i]) //add a \ in the name
                        {
                            txbFiles[i].Clear();
                            txbFiles[i].AddRange(destFilenames[i].OnlyName.Select(c => new FastColoredTextBoxNS.Char(c)));
                        }
                    }
                }
            }
        }
        private void ResetRegexStyles(Range range)
        {
            range.ClearStyle(grayStyle, redStyle, orangeStyle, greenStyle, regexStyle);
        }
        private void ReprintColoration(Range range)
        {
            if (!string.IsNullOrEmpty(renameRegex))
            {
                ReprintReplaceRegexColoration();
            }
            else
            {
                ReprintValidityColoration(range);
            }
        }
        private void ReprintReplaceRegexColoration()
        {
            if (string.IsNullOrEmpty(renameRegex)) return;
            try
            {
                ResetRegexStyles(txbFiles.Range);
                txbFiles.Range.SetStyle(regexStyle, renameRegex, RegexOptions.Multiline);
            }
            catch { }
        }
        private void ReprintValidityColoration(Range range)
        {
            if (!string.IsNullOrEmpty(renameRegex)) return;
            ResetRegexStyles(range);
            if (chkCheckPaths.Checked)
            {
                List<string> lines = txbFiles.Lines.ToList();
                int s = 0;
                int f = 0;
                for (int i = 0; i < lines.Count && i < destFilenames.Count() && i < sourceFilenames.Count(); i++)
                {
                    f += lines[i].Length + 2;
                    if (i < range.Start.iLine || i > range.End.iLine)
                    {
                        s += lines[i].Length + 2;
                        continue;
                    }

                    Range r = txbFiles.GetRange(s, f);
                    if (sourceFilenames[i].ExistsAsDirectory)
                    {
                        if (destFilenames[i].IsValidAsDirectory(sourceFilenames[i].CompletePath))
                        {
                            r.SetStyle(grayStyle, PATH_REGEX);
                            if (destFilenames[i].ExistsAsDirectory)
                            {
                                r.SetStyle(orangeStyle, FILENAME_REGEX);
                            }
                            else
                            {
                                r.SetStyle(greenStyle, FILENAME_REGEX);
                            }
                        }
                        else
                        {
                            r.SetStyle(redStyle);
                        }
                    }
                    else
                    {
                        if (destFilenames[i].IsValidAsFile)
                        {
                            r.SetStyle(grayStyle, PATH_REGEX);
                            if (destFilenames[i].ExistsAsFile)
                            {
                                r.SetStyle(orangeStyle, FILENAME_REGEX);
                            }
                            else
                            {
                                r.SetStyle(greenStyle, FILENAME_REGEX);
                            }
                        }
                        else
                        {
                            r.SetStyle(redStyle);
                        }
                    }
                    s += lines[i].Length + 2;
                }
            }
            else
            {
                range.SetStyle(grayStyle, PATH_REGEX, RegexOptions.Multiline);
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
            ReprintValidityColoration(txbFiles.Range);
        }
        private void chkShowpathDest_CheckedChanged(object sender, EventArgs e)
        {
            ReprintFilenames(false);
            txbFiles.ClearUndo();
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
                sourceFilenames = new PathContainer(this.sourceFilenames.Where(x => result.Item1.All(y => x.CompletePath != y.CompletePath)));
                destFilenames = new PathContainer(sourceFilenames);
                ReprintFilenames();
            }
        }
        private void btnRegex_Click(object sender, EventArgs e)
        {
            if (regexWindow == null)
            {
                regexWindow = new RegexWindow(this);
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
                        ReprintColoration(txbFiles.Range);
                    }
                };
                regexWindow.chkShowMatches.CheckedChanged += (sender2, e2) =>
                {
                    if (regexWindow.chkShowMatches.Checked)
                    {
                        renameRegex = regexWindow.txbFrom.Text;
                        ReprintReplaceRegexColoration();
                    }
                    else
                    {
                        renameRegex = null;
                        ReprintValidityColoration(txbFiles.Range);
                    }
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
                                    destFilenames[i].CompletePath = Regex.Replace(destFilenames[i].CompletePath,
                                        regexWindow.txbFrom.Text,
                                        regexWindow.txbTo.Text);
                                }
                                else
                                {
                                    destFilenames[i].OnlyName = Regex.Replace(destFilenames[i].OnlyName,
                                        regexWindow.txbFrom.Text,
                                        regexWindow.txbTo.Text);
                                }
                            }
                            regexWindow.Close();
                            regexWindow = null;
                        }
                        catch
                        {
                            ShowError("Invalid regex", "The regex '" + regexWindow.txbFrom.Text + "' is invalid.");
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
