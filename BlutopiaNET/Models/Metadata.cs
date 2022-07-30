using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlutopiaNET.Models
{
    public class Metadata
    {
        [JsonPropertyName("poster")]
        public string Poster { get; set; }

        [JsonPropertyName("genres")]
        public string Genres { get; set; }

        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonPropertyName("links")]
        public List<Link> Links { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
