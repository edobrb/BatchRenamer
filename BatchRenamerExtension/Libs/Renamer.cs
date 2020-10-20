using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BatchRenamerExtension
{
    class Renamer
    {
        public delegate void ShowError(string title, string message);
        public delegate bool AskForContinuation(string title, string message);
        public static Tuple<List<FileOrFolderPath>, bool> Rename(
            PathContainer sources,
            PathContainer dests,
            ShowError ShowError,
            AskForContinuation Ask)
        {
            var success = new List<FileOrFolderPath>();

            if (sources.Count != dests.Count)
            {
                ShowError("Wrong file number", "The number of fiels to rename is not correct.");
                return Tuple.Create(success, false);
            }

            var renames = dests.Zip(sources, (f, s) => Tuple.Create(f, s))
                .Where(x => x.Item1.CompletePath != x.Item2.CompletePath);

            List<Tuple<FileOrFolderPath, FileOrFolderPath>> overwriting = new List<Tuple<FileOrFolderPath, FileOrFolderPath>>();
            List<Tuple<FileOrFolderPath, FileOrFolderPath>> inUse = new List<Tuple<FileOrFolderPath, FileOrFolderPath>>();
            List<Tuple<FileOrFolderPath, FileOrFolderPath>> invalidPath = new List<Tuple<FileOrFolderPath, FileOrFolderPath>>();
            List<Tuple<FileOrFolderPath, FileOrFolderPath>> folderMerge = new List<Tuple<FileOrFolderPath, FileOrFolderPath>>();
            List<Tuple<FileOrFolderPath, FileOrFolderPath>> ok = new List<Tuple<FileOrFolderPath, FileOrFolderPath>>();
            foreach (var p in renames)
            {
                var source = p.Item2;
                var dest = p.Item1;
                try
                {
                    source.InvalidateCache();
                    dest.InvalidateCache();
                    if (source.ExistsAsFile && dest.ExistsAsFile) overwriting.Add(p);
                    else if (source.ExistsAsFile && !dest.IsValidAsFile) invalidPath.Add(p);
                    else if (source.ExistsAsDirectory && dest.ExistsAsDirectory) folderMerge.Add(p);
                    else if (source.ExistsAsDirectory && !dest.IsValidAsDirectory(source.CompletePath)) invalidPath.Add(p);
                    else if (source.ExistsAsFile && source.IsFileLocked) inUse.Add(p);
                    else if (source.ExistsAsFile || source.ExistsAsDirectory) ok.Add(p);
                    else throw new Exception("The path is nor a file or a folder.");
                }
                catch (Exception ex)
                {
                    ShowError("Unexpected error", ex.Message);
                    return Tuple.Create(success, false);
                }
            }

            if (invalidPath.Count > 0)
            {
                var desc = String.Join("\n", invalidPath.Select(x => x.Item1));
                ShowError("Invalid path value", "This path(s) are invalid:\n\n" + desc);
                return Tuple.Create(success, false);
            }
            if (folderMerge.Count > 0)
            {
                var desc = String.Join("\n", folderMerge.Select(x => x.Item2 + " -> " + x.Item1));
                ShowError("Directory merge", "Directory merge is unsupported\n\n" + desc);
                return Tuple.Create(success, false);
            }
            if (inUse.Count > 0)
            {
                var desc = String.Join("\n", inUse.Select(x => x.Item2));
                ShowError("Files in use", "This file(s) are in use:\n\n" + desc);
                return Tuple.Create(success, false);
            }
            if (overwriting.Count > 0)
            {
                var desc = String.Join("\n", overwriting.Select(x => x.Item1));
                if (!Ask("Overwrite files?", "Do you want to overwrite these files:\n\n" + desc)) return Tuple.Create(success, false);
                ok.AddRange(overwriting);
            }

            foreach (var p in ok)
            {
                var source = p.Item2;
                var dest = p.Item1;
                try
                {
                    if (source.ExistsAsFile)
                    {
                        if (dest.ExistsAsFile) File.Delete(dest.CompletePath);
                        File.Move(source.CompletePath, dest.CompletePath);
                    }
                    else if (source.ExistsAsDirectory)
                    {
                        Directory.Move(source.CompletePath, dest.CompletePath);
                    }
                    success.Add(source);
                }
                catch (Exception ex)
                {
                    ShowError("Unexpected error", ex.Message);
                    return Tuple.Create(success, false);
                }
            }

            return Tuple.Create(success, true);
        }
    }
}
