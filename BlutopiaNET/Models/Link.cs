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
        public string Url { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }

        [JsonPropertyName("prev")]
        public object Prev { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
