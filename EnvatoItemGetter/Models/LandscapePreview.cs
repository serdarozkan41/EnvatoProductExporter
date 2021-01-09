using Newtonsoft.Json;
using System;

namespace EnvatoItemGetter.Models
{
    public class LandscapePreview
    {
        [JsonProperty("landscape_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri LandscapeUrl { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
