using Newtonsoft.Json;

namespace EnvatoItemGetter.Models
{
    public partial class LiveSite
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
