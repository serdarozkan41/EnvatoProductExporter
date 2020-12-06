using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EnvatoProductExporter
{
    public partial class EnvatoItem
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

    public partial class Attribute
    {
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("value")]
        public Value? Value { get; set; }

        [JsonProperty("label", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
    }

    public partial class Previews
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

    public partial class IconPreview
    {
        [JsonProperty("icon_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri IconUrl { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public partial class IconWithLandscapePreview
    {
        [JsonProperty("icon_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri IconUrl { get; set; }

        [JsonProperty("landscape_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri LandscapeUrl { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public partial class LandscapePreview
    {
        [JsonProperty("landscape_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri LandscapeUrl { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public partial class LiveSite
    {
        [JsonProperty("href", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public partial class WordpressThemeMetadata
    {
        [JsonProperty("theme_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ThemeName { get; set; }

        [JsonProperty("author_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorName { get; set; }

        [JsonProperty("version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public partial struct Value
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator Value(string String) => new Value { String = String };
        public static implicit operator Value(List<string> StringArray) => new Value { StringArray = StringArray };
        public bool IsNull => StringArray == null && String == null;
    }

    public partial class EnvatoItem
    {
        public static EnvatoItem FromJson(string json) => JsonConvert.DeserializeObject<EnvatoItem>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this EnvatoItem self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ValueConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Value) || t == typeof(Value?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new Value { };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Value { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<string>>(reader);
                    return new Value { StringArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Value");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Value)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.StringArray != null)
            {
                serializer.Serialize(writer, value.StringArray);
                return;
            }
            throw new Exception("Cannot marshal type Value");
        }

        public static readonly ValueConverter Singleton = new ValueConverter();
    }
}
