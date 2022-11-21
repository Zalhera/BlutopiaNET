using System.Text.Json.Serialization;

namespace BlutopiaNET.Models
{
    public class Metadata
    {
        [JsonPropertyName("poster")]
        public string Poster { get; set; } = string.Empty;

        [JsonPropertyName("genres")]
        public string Genres { get; set; } = string.Empty;

        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonPropertyName("links")]
        public List<Link> Links { get; set; } = new List<Link>();

        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
