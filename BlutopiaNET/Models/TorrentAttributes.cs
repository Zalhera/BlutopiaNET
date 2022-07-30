using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlutopiaNET.Models
{
    public class TorrentAttributes
    {
        [JsonPropertyName("meta")]
        public Metadata Meta { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("release_year")]
        public string ReleaseYear { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("resolution")]
        public string Resolution { get; set; }

        [JsonPropertyName("media_info")]
        public string MediaInfo { get; set; }

        [JsonPropertyName("bd_info")]
        public string BdInfo { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("info_hash")]
        public string InfoHash { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("num_file")]
        public int NumFile { get; set; }

        [JsonPropertyName("freeleech")]
        public string Freeleech { get; set; }

        [JsonPropertyName("double_upload")]
        public int DoubleUpload { get; set; }

        [JsonPropertyName("internal")]
        public int Internal { get; set; }

        [JsonPropertyName("uploader")]
        public string Uploader { get; set; }

        [JsonPropertyName("seeders")]
        public int Seeders { get; set; }

        [JsonPropertyName("leechers")]
        public int Leechers { get; set; }

        [JsonPropertyName("times_completed")]
        public int TimesCompleted { get; set; }

        [JsonPropertyName("tmdb_id")]
        public string TmdbId { get; set; }

        [JsonPropertyName("imdb_id")]
        public string ImdbId { get; set; }

        [JsonPropertyName("tvdb_id")]
        public string TvdbId { get; set; }

        [JsonPropertyName("mal_id")]
        public string MalId { get; set; }

        [JsonPropertyName("igdb_id")]
        public string IgdbId { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        [JsonPropertyName("resolution_id")]
        public int ResolutionId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("download_link")]
        public string DownloadLink { get; set; }

        [JsonPropertyName("details_link")]
        public string DetailsLink { get; set; }

        [JsonPropertyName("distributor")]
        public string Distributor { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("distributor_id")]
        public int? DistributorId { get; set; }

        [JsonPropertyName("region_id")]
        public int? RegionId { get; set; }
    }
}
