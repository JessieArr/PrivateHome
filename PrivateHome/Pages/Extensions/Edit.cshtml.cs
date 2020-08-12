using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using PrivateHome.ExtensionContracts;
using PrivateHome.Models;
using PrivateHome.Services;

namespace PrivateHome.Extensions
{
    public class EditModel : PageModel
    {
        public Extension Extension { get; set; }
        [BindProperty]
        public string FileContents { get; set; }

        public void OnGet(Guid id)
        {
            var service = new ExtensionService();
            Extension = service.GetExtension(id);
            var firstFile = Extension.Files.FirstOrDefault();
            FileContents = firstFile?.Contents;
        }

        public void OnPost(Guid id)
        {
            var service = new ExtensionService();
            Extension = service.GetExtension(id);
            var firstFile = Extension.Files.FirstOrDefault();
            if(firstFile == null)
            {
                firstFile = new ExtensionFile();
                Extension.Files.Add(firstFile);
            }
            firstFile.Contents = FileContents;
            service.SaveExtensions();
        }
    }
}