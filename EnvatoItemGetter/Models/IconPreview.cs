using Newtonsoft.Json;
using System;

namespace EnvatoItemGetter.Models
{
    public class IconPreview
    {
        [JsonProperty("icon_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri IconUrl { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
