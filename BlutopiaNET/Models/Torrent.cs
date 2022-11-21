using System.Text.Json.Serialization;

namespace BlutopiaNET.Models
{
    public class Torrent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("attributes")]
        public TorrentAttributes Attributes { get; set; } = default!;
    }
}
