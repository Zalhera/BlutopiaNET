using System.Text.Json.Serialization;

namespace BlutopiaNET.Models
{
    public class TorrentCollection
    {
        [JsonPropertyName("data")]
        public List<Torrent> Torrents { get; set; } = new List<Torrent>();

        [JsonPropertyName("links")]
        public Link Links { get; set; } = default!;

        [JsonPropertyName("meta")]
        public Metadata Metadata { get; set; } = default!;
    }
}
