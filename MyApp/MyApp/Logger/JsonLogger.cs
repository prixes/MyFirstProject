using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Logger
{
    public class JsonLogger
    {
        private readonly string _logFilePath;

        public JsonLogger(string logFilePath)
        {
            _logFilePath = logFilePath;

            // Create an empty array in the log file if it doesn't exist
            if (!File.Exists(_logFilePath))
            {
                File.WriteAllText(_logFilePath, "[]");
            }
        }

        public void AddLog(string message)
        {
            var logEntry = new JObject
            {
                ["timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ["message"] = message
            };

            var logEntries = JArray.Parse(File.ReadAllText(_logFilePath));
            logEntries.Add(logEntry);
            File.WriteAllText(_logFilePath, logEntries.ToString());
        }

        public List<JObject> GetLastNLogs(int n)
        {
            var logEntries = JArray.Parse(File.ReadAllText(_logFilePath));
            var result = new List<JObject>();

            for (int i = Math.Max(0, logEntries.Count - n); i < logEntries.Count; i++)
            {
                result.Add((JObject)logEntries[i]);
            }

            return result;
        }
    }

}
