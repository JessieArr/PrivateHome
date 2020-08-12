using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrivateHome.Models;
using PrivateHome.Services;

namespace PrivateHome.Extensions
{
    public class DetailsModel : PageModel
    {
        public Extension Extension { get; set; }
        public string Summary { get; set; }
        public List<string> CompilerErrors { get; set; } = new List<string>();

        private DynamicCodeService _DynamicCodeService;
        public DetailsModel(DynamicCodeService dynamicCodeService)
        {
            _DynamicCodeService = dynamicCodeService;
        }

        public void OnGet(Guid id)
        {
            var service = new ExtensionService();
            Extension = service.GetExtension(id);
            var firstFile = Extension.Files.FirstOrDefault();

            if(firstFile != null && !string.IsNullOrEmpty(firstFile.Contents))
            {
                var result = _DynamicCodeService.GetAssemblyFromText(firstFile.Contents, Extension.ExtensionName);

                if(result.Succeeded)
                {
                    var extension = _DynamicCodeService.GetExtensionFromAssembly(result.Assembly);
                    Summary = extension.GetSummary();
                }
                else
                {
                    CompilerErrors = result.CompilerErrors;
                }
            }
        }
    }
}