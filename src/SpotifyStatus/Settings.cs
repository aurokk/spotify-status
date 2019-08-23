using System;
using System.Linq;

namespace SpotifyStatus
{
    public class Settings
    {
        public string Country { get; set; }

        public string TelegramBotApiKey { get; set; }
        public string TelegramChannel { get; set; }
        public string TelegramTextYes { get; set; }
        public string TelegramTextNo { get; set; }

        public string GiphyApiKey { get; set; }
        public string GiphyTextYes { get; set; }
        public string GiphyTextNo { get; set; }

        public bool DryRun { get; set; }

        public void ThrowIfInvalid()
        {
            var stringProperties = GetType()
                .GetProperties()
                .Where(x => x.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                var value = stringProperty.GetValue(this) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"Configuration parameter {stringProperty.Name} should be set");
                }
            }
        }
    }
}