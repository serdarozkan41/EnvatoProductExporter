using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnvatoItemGetter.Models
{
    public class EnvatoItem
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("number_of_sales", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberOfSales { get; set; }

        [JsonProperty("author_username", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorUsername { get; set; }

        [JsonProperty("author_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri AuthorUrl { get; set; }

        [JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("updated_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("attributes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("wordpress_theme_metadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public WordpressThemeMetadata WordpressThemeMetadata { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("site", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Site { get; set; }

        [JsonProperty("classification", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Classification { get; set; }

        [JsonProperty("classification_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri ClassificationUrl { get; set; }

        [JsonProperty("price_cents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? PriceCents { get; set; }

        [JsonProperty("author_image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri AuthorImage { get; set; }

        [JsonProperty("summary", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Summary { get; set; }

        [JsonProperty("rating", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Rating { get; set; }

        [JsonProperty("rating_count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? RatingCount { get; set; }

        [JsonProperty("published_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("trending", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Trending { get; set; }

        [JsonProperty("tags", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        [JsonProperty("previews", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Previews Previews { get; set; }
    }
}
