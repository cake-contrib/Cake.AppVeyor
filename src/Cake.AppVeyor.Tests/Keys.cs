using System;
using System.IO;

namespace Cake.AppVeyor.Tests
{
    public static class Keys
    {
        private const string YOUR_APPVEYOR_API_TOKEN = "{APPVEYOR_APITOKEN}";

        private static string appVeyorApiToken;

        public static string AppVeyorApiToken
        {
            get
            {
                if (appVeyorApiToken == null)
                {
                    // Check for a local file with a token first
                    var localFile = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", ".appveyorapitoken");
                    if (File.Exists(localFile))
                    {
                        appVeyorApiToken = File.ReadAllText(localFile);
                    }

                    // Next check for an environment variable
                    if (string.IsNullOrEmpty(appVeyorApiToken))
                    {
                        appVeyorApiToken = Environment.GetEnvironmentVariable("test_appveyor_api_token");
                    }

                    // Finally use the const value
                    if (string.IsNullOrEmpty(appVeyorApiToken))
                    {
                        appVeyorApiToken = YOUR_APPVEYOR_API_TOKEN;
                    }
                }

                return appVeyorApiToken;
            }
        }
    }
}

