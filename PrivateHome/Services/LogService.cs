using Newtonsoft.Json;
using PrivateHome.ExtensionContracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateHome.Services
{
    public class LogService : ILogService
    {
        private static string _LogFileName = "logs.json";
        private static List<LogMessage> _Logs;
        private static List<LogMessage> Logs
        {
            get
            {
                if(_Logs == null)
                {
                    if(File.Exists(_LogFileName))
                    {
                        var existingLogs = File.ReadAllText(_LogFileName);
                        _Logs = JsonConvert.DeserializeObject<List<LogMessage>>(existingLogs);
                    }
                    else
                    {
                        _Logs = new List<LogMessage>();
                    }
                }
                return _Logs;
            }
        }

        public List<LogMessage> GetLogs()
        {
            return Logs.ToList();
        }

        public void WriteLog(LogMessage newLog)
        {
            Logs.Add(newLog);
            SaveLogs();
        }

        private void SaveLogs()
        {
            var serialized = JsonConvert.SerializeObject(Logs, Formatting.Indented);
            File.WriteAllText(_LogFileName, serialized);
        }
    }
}
