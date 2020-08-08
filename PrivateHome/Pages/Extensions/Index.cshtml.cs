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
    public class IndexModel : PageModel
    {
        public List<Extension> Extensions { get; set; }
        public void OnGet()
        {
            var service = new ExtensionService();
            Extensions = service.GetExtensions();
        }
    }
}