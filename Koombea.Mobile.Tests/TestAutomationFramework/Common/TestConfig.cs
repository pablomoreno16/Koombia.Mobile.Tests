using System;
using Microsoft.Extensions.Configuration;

namespace TestAutomationFramework.Common
{
    public class TestConfig
    {
        private readonly IConfigurationRoot _config;

        private static TestConfig _instance;
        public static TestConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TestConfig();
                }
                return _instance;
            }
        }

        private TestConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        public string GetValue(string key, string defaultValue = null)
        {
            var value = Environment.GetEnvironmentVariable(key)
                        ?? _config.GetSection(key).Value
                        ?? defaultValue;

            value = value != null ? Environment.ExpandEnvironmentVariables(value) : value;

            return value;
        }

        public bool GetBoolValue(string key, bool defaultValue = false)
        {
            var value = GetValue(key, $"{defaultValue}");
            bool.TryParse(value, out bool result);

            return result;
        }

        public int GetIntValue(string key, int defaultValue)
        {
            var value = GetValue(key, $"{defaultValue}");
            int.TryParse(value, out int result);

            return result;
        }

        public long GetLongValue(string key, long defaultValue)
        {
            var value = GetValue(key, $"{defaultValue}");
            long.TryParse(value, out long result);

            return result;
        }

        public Uri GetUriValue(string key, string defaultValue = null)
        {
            var value = GetValue(key, defaultValue);
            return new Uri(value);
        }

        public void SetValue(string key, string value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                Environment.SetEnvironmentVariable(key, value);
            }
        }

    }
}
