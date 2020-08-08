using PrivateHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateHome.Services
{
    public class ExtensionService
    {
        private static List<Extension> _Extensions { get; set; } = new List<Extension>();

        public List<Extension> GetExtensions()
        {
            return _Extensions;
        }

        public void CreateExtension(Extension newExtension)
        {
            _Extensions.Add(newExtension);
        }
    }
}
