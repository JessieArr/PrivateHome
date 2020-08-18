using Newtonsoft.Json;
using PrivateHome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateHome.Services
{
    public class ExtensionService
    {
        private static List<Extension> _Extensions;
        private static List<Extension> Extensions
        {
            get
            {
                if(_Extensions == null)
                {
                    if(File.Exists(_FileName))
                    {
                        var contents = File.ReadAllText(_FileName);
                        _Extensions = JsonConvert.DeserializeObject<List<Extension>>(contents);
                    }
                    else
                    {
                        _Extensions = new List<Extension>();
                    }
                }
                return _Extensions;
            }
            set
            {
                _Extensions = value;
            }
        }
        private static string _FileName = "extensions.json";

        public Extension GetExtension(Guid id)
        {
            return Extensions.First(x => x.ID == id);
        }

        public List<Extension> GetExtensions()
        {
            return Extensions;
        }

        public void CreateExtension(Extension newExtension)
        {
            Extensions.Add(newExtension);
            SaveExtensions();
        }

        public void SaveExtensions()
        {
            var serialized = JsonConvert.SerializeObject(Extensions, Formatting.Indented);
            File.WriteAllText(_FileName, serialized);
        }
    }
}
