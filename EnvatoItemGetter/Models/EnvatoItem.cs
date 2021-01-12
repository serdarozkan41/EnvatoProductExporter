using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnvatoItemGetter.Models
{
    public class EnvatoItem
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("number_of_sales")]
        public long? NumberOfSales { get; set; }

        [JsonProperty("author_username")]
        public string AuthorUsername { get; set; }

        [JsonProperty("author_url")]
        public Uri AuthorUrl { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("wordpress_theme_metadata")]
        public WordpressThemeMetadata WordpressThemeMetadata { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("classification_url")]
        public Uri ClassificationUrl { get; set; }

        [JsonProperty("price_cents")]
        public long? PriceCents { get; set; }

        [JsonProperty("author_image")]
        public Uri? AuthorImage { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("rating")]
        public double? Rating { get; set; }

        [JsonProperty("rating_count")]
        public long? RatingCount { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("trending")]
        public bool? Trending { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("previews")]
        public Previews Previews { get; set; }
    }
}
