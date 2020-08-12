using PrivateHome.ExtensionContracts.Models;
using System.Collections.Generic;

namespace PrivateHome.ExtensionContracts.Utilities
{
    public interface ILogger
    {
        public void WriteCriticalLog(string message);
        public void WriteErrorLog(string message);
        public void WriteWarningLog(string message);
        public void WriteInfoLog(string message);
        public void WriteDebugLog(string message);
        public List<LogMessage> GetLogs();
    }
}