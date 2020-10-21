using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BatchRenamerExtension
{
    public class FileOrFolderPath
    {
        private string path = null;
        private bool? isValidAsFile = null;
        private Dictionary<string, bool> isValidAsDirectory = new Dictionary<string, bool>();
        private bool? existAsDirectory = null;
        private bool? existAsFile = null;
        private bool? isFileLocked = null;
        public FileOrFolderPath(string path)
        {
            this.CompletePath = path;
        }
        public string ToString(bool showPath)
        {
            return showPath ? CompletePath : OnlyName;
        }
        public override string ToString()
        {
            return CompletePath;
        }
        public string CompletePath
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                InvalidateCache();
            }
        }
        public string OnlyName
        {
            get
            {
                return CompletePath.Split('\\').Last();
            }
            set
            {
                string dirName = Path.GetDirectoryName(CompletePath);
                if (string.IsNullOrEmpty(dirName))
                {
                    CompletePath = value;
                }
                else
                {
                    CompletePath = dirName + "\\" + value;
                }
            }
        }
        public bool IsValidAsFile
        {
            get
            {
                if (isValidAsFile.HasValue)
                {
                    return isValidAsFile.Value;
                }
                else
                {
                    try
                    {
                        var file = new FileInfo(CompletePath);
                        isValidAsFile = Directory.Exists(file.DirectoryName)
                            && !Directory.Exists(CompletePath) && Path.IsPathRooted(CompletePath);
                    }
                    catch
                    {
                        isValidAsFile = false;
                    }
                    return IsValidAsFile;
                }
            }
        }
        public bool IsValidAsDirectory(string origin)
        {
            try
            {
                if (isValidAsDirectory.ContainsKey(origin))
                {
                    return isValidAsDirectory[origin];
                }
                else
                {
                    var originDir = new DirectoryInfo(origin);
                    var destDir = new DirectoryInfo(CompletePath);

                    bool isParent = false;
                    while (destDir.Parent != null)
                    {
                        if (destDir.Parent.FullName == originDir.FullName)
                        {
                            isParent = true;
                            break;
                        }
                        else destDir = destDir.Parent;
                    }

                    bool parentExists = Directory.Exists(new DirectoryInfo(CompletePath).Parent.FullName);
                    isValidAsDirectory.Add(origin, parentExists && !isParent && !File.Exists(CompletePath));
                    return IsValidAsDirectory(origin);
                }

            }
            catch
            {
                return false;
            }
        }
        public bool ExistsAsDirectory
        {
            get
            {
                if (existAsDirectory.HasValue)
                {
                    return existAsDirectory.Value;
                }
                else
                {
                    existAsDirectory = Directory.Exists(CompletePath);
                    return ExistsAsDirectory;
                }
            }
        }
        public bool ExistsAsFile
        {
            get
            {
                if (existAsFile.HasValue)
                {
                    return existAsFile.Value;
                }
                else
                {
                    existAsFile = File.Exists(CompletePath);
                    return ExistsAsFile;
                }
            }
        }
        public bool IsFileLocked
        {
            get
            {
                if(!ExistsAsFile) return false;
                if (!IsValidAsFile) return false;
                if (isFileLocked.HasValue) return isFileLocked.Value;
                else
                {
                    FileInfo file = new FileInfo(CompletePath);
                    try
                    {
                        using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            stream.Close();
                        }
                        isFileLocked = false;
                    }
                    catch (IOException)
                    {
                        isFileLocked = true;
                    }
                    return IsFileLocked;
                }
            }
        }
        public void InvalidateCache()
        {
            isFileLocked = isValidAsFile = existAsFile = existAsDirectory = null;
            isValidAsDirectory.Clear();
        }
        public override bool Equals(object obj)
        {
            return (obj is FileOrFolderPath) && ((obj as FileOrFolderPath).CompletePath == this.CompletePath);
        }
        public override int GetHashCode()
        {
            return CompletePath.GetHashCode();
        }
        public static bool operator !=(FileOrFolderPath l, FileOrFolderPath r) => !(l == r);
        public static bool operator ==(FileOrFolderPath l, FileOrFolderPath r) => l.Equals(r);
    }
}
