using BlutopiaNET.Constants;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace BlutopiaNET.Models
{
    public class Filter
    {
        internal static readonly Dictionary<string, PropertyInfo> FilterMapping = new Dictionary<string, PropertyInfo>()
        {
            { BlutopiaConstants.RouteParameters.NameParameter, typeof(Filter).GetProperty(nameof(Name))! },
            { BlutopiaConstants.RouteParameters.DescriptionParameter, typeof(Filter).GetProperty(nameof(Description))! },
            { BlutopiaConstants.RouteParameters.UploaderParameter, typeof(Filter).GetProperty(nameof(Uploader))! },
            { BlutopiaConstants.RouteParameters.TmdbParameter, typeof(Filter).GetProperty(nameof(Tmdb))! },
            { BlutopiaConstants.RouteParameters.TvdbParameter, typeof(Filter).GetProperty(nameof(Tvdb))! },
            { BlutopiaConstants.RouteParameters.MalParameter, typeof(Filter).GetProperty(nameof(Mal))! },
            { BlutopiaConstants.RouteParameters.IgdbParameter, typeof(Filter).GetProperty(nameof(Igdb))! },
            { BlutopiaConstants.RouteParameters.StartYearParameter, typeof(Filter).GetProperty(nameof(StartYear))! },
            { BlutopiaConstants.RouteParameters.EndYearParameter, typeof(Filter).GetProperty(nameof(EndYear))! },
            { BlutopiaConstants.RouteParameters.CategoriesParameter, typeof(Filter).GetProperty(nameof(Categories))! },
            { BlutopiaConstants.RouteParameters.TypesParameter, typeof(Filter).GetProperty(nameof(Types))! },
            { BlutopiaConstants.RouteParameters.GenresParameter, typeof(Filter).GetProperty(nameof(Genres))! },
            { BlutopiaConstants.RouteParameters.FreeleechParameter, typeof(Filter).GetProperty(nameof(IsFreeleech))! },
            { BlutopiaConstants.RouteParameters.DoubleUploadParameter, typeof(Filter).GetProperty(nameof(IsDoubleUpload))! },
            { BlutopiaConstants.RouteParameters.FeaturedParameter, typeof(Filter).GetProperty(nameof(IsFeatured))! },
            { BlutopiaConstants.RouteParameters.StreamParameter, typeof(Filter).GetProperty(nameof(IsStreamOptimized))! },
            { BlutopiaConstants.RouteParameters.HighspeedParameter, typeof(Filter).GetProperty(nameof(IsHighspeed))! },
            { BlutopiaConstants.RouteParameters.SdParameter, typeof(Filter).GetProperty(nameof(IsSd))! },
            { BlutopiaConstants.RouteParameters.InternalParameter, typeof(Filter).GetProperty(nameof(IsInternal))! },
            { BlutopiaConstants.RouteParameters.AliveParameter, typeof(Filter).GetProperty(nameof(IsAlive))! },
            { BlutopiaConstants.RouteParameters.DyingParameter, typeof(Filter).GetProperty(nameof(IsDying))! },
            { BlutopiaConstants.RouteParameters.DeadParameter, typeof(Filter).GetProperty(nameof(IsDead))! },
        };

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Uploader { get; set; }
        public int? Tmdb { get; set; }
        public int? Tvdb { get; set; }
        public int? Mal { get; set; }
        public int? Igdb { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string[]? Categories { get; set; }
        public string[]? Types { get; set; }
        public string[]? Genres { get; set; }
        public bool? IsFreeleech { get; set; }
        public bool? IsDoubleUpload { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsStreamOptimized { get; set; }
        public bool? IsHighspeed { get; set; }
        public bool? IsSd { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsAlive { get; set; }
        public bool? IsDying { get; set; }
        public bool? IsDead { get; set; }

        [DebuggerStepThrough]
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"/{BlutopiaConstants.RouteParameters.FilterParameter}?");

            foreach(var pair in FilterMapping)
            {
                object? value = pair.Value.GetValue(this);

                if (value == null)
                    continue;

                if(pair.Value.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                    Nullable.GetUnderlyingType(pair.Value.PropertyType) == typeof(string[]))
                {
                    var listValue = value as string[];

                    if(listValue != null)
#if NETSTANDARD2_0
                        stringBuilder.Append($"{pair.Key}=[{string.Join(",", listValue)}]&");
#else
                        stringBuilder.Append($"{pair.Key}=[{string.Join(',', listValue)}]&");
#endif
                }
                else
                {
                    stringBuilder.Append($"{pair.Key}={value.ToString()}&");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
