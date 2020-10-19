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

            if (sources.Count() != dests.Count())
            {
                ShowError("Wrong file number", "The number of fiels to rename is not correct.");
                return Tuple.Create(success, false);
            }

            var renames = dests.Zip(sources, (f, s) => Tuple.Create(f, s))
                .Where(x => x.Item1.CompletePath != x.Item2.CompletePath);

            foreach (var p in renames)
            {
                var source = p.Item2;
                var dest = p.Item1;
                try
                {
                    if (source.ExistsAsFile && dest.ExistsAsFile)
                    { 
                        if(!Ask("Overwriting", String.Format("Do you want to override {0} with {1}", source.CompletePath, dest.CompletePath)))
                        {
                            return Tuple.Create(success, false);
                        }
                    }
                    if (source.ExistsAsFile && !dest.IsValidAsFile)
                    {
                        ShowError("Invalid file path", String.Format("The file {0} has an invalid path or name", dest.CompletePath));
                        return Tuple.Create(success, false);
                    }
                    if (source.ExistsAsDirectory && dest.ExistsAsDirectory)
                    {
                        ShowError("Folder merge", String.Format("Folder merge is not supported: {0}", dest.CompletePath));
                        return Tuple.Create(success, false);
                    }
                    if(source.ExistsAsDirectory && !dest.IsValidAsDirectory(source.CompletePath))
                    {
                        ShowError("Invalid folder path", String.Format("The folder {0} has an invalid path or name", dest.CompletePath));
                        return Tuple.Create(success, false);
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Unexpected error", ex.Message);
                    return Tuple.Create(success, false);
                }
            }

            
            foreach (var p in renames)
            {
                var source = p.Item2;
                var dest = p.Item1;
                try
                {
                    if (source.ExistsAsFile)
                    {
                        if(dest.ExistsAsFile)
                        {
                            File.Delete(dest.CompletePath);
                        }
                        File.Move(source.CompletePath, dest.CompletePath);
                    }
                    else if (source.ExistsAsDirectory)
                    {
                        Directory.Move(source.CompletePath, dest.CompletePath);
                    }
                    else
                    {
                        throw new Exception("The path is nor a file or a folder.");
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
