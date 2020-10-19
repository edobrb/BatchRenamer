using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace BatchRenamerExtension
{
    class PathContainer : IEnumerable<PathValue>
    {
        private List<PathValue> paths;

        public PathContainer(IEnumerable<string> paths)
        {
            this.paths = paths.Select(x => new PathValue(x)).ToList();
        }
        public PathContainer(IEnumerable<PathValue> paths)
        {
            this.paths = paths.Select(v => new PathValue(v.Value)).ToList();
        }

        public void ChangeOnlyName(int index, string name)
        {
            paths[index].ChangeOnlyName(name);
        }

        public PathValue this[int index]
        {
            get
            {
                return paths[index];
            }
        }

        public string ToString(bool showPath)
        {

            return paths.Aggregate("", (acc, x) => acc + "\n" + x.ToString(showPath)).Trim();
        }

        public IEnumerator<PathValue> GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return paths.GetEnumerator();
        }

        public void AddRange(IList<string> values)
        {
            paths.AddRange(values.Where(v => paths.All(p => p.Value != v)).Select(v => new PathValue(v)));
        }
    }
}
