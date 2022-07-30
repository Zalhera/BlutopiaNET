using BlutopiaNET.Constants;
using BlutopiaNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlutopiaNET.Client
{
    public sealed class BlutopiaClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiToken;

        public BlutopiaClient(string apiToken)
        {
            _apiToken = apiToken;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BlutopiaConstants.Routes.BlutopiaApiUrl),
            };
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);
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

        private async Task<T> GetAsync<T>(string route)
            where T : new()
        {
            using (var response = await _httpClient.GetAsync(route))
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
