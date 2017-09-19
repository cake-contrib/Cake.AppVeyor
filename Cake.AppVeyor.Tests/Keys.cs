using System;
using System.IO;

namespace Cake.AppVeyor.Tests
{
    public static class Keys
    {
        const string YOUR_APPVEYOR_API_TOKEN = "{APPVEYOR_APITOKEN}";

        static string appVeyorApiToken;

        public static string AppVeyorApiToken {
            get
            {
                if (appVeyorApiToken == null)
                {
                    // Check for a local file with a token first
                    var localFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".appveyorapitoken");
                    if (File.Exists(localFile))
                        appVeyorApiToken = File.ReadAllText(localFile);

                    // Next check for an environment variable
                    if (string.IsNullOrEmpty(appVeyorApiToken))
                        appVeyorApiToken = Environment.GetEnvironmentVariable("appveyor_api_token");

                    // Finally use the const value
                    if (string.IsNullOrEmpty(appVeyorApiToken))
                        appVeyorApiToken = YOUR_APPVEYOR_API_TOKEN;
                }

                return appVeyorApiToken;
            }
        }
    }
}

