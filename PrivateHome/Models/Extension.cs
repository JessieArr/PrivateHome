using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateHome.Models
{
    public class Extension
    {
        public Guid ID { get; set; }
        public string ExtensionName { get; set; }
        public List<ExtensionFile> Files { get; set; }
    }
}
