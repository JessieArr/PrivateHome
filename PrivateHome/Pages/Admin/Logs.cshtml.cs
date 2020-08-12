using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrivateHome.ExtensionContracts.Models;
using PrivateHome.Models;
using PrivateHome.Services;

namespace PrivateHome.Admin
{
    public class LogsModel : PageModel
    {
        private ILogService _LogService;
        public List<LogMessage> Logs;
        public LogsModel(ILogService logService)
        {
            _LogService = logService;
        }

        public void OnGet()
        {
            Logs = _LogService.GetLogs().OrderByDescending(x => x.Time).ToList();
        }
    }
}