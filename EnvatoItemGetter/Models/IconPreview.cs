using Newtonsoft.Json;
using System;

namespace EnvatoItemGetter.Models
{
    public class IconPreview
    {
        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
