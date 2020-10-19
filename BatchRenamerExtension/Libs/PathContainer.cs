using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace BatchRenamerExtension
{
    class PathContainer : IEnumerable<FileOrFolderPath>
    {
        private List<FileOrFolderPath> paths;

        public PathContainer(IEnumerable<string> paths)
        {
            this.paths = paths.Select(x => new FileOrFolderPath(x)).ToList();
        }
        public PathContainer(IEnumerable<FileOrFolderPath> paths)
        {
            this.paths = paths.Select(v => new FileOrFolderPath(v.CompletePath)).ToList();
        }


        public FileOrFolderPath this[int index]
        {
            get
            {
                return paths[index];
            }
        }

        public string ToString(bool showPath)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var p in paths) sb.AppendLine(p.ToString(showPath));
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public IEnumerator<FileOrFolderPath> GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        public void AddRange(IList<string> values)
        {
            paths.AddRange(values.Where(v => paths.All(p => p.CompletePath != v)).Select(v => new FileOrFolderPath(v)));
        }
    }
}
