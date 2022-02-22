using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.PEF.BLL.Configuration
{
    public static class ApplicationConfig
    {
        public static string CurrentEnvironment { get; private set; }

        static ApplicationConfig()
        {
            CurrentEnvironment = "dev";
        }

        public static void EnvironmentDetection(string[] args)
        {
            var env = GetArgConfigEnvironmentValue(args) ?? GetAppConfigEnvironmentValue();

            var list = new List<string>() { "p", "pr", "pro", "prod" };
            CurrentEnvironment = (list.Any(env.Contains)) ? "prod" : "dev";
        }


        private static string GetArgConfigEnvironmentValue(string[] args)
        {
            const string envKey = "env=";
            foreach (var arg in args)
            {
                if (arg.IndexOf(envKey, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return arg.Split(new char[] { '=' })[1];
                }
            }
            return null;
        }

        private static string GetAppConfigEnvironmentValue()
        {
            var env = ConfigurationManager.AppSettings["env"];
            return (env ?? "dev").Trim().ToLower();
        }

    }
}
