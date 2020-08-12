using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateHome.ExtensionContracts.Models
{
    public class LogMessage
    {
        public string Message { get; set; }
        public bool IsSystem { get; set; }
        public string ExtensionName { get; set; }
        public LogLevelEnum Level { get; set; }
        public DateTime Time { get; set; }

        public LogMessage(string message, LogLevelEnum level, bool isSystem, string extensionName)
        {
            Message = message;
            IsSystem = isSystem;
            ExtensionName = extensionName;
            Level = level;
            Time = DateTime.UtcNow;
        }
    }
}
