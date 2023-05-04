using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace octsaver_windows
{
    internal class OctcatInfo
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public OctcatInfo(string name, string url)
        {
            Name = name;
            ImageUrl = url;
        }
    }
}
