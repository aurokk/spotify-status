using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpotifyStatus.App
{
    public static class SettingsBuilder
    {
        public static Settings Build(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var settings = config
                .Get<Settings>();

            settings.ThrowIfInvalid();

            return settings;
        }
    }
}