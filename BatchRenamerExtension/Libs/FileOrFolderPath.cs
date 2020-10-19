using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BatchRenamerExtension
{
    class FileOrFolderPath
    {
        private string _path = null;
        public string CompletePath
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                InvalidateCache();
            }
        }

        public FileOrFolderPath(string path)
        {
            this.CompletePath = path;
        }

        public string ToString(bool showPath)
        {
            return showPath ? CompletePath : OnlyName;
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
                InvalidateCache();
            }
        }

        private bool? _isValidAsFile = null;
        public bool IsValidAsFile
        {
            get
            {
                if (_isValidAsFile.HasValue)
                {
                    return _isValidAsFile.Value;
                }
                else
                {
                    try
                    {
                        var file = new FileInfo(CompletePath);
                        _isValidAsFile = Directory.Exists(file.DirectoryName)
                            && !Directory.Exists(CompletePath) && Path.IsPathRooted(CompletePath);
                    }
                    catch
                    {
                        _isValidAsFile = false;
                    }
                    return IsValidAsFile;
                }
            }
        }

        private Dictionary<string, bool> _isValidAsDirectory = new Dictionary<string, bool>();
        public bool IsValidAsDirectory(string origin)
        {
            try
            {
                if(_isValidAsDirectory.ContainsKey(origin))
                {
                    return _isValidAsDirectory[origin];
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
                    _isValidAsDirectory.Add(origin, parentExists && !isParent && !File.Exists(CompletePath));
                    return IsValidAsDirectory(origin);
                }
                
            }
            catch
            {
                return false;
            }
        }

        private bool? _existAsDirectory = null;
        public bool ExistsAsDirectory
        {
            get
            {
                if (_existAsDirectory.HasValue)
                {
                    return _existAsDirectory.Value;
                }
                else
                {
                    _existAsDirectory = Directory.Exists(CompletePath);
                    return ExistsAsDirectory;
                }
            }
        }

        private bool? _existAsFile = null;
        public bool ExistsAsFile
        {
            get
            {
                if (_existAsFile.HasValue)
                {
                    return _existAsFile.Value;
                }
                else
                {
                    _existAsFile = File.Exists(CompletePath);
                    return ExistsAsFile;
                }
            }
        }

        private void InvalidateCache()
        {
            _isValidAsFile = _existAsFile = _existAsDirectory = null;
            _isValidAsDirectory.Clear();
        }
    }
}
