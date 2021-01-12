using Newtonsoft.Json;

namespace EnvatoItemGetter.Models
{
    public class Previews
    {
        [JsonProperty("live_site")]
        public LiveSite? LiveSite { get; set; }

        [JsonProperty("icon_with_landscape_preview")]
        public IconWithLandscapePreview? IconWithLandscapePreview { get; set; }

        [JsonProperty("landscape_preview")]
        public LandscapePreview? LandscapePreview { get; set; }

        [JsonProperty("icon_preview")]
        public IconPreview? IconPreview { get; set; }
    }
}
