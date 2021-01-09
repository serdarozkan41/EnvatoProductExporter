using Newtonsoft.Json;

namespace EnvatoItemGetter.Models
{
    public class WordpressThemeMetadata
    {
        [JsonProperty("theme_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ThemeName { get; set; }

        [JsonProperty("author_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        [JsonProperty("version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
