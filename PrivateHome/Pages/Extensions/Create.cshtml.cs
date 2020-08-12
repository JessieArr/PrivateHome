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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string ExtensionName { get; set; }

        private ExtensionService _ExtensionService;
        public CreateModel()
        {
            _ExtensionService = new ExtensionService();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var newExtension = new Extension();
            newExtension.ExtensionName = ExtensionName;
            _ExtensionService.CreateExtension(newExtension);

            return new RedirectToPageResult("Index");
        }
    }
}