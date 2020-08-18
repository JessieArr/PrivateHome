using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateHome.Models
{
    public class ExtensionFile
    {
        public string FileName { get
            {
                return FullPath.Substring(FullPath.LastIndexOf('/') + 1);
            }
        }
        public string FullPath { get; set; }
        public string Contents { get; set; }
    }
}
