using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octosaver_windows
{
    internal class OctocatInfo
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public OctocatInfo(string name, string url)
        {
            Name = name;
            ImageUrl = url;
        }
    }
}
