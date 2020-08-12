using PrivateHome.ExtensionContracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateHome.ExtensionContracts.Utilities
{
    public class Logger : ILogger
    {
        private string _ExtensionName;
        public Logger( string extensionName)
        {
            _ExtensionName = extensionName;
        }

        public List<LogMessage> GetLogs()
        {            
            throw new NotImplementedException();
        }

        public void WriteCriticalLog(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteDebugLog(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteErrorLog(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteInfoLog(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteWarningLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
