using System;
using System.Threading.Tasks;
using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;

namespace SpotifyStatus
{
    public class GetGifCommand
    {
        private readonly Giphy _giphyClient;
        private readonly Settings _settings;
        private readonly bool _isAvailable;

        public GetGifCommand(Giphy giphyClient, Settings settings, bool isAvailable)
        {
            _giphyClient = giphyClient ?? throw new ArgumentNullException(nameof(giphyClient));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _isAvailable = isAvailable;
        }

        public async Task<string> Execute()
        {
            var gifRequest = new RandomParameter
            {
                Tag = _isAvailable
                    ? _settings.GiphyTextYes
                    : _settings.GiphyTextNo,
            };
            var gif = await _giphyClient.RandomGif(gifRequest);
            return gif.Data.ImageUrl;
        }
    }
}