using System;
using System.Diagnostics;

namespace TestAutomationFramework.Common
{
    public enum LogType
    {
        Error,
        Success,
        Info,
        Step
    }
    public class Logging
    {
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the log.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="logType">The type of the log</param>
        public static void WriteLine(string value = "", LogType logType = LogType.Info)
        {
            var timeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            value = $"{timeStamp} - [{logType}] {value}";
            Debug.WriteLine(value, "Log");
            Console.WriteLine(value);

            // Get the "log" from the current TestContext
            var log = TestContext.Get("log")?.ToString();
            // Add the new "log line" to the "log"
            log = log + value + Environment.NewLine;
            // Save the new log
            TestContext.Set("log", log);
        }

        public static void CreateFile()
        {
            var log = TestContext.Get("log")?.ToString();
            string[] logToPrint = null;
            if(log != null) logToPrint = log.Split(Environment.NewLine);
            const string filePath = "../../../../TestResults/";
            System.IO.Directory.CreateDirectory(filePath); //Not necessary to validate if the path already exists.
            var fileName = NUnit.Framework.TestContext.CurrentContext.Test.FullName.Replace(".", "__") + ".txt";
            System.IO.File.WriteAllLines(filePath+fileName, logToPrint);
        }
    }
}
