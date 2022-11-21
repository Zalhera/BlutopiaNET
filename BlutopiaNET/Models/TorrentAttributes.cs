using System.Text.Json.Serialization;

namespace BlutopiaNET.Models
{
    public class TorrentAttributes
    {
        [JsonPropertyName("meta")]
        public Metadata Meta { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("release_year")]
        public string ReleaseYear { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("resolution")]
        public string Resolution { get; set; } = string.Empty;

        [JsonPropertyName("media_info")]
        public string MediaInfo { get; set; } = string.Empty;

        [JsonPropertyName("bd_info")]
        public string BdInfo { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("info_hash")]
        public string InfoHash { get; set; } = string.Empty;

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("num_file")]
        public int NumFile { get; set; }

        [JsonPropertyName("freeleech")]
        public string Freeleech { get; set; } = string.Empty;

        [JsonPropertyName("double_upload")]
        public int DoubleUpload { get; set; }

        [JsonPropertyName("internal")]
        public int Internal { get; set; }

        [JsonPropertyName("uploader")]
        public string Uploader { get; set; } = string.Empty;

        [JsonPropertyName("seeders")]
        public int Seeders { get; set; }

        [JsonPropertyName("leechers")]
        public int Leechers { get; set; }

        [JsonPropertyName("times_completed")]
        public int TimesCompleted { get; set; }

        [JsonPropertyName("tmdb_id")]
        public string TmdbId { get; set; } = string.Empty;

        [JsonPropertyName("imdb_id")]
        public string ImdbId { get; set; } = string.Empty;

        [JsonPropertyName("tvdb_id")]
        public string TvdbId { get; set; } = string.Empty;

        [JsonPropertyName("mal_id")]
        public string MalId { get; set; } = string.Empty;

        [JsonPropertyName("igdb_id")]
        public string IgdbId { get; set; } = string.Empty;

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        [JsonPropertyName("resolution_id")]
        public int ResolutionId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("download_link")]
        public string DownloadLink { get; set; } = string.Empty;

        [JsonPropertyName("details_link")]
        public string DetailsLink { get; set; } = string.Empty;

        [JsonPropertyName("distributor")]
        public string Distributor { get; set; } = string.Empty;

        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;

        [JsonPropertyName("distributor_id")]
        public int? DistributorId { get; set; }

        [JsonPropertyName("region_id")]
        public int? RegionId { get; set; }
    }
}
