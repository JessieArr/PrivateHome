using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PrivateHome.Models.DynamicCode
{
    public class ExtensionCompilationResult
    {
        public bool Succeeded { get; set; }
        public Assembly Assembly { get; set; }
        public List<string> CompilerErrors { get; set; }
    }
}
