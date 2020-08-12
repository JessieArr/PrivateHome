using PrivateHome.ExtensionContracts.Models;
using PrivateHome.ExtensionContracts.Utilities;
using PrivateHome.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrivateHome.Utilities
{
    public class Logger : ILogger
    {
        private string _ExtensionName;
        private ILogService _LogService;
        public Logger(ILogService logService, string extensionName)
        {
            _LogService = logService;
            _ExtensionName = extensionName;
        }

        public List<LogMessage> GetLogs()
        {
            var logs = _LogService.GetLogs().Where(x => x.ExtensionName == _ExtensionName);
            return logs.ToList();
        }

        public void WriteCriticalLog(string message)
        {
            _LogService.WriteLog(new LogMessage(message, LogLevelEnum.Critical, false, _ExtensionName));            
        }

        public void WriteDebugLog(string message)
        {
            _LogService.WriteLog(new LogMessage(message, LogLevelEnum.Debug, false, _ExtensionName));
        }

        public void WriteErrorLog(string message)
        {
            _LogService.WriteLog(new LogMessage(message, LogLevelEnum.Error, false, _ExtensionName));
        }

        public void WriteInfoLog(string message)
        {
            _LogService.WriteLog(new LogMessage(message, LogLevelEnum.Info, false, _ExtensionName));
        }

        public void WriteWarningLog(string message)
        {
            _LogService.WriteLog(new LogMessage(message, LogLevelEnum.Warning, false, _ExtensionName));
        }
    }
}
