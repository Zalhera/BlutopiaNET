using BlutopiaNET.Constants;
using BlutopiaNET.Models;
using System.Net;
using System.Text.Json;

namespace BlutopiaNET.Client
{
    /// <summary>
    /// HTTP Client wrapper for Blutopia API
    /// </summary>
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
        }

        /// <summary>
        /// Query torrents with pagination and optional filter
        /// </summary>
        /// <param name="page">Page (15 torrents per page)</param>
        /// <param name="filter">Filter options</param>
        /// <exception cref="HttpRequestException">Thrown on non successful HTTP response</exception>
        /// <returns>List of torrents, null if invalid payload</returns>
        public async Task<TorrentCollection?> GetTorrentsAsync(int? page = null, Filter? filter = null)
        {
            return await GetAsync<TorrentCollection?>($"{BlutopiaConstants.Routes.TorrentsSubUrl}" +
                $"{(filter != null ? filter.ToString() : "")}" +
                $"{(page != null ? filter != null ? $"&{BlutopiaConstants.RouteParameters.PageParameter}={page}" : $"?{BlutopiaConstants.RouteParameters.PageParameter}={page}" : "")}");
        }

        /// <summary>
        /// Query specific torrent
        /// </summary>
        /// <param name="torrentId">Id of specific torrent</param>
        /// <exception cref="HttpRequestException">Thrown on non successful HTTP response</exception>
        /// <returns>Single torrent, null if invalid payload</returns>
        public async Task<Torrent?> GetTorrentAsync(int torrentId)
        {
            return await GetAsync<Torrent?>($"{BlutopiaConstants.Routes.TorrentsSubUrl}/{torrentId}");
        }

        /// <summary>
        /// Download torrent to file
        /// </summary>
        /// <param name="torrent">Torrent to download</param>
        /// <param name="path">Path for torrent file</param>
        /// <param name="fileName">Name of torrent file</param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException">Thrown on non successful HTTP response</exception>
        public async Task DownloadTorrentAsync(Torrent torrent, string path, string? fileName = null)
        {
            using (var response = await _httpClient.GetAsync(torrent.Attributes.DownloadLink))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Unable to download torrent from {torrent.Attributes.DownloadLink}");
                }

                using (var fileStream = new FileStream(Path.Combine(path, fileName ?? $"{torrent.Attributes.InfoHash}.torrent"), FileMode.Create, FileAccess.Write))
                {
                    var torrentStream = await response.Content.ReadAsStreamAsync();
                    await torrentStream.CopyToAsync(fileStream);
                }
            }
        }

        private async Task<T?> GetAsync<T>(string route)
            where T : new()
        {
            using (var response = await _httpClient.GetAsync($"{BlutopiaConstants.Routes.BlutopiaApiUrl}{route}"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Did not receive successful response from {route}");
                }

                try
                {
                    return JsonSerializer.Deserialize<T?>(await response.Content.ReadAsStringAsync());
                }
                catch
                {
                    return default(T);
                }
            }
        }

        public void Dispose()
        {
            _handler?.Dispose();
            _httpClient?.Dispose();
        }
    }
}
