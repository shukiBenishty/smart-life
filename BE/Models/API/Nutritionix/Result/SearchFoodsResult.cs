using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace BE.API.Nutritionix.Result
{
    public partial class SearchFoodsResult
    {
        [JsonProperty("success")]
        public Success[] Success { get; set; }
    }

    public partial class Success
    {
        [JsonProperty("branded")]
        public Branded[] Branded { get; set; }

        [JsonProperty("common")]
        public Common[] Common { get; set; }
    }

    public partial class Branded
    {
        [JsonProperty("food_name")]
        public string FoodName { get; set; }

        [JsonProperty("serving_unit")]
        public string ServingUnit { get; set; }

        [JsonProperty("nix_brand_id")]
        public string NixBrandId { get; set; }

        [JsonProperty("brand_name_item_name")]
        public string BrandNameItemName { get; set; }

        [JsonProperty("serving_qty")]
        public double ServingQty { get; set; }

        [JsonProperty("nf_calories")]
        public double NfCalories { get; set; }

        [JsonProperty("photo")]
        public BrandedPhoto Photo { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("region")]
        public long Region { get; set; }

        [JsonProperty("brand_type")]
        public long BrandType { get; set; }

        [JsonProperty("nix_item_id")]
        public string NixItemId { get; set; }

        [JsonProperty("locale")]
        public Locale Locale { get; set; }
    }

    public partial class BrandedPhoto
    {
        [Key]
        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("highres")]
        public object Highres { get; set; }

        [JsonProperty("is_user_uploaded", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUserUploaded { get; set; }
    }

    public partial class Common
    {
        [JsonProperty("food_name")]
        public string FoodName { get; set; }

        [JsonProperty("serving_unit")]
        public string ServingUnit { get; set; }

        [JsonProperty("serving_qty")]
        public long ServingQty { get; set; }

        [JsonProperty("photo")]
        public CommonPhoto Photo { get; set; }

        [JsonProperty("tag_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TagId { get; set; }

        [JsonProperty("locale")]
        public Locale Locale { get; set; }
    }

    public partial class CommonPhoto
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }
    }

    public enum Locale { EnUs };

    public partial class SearchFoodsResult
    {
        public static SearchFoodsResult FromJson(string json) => JsonConvert.DeserializeObject<SearchFoodsResult>(json, Converter.Settings);
        
    }

    
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                LocaleConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class LocaleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Locale) || t == typeof(Locale?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "en_US")
            {
                return Locale.EnUs;
            }
            throw new Exception("Cannot unmarshal type Locale");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Locale)untypedValue;
            if (value == Locale.EnUs)
            {
                serializer.Serialize(writer, "en_US");
                return;
            }
            throw new Exception("Cannot marshal type Locale");
        }

        public static readonly LocaleConverter Singleton = new LocaleConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
