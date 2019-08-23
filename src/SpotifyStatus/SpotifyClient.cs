using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyStatus
{
    public class SpotifyClient
    {
        private readonly HttpClient _httpClient;

        public SpotifyClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<bool> IsAvailable(string country, CancellationToken ct = default(CancellationToken))
        {
            if (country == null) throw new ArgumentNullException(nameof(country));
            const string url = "https://www.spotify.com/us/select-your-country/";
            var response = await _httpClient.GetAsync(url, ct);
            response.EnsureSuccessStatusCode();
            var page = await response.Content.ReadAsStringAsync();
            return page.Contains(country);
        }
    }
}