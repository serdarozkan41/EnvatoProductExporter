using Newtonsoft.Json;

namespace EnvatoItemGetter.Models
{
    public class Previews
    {
        [JsonProperty("live_site", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public LiveSite LiveSite { get; set; }

        [JsonProperty("icon_with_landscape_preview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IconWithLandscapePreview IconWithLandscapePreview { get; set; }

        [JsonProperty("landscape_preview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public LandscapePreview LandscapePreview { get; set; }

        [JsonProperty("icon_preview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IconPreview IconPreview { get; set; }
    }
}
