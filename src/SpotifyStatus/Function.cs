using System.Net.Http;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using GiphyDotNet.Manager;
using SpotifyStatus.App;
using Telegram.Bot;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SpotifyStatus
{
    public class Function
    {
        public async Task FunctionHandler(string input, ILambdaContext context)
        {
            // Build settings
            var settings = SettingsBuilder.Build();

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