using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
