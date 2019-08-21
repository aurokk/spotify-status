using System.Net.Http;
using System.Threading.Tasks;
using GiphyDotNet.Manager;
using Telegram.Bot;

namespace SpotifyStatus.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Build settings
            var settings = SettingsBuilder.Build(args);

            // Check availability
            var httpClient = new HttpClient();
            var spotifyClient = new SpotifyClient(httpClient);
            var isAvailable = await spotifyClient.IsAvailable(settings.Country);

            // Get gif
            var giphyClient = new Giphy(settings.GiphyApiKey);
            var gif = await new GetGifCommand(giphyClient, settings, isAvailable).Execute();

            // Send gif
            var telegramClient = new TelegramBotClient(settings.TelegramBotApiKey);
            await new SendGifCommand(telegramClient, settings, isAvailable, gif).Execute();
        }
    }
}