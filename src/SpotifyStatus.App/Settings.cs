using System;

namespace SpotifyStatus.App
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
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(bool))
                {
                    continue;
                }

                var value = property.GetValue(this) as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"Configuration parameter {property.Name} should be set");
                }
            }
        }
    }
}