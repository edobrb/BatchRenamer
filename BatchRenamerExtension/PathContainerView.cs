using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace BatchRenamerExtension
{
    public partial class PathContainerView : UserControl
    {
        private const string PATH_REGEX = @"(^(.+)\\)";
        private const string FILENAME_REGEX = @"[^\\]+$";

        private bool checkPathSanity = true;
        private bool showFullpath = false;
        private string renameRegex = null;
        public PathContainer SourceFilenames { get; private set; } = new PathContainer();
        public PathContainer DestFilenames { get; private set; } = new PathContainer();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowFullpath
        {
            get => showFullpath;
            set
            {
                showFullpath = value;
                ReprintFilenames(false);
                txbFiles.ClearUndo();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckPathSanity
        {
            get => checkPathSanity;
            set
            {
                checkPathSanity = value;
                ReprintPathSanityColoration(txbFiles.Range);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RenameRegex
        {
            get => renameRegex;
            set
            {
                renameRegex = value;
                if (renameRegex == null)
                {
                    ReprintPathSanityColoration(txbFiles.Range);
                }
                else
                {
                    ReprintReplaceRegexColoration();
                }

            }
        }

        public TextStyle RootFilenameStyle = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);
        public TextStyle FileOverwriteStyle = new TextStyle(null, Brushes.DarkOrange, FontStyle.Regular);
        public TextStyle WrongFilenameStyle = new TextStyle(Brushes.Red, null, FontStyle.Underline);
        public TextStyle FileLockedStyle = new TextStyle(null, Brushes.Yellow, FontStyle.Regular);
        public TextStyle FilenameOkStyle = new TextStyle(null, Brushes.LightGreen, FontStyle.Regular);
        public TextStyle RegexHighlightsStle = new TextStyle(null, Brushes.LightBlue, FontStyle.Bold);

        public PathContainerView()
        {
            InitializeComponent();
        }

        public void SetPaths(PathContainer paths, bool reprint = true)
        {
            SourceFilenames = new PathContainer(paths);
            DestFilenames = new PathContainer(paths);
            if(reprint) ReprintFilenames(false);
            txbFiles.ClearUndo();
        }
        private void txbFiles_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbFiles.Text)) return;
            if (txbFiles.LinesCount != SourceFilenames.Count)
            {
                ReprintFilenames();
                return;
            }
            UpdateDestinatinoPath(e.ChangedRange);
            ReprintColoration(e.ChangedRange);
        }
        public void ReprintFilenames(bool updateDestination = true)
        {
            if (!updateDestination) txbFiles.TextChanged -= txbFiles_TextChanged;
            txbFiles.Text = DestFilenames.ToString(ShowFullpath);
            if (!updateDestination) txbFiles.TextChanged += txbFiles_TextChanged;
            ReprintColoration(txbFiles.Range);
        }
        private void UpdateDestinatinoPath(Range range)
        {
            if (ShowFullpath)
            {
                for (int i = 0; i < txbFiles.Lines.Count && i < DestFilenames.Count; i++)
                {
                    if (i < range.Start.iLine || i > range.End.iLine) continue;
                    if (DestFilenames[i].CompletePath == txbFiles.Lines[i]) continue;
                    DestFilenames[i].CompletePath = txbFiles.Lines[i];
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txbFiles.Text))
                {
                    for (int i = 0; i < txbFiles.Lines.Count && i < DestFilenames.Count; i++)
                    {
                        if (i < range.Start.iLine || i > range.End.iLine) continue;
                        if (DestFilenames[i].OnlyName == txbFiles.Lines[i]) continue;
                        DestFilenames[i].OnlyName = txbFiles.Lines[i];
                        if (DestFilenames[i].OnlyName != txbFiles.Lines[i]) //add a \ in the name
                        {
                            txbFiles[i].Clear();
                            txbFiles[i].AddRange(DestFilenames[i].OnlyName.Select(c => new FastColoredTextBoxNS.Char(c)));
                            txbFiles.ClearUndo();
                        }
                    }
                }
            }
        }
        private void ResetRegexStyles(Range range)
        {
            range.ClearStyle(FileLockedStyle, RootFilenameStyle, WrongFilenameStyle, FileOverwriteStyle, FilenameOkStyle, RegexHighlightsStle);
        }
        public void ReprintColoration(Range range)
        {
            if (!string.IsNullOrEmpty(RenameRegex)) ReprintReplaceRegexColoration();
            else ReprintPathSanityColoration(range);
        }
        public void ReprintReplaceRegexColoration()
        {
            if (string.IsNullOrEmpty(RenameRegex)) return;
            try
            {
                ResetRegexStyles(txbFiles.Range);
                txbFiles.Range.SetStyle(RegexHighlightsStle, RenameRegex, RegexOptions.Multiline);
            }
            catch { }
        }
        public void ReprintPathSanityColoration(Range range)
        {
            if (!string.IsNullOrEmpty(RenameRegex)) return;
            ResetRegexStyles(range);
            if (CheckPathSanity)
            {
                List<string> lines = txbFiles.Lines.ToList();
                int s = 0;
                int f = 0;
                for (int i = 0; i < lines.Count && i < DestFilenames.Count && i < SourceFilenames.Count; i++)
                {
                    f += lines[i].Length + 2;
                    if (i < range.Start.iLine || i > range.End.iLine)
                    {
                        s += lines[i].Length + 2;
                        continue;
                    }

                    Range r = txbFiles.GetRange(s, f);
                    if (SourceFilenames[i].ExistsAsDirectory)
                    {
                        if (DestFilenames[i].IsValidAsDirectory(SourceFilenames[i].CompletePath))
                        {
                            r.SetStyle(RootFilenameStyle, PATH_REGEX);
                            if (SourceFilenames[i] != DestFilenames[i])
                            {
                                if (DestFilenames[i].ExistsAsDirectory) r.SetStyle(FileOverwriteStyle, FILENAME_REGEX);
                                else r.SetStyle(FilenameOkStyle, FILENAME_REGEX);
                            }
                        }
                        else
                        {
                            r.SetStyle(WrongFilenameStyle);
                        }
                    }
                    else
                    {
                        if (DestFilenames[i].IsValidAsFile)
                        {
                            r.SetStyle(RootFilenameStyle, PATH_REGEX);
                            if (SourceFilenames[i].IsFileLocked) r.SetStyle(FileLockedStyle);
                            else if (SourceFilenames[i] != DestFilenames[i])
                            {
                                if (DestFilenames[i].ExistsAsFile) r.SetStyle(FileOverwriteStyle, FILENAME_REGEX);
                                else r.SetStyle(FilenameOkStyle, FILENAME_REGEX);
                            }
                        }
                        else
                        {
                            r.SetStyle(WrongFilenameStyle);
                        }
                    }
                    s += lines[i].Length + 2;
                }
            }
            else
            {
                range.SetStyle(RootFilenameStyle, PATH_REGEX, RegexOptions.Multiline);
            }
        }
        public bool ApplyRegex(string from, string to, bool showError = true)
        {
            if (!string.IsNullOrEmpty(from))
            {
                try
                {
                    for (int i = 0; i < DestFilenames.Count(); i++)
                    {
                        if (ShowFullpath) DestFilenames[i].CompletePath = Regex.Replace(DestFilenames[i].CompletePath, from, to);
                        else DestFilenames[i].OnlyName = Regex.Replace(DestFilenames[i].OnlyName, from, to);
                    }
                    ReprintFilenames();
                    return true;
                }
                catch
                {
                    if(showError) FormUtils.ShowError("Invalid regex", "The regex '" + from + "' is invalid.");
                    ReprintFilenames();
                    return false;
                }
            }
            return true;
        }
        public void ClearUndo()
        {
            txbFiles.ClearUndo();
        }
    }
}
