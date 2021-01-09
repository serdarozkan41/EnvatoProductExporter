using Newtonsoft.Json;
using System;

namespace EnvatoItemGetter.Models
{
    public class IconWithLandscapePreview
    {
        [JsonProperty("icon_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri IconUrl { get; set; }

        [JsonProperty("landscape_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri LandscapeUrl { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
