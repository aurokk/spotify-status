using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpotifyStatus
{
    public static class SettingsBuilder
    {
        public static Settings Build()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            var settings = config
                .Get<Settings>();

            settings
                .ThrowIfInvalid();

            return settings;
        }
    }
}