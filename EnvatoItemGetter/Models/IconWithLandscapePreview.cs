using Newtonsoft.Json;
using System;

namespace EnvatoItemGetter.Models
{
    public class IconWithLandscapePreview
    {
        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("landscape_url")]
        public Uri LandscapeUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
