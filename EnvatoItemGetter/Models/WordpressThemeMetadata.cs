using Newtonsoft.Json;

namespace EnvatoItemGetter.Models
{
    public class WordpressThemeMetadata
    {
        [JsonProperty("theme_name")]
        public string ThemeName { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
