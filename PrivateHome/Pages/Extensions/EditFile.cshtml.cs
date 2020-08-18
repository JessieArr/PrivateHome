using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrivateHome.Models;
using PrivateHome.Services;

namespace PrivateHome
{
    public class EditFileModel : PageModel
    {
        public Extension Extension { get; set; }
        public ExtensionFile ExtensionFile { get; set; }
        [BindProperty]
        public string FileContents { get; set; }

        public void OnGet(Guid id, string filePath)
        {
            var service = new ExtensionService();
            Extension = service.GetExtension(id);
            ExtensionFile = Extension.Files.First(
                x => String.Equals(x.FullPath, filePath, StringComparison.OrdinalIgnoreCase));
            FileContents = ExtensionFile?.Contents;
        }

        public void OnPost(Guid id, string filePath)
        {
            var service = new ExtensionService();
            Extension = service.GetExtension(id);
            ExtensionFile = Extension.Files.First(
                x => String.Equals(x.FullPath, filePath, StringComparison.OrdinalIgnoreCase));
            ExtensionFile.Contents = FileContents;
            service.SaveExtensions();
        }
    }
}