using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlutopiaNET.Models
{
    public class Link
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; } = string.Empty;

        [JsonPropertyName("last")]
        public string Last { get; set; } = string.Empty;

        [JsonPropertyName("prev")]
        public object Prev { get; set; } = string.Empty;

        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;

        [JsonPropertyName("self")]
        public string Self { get; set; } = string.Empty;
    }
}
