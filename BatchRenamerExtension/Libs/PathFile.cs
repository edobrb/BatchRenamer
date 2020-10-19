using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BatchRenamerExtension
{
    class PathValue
    {
        public string Value { get; set; }

        public PathValue(string path)
        {
            this.Value = path;
        }

        public string ToString(bool showPath)
        {
            return showPath ? Value : OnlyName;
        }

        public string OnlyName
        {
            get
            {
                return Value.Split('\\').Last();
            }
        }

        public void ChangeOnlyName(string name)
        {
            var dir = Path.GetDirectoryName(Value);
            if (string.IsNullOrEmpty(dir))
            {
                Value = name;
            }
            else
            {
                Value = dir + "\\" + name;
            }
        }

        public bool IsValidAsFile
        {
            get
            {
                try
                {
                    var file = new FileInfo(Value);
                    return Directory.Exists(file.DirectoryName)
                        && !Directory.Exists(Value) && Path.IsPathRooted(Value);
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IsValidAsDirectory(string origin)
        {
            try
            {
                var originDir = new DirectoryInfo(origin);
                var destDir = new DirectoryInfo(Value);

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

                bool parentExists = Directory.Exists(new DirectoryInfo(Value).Parent.FullName);
                return parentExists && !isParent && !File.Exists(Value);
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
                return Directory.Exists(Value);
            }
        }

        public bool ExistsAsFile
        {
            get
            {
                return File.Exists(Value);
            }
        }
    }
}
