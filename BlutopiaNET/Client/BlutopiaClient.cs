using BlutopiaNET.Constants;
using BlutopiaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlutopiaNET.Client
{
    public sealed class BlutopiaClient : IDisposable
    {
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _handler;
        private readonly HttpClient _httpClient;
        private readonly string _apiToken;

        public BlutopiaClient(string apiToken)
        {
            _apiToken = apiToken;

            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler()
            {
                PreAuthenticate = true,
                CookieContainer = _cookieContainer,
                UseCookies = true,
            };
            _httpClient = new HttpClient(_handler);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiToken);
            //_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {_apiToken}");
        }

        public async Task<TorrentCollection> GetTorrentsAsync(int? page = null, Filter? filter = null)
        {
            return await GetAsync<TorrentCollection>($"{BlutopiaConstants.Routes.TorrentsSubUrl}" +
                $"{(filter != null ? filter.ToString() : "")}" +
                $"{(page != null ? filter != null ? $"&{BlutopiaConstants.RouteParameters.PageParameter}={page}" : $"?{BlutopiaConstants.RouteParameters.PageParameter}={page}" : "")}");
        }

        public async Task<Torrent> GetTorrentAsync(int torrentId)
        {
            return await GetAsync<Torrent>($"{BlutopiaConstants.Routes.TorrentsSubUrl}/{torrentId}");
        }

        public async Task DownloadTorrentAsync(Torrent torrent, string path, string? fileName = null)
        {
            using(var response = await _httpClient.GetAsync(torrent.Attributes.DownloadLink))
            {
                if(!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Unable to download torrent from {torrent.Attributes.DownloadLink}");
                }

                using(var fileStream = new FileStream(Path.Combine(path, fileName ?? $"{torrent.Attributes.InfoHash}.torrent"), FileMode.Create, FileAccess.Write))
                {
                    var torrentStream = await response.Content.ReadAsStreamAsync();
                    await torrentStream.CopyToAsync(fileStream);
                }
            }
        }

        private async Task<T> GetAsync<T>(string route)
            where T : new()
        {
            using (var response = await _httpClient.GetAsync($"{BlutopiaConstants.Routes.BlutopiaApiUrl}{route}"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Did not receive successful response from {route}");
                }

                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
