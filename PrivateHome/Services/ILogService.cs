using PrivateHome.ExtensionContracts.Models;
using PrivateHome.Models;
using System.Collections.Generic;

namespace PrivateHome.Services
{
    public interface ILogService
    {
        List<LogMessage> GetLogs();
        void WriteLog(LogMessage newLog);
    }
}