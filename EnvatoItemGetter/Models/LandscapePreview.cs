using Newtonsoft.Json;
using System;

namespace EnvatoItemGetter.Models
{
    public class LandscapePreview
    {
        [JsonProperty("landscape_url")]
        public Uri LandscapeUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
