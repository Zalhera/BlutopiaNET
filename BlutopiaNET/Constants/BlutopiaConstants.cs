using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlutopiaNET.Constants
{
    public static class BlutopiaConstants
    {
        public static class Routes
        {
            public const string BlutopiaApiUrl = "https://blutopia.xyz/api";

            public const string UploadSubUrl = "/torrents/upload";
            public const string TorrentsSubUrl = "/torrents";
        }

        public static class RouteParameters
        {
            public const string FilterParameter = "filter";
            public const string ApiTokenParameter = "api_token";
            public const string PageParameter = "page";
            public const string NameParameter = "name";
            public const string DescriptionParameter = "description";
            public const string UploaderParameter = "uploader";
            public const string TmdbParameter = "tmdb";
            public const string ImdbParameter = "imdb";
            public const string TvdbParameter = "tvdb";
            public const string MalParameter = "mal";
            public const string IgdbParameter = "igdb";
            public const string StartYearParameter = "start_year";
            public const string EndYearParameter = "end_year";
            public const string CategoriesParameter = "category";
            public const string TypesParameter = "types";
            public const string GenresParameter = "genres";
            public const string FreeleechParameter = "freeleech";
            public const string DoubleUploadParameter = "doubleupload";
            public const string FeaturedParameter = "featured";
            public const string StreamParameter = "stream";
            public const string HighspeedParameter = "highspeed";
            public const string SdParameter = "sd";
            public const string InternalParameter = "internal";
            public const string AliveParameter = "alive";
            public const string DyingParameter = "dying";
            public const string DeadParameter = "dead";
        }
    }
}
