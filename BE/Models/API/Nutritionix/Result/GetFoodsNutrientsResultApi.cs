using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BE.API.Nutritionix.Result
{
  
    public partial class GetFoodsNutrientsResultApi
    {
        [JsonProperty("success")]
        public Success[] Success { get; set; }
    }

    public partial class Success
    {
        [JsonProperty("foods")]
        public FoodNutritionsItem[] Foods { get; set; }
    }

    public partial class FoodNutritionsItem
    {
        public FoodNutritionsItem()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        [Key]
        [StringLength(250)]
        [JsonProperty("food_name")]
        public string FoodName { get; set; }

      
        [StringLength(250)]
        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [Required]
        [JsonProperty("serving_qty")]
        public long? ServingQty { get; set; }

        [JsonProperty("serving_unit")]
        public string ServingUnit { get; set; }

        [JsonProperty("serving_weight_grams")]
        public long? ServingWeightGrams { get; set; }

        [JsonProperty("nf_calories")]
        public double? NfCalories { get; set; }

        [JsonProperty("nf_total_fat")]
        public double? NfTotalFat { get; set; }

        [JsonProperty("nf_saturated_fat")]
        public double? NfSaturatedFat { get; set; }

        [JsonProperty("nf_cholesterol")]
        public double? NfCholesterol { get; set; }

        [JsonProperty("nf_sodium")]
        public double? NfSodium { get; set; }

        [JsonProperty("nf_total_carbohydrate")]
        public long? NfTotalCarbohydrate { get; set; }

        [JsonProperty("nf_dietary_fiber")]
        public long? NfDietaryFiber { get; set; }

        [JsonProperty("nf_sugars")]
        public long? NfSugars { get; set; }

        [JsonProperty("nf_protein")]
        public double? NfProtein { get; set; }

        [JsonProperty("nf_potassium")]
        public double? NfPotassium { get; set; }

        [JsonProperty("nf_p")]
        public double? NfP { get; set; }

        [JsonProperty("full_nutrients")]
        public FullNutrient[] FullNutrients { get; set; }

        [JsonProperty("nix_brand_name")]
        public object NixBrandName { get; set; }

        [JsonProperty("nix_brand_id")]
        public object NixBrandId { get; set; }

        [JsonProperty("nix_item_name")]
        public object NixItemName { get; set; }

        [JsonProperty("nix_item_id")]
        public object NixItemId { get; set; }

        [JsonProperty("upc")]
        public object Upc { get; set; }

        [JsonProperty("consumed_at")]
        public DateTimeOffset ConsumedAt { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("source")]
        public long? Source { get; set; }

        [JsonProperty("ndb_no")]
        public long? NdbNo { get; set; }

        [JsonProperty("tags")]
        public Tags Tags { get; set; }

        [JsonProperty("alt_measures")]
        public AltMeasure[] AltMeasures { get; set; }

        [JsonProperty("lat")]
        public object Lat { get; set; }

        [JsonProperty("lng")]
        public object Lng { get; set; }

        [JsonProperty("meal_type")]
        public long? MealType { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        [JsonProperty("sub_recipe")]
        public object SubRecipe { get; set; }
    }

    public partial class AltMeasure
    {
        [JsonProperty("serving_weight")]
        public long? ServingWeight { get; set; }

        [JsonProperty("measure")]
        public string Measure { get; set; }

        [JsonProperty("seq")]
        public long? Seq { get; set; }

        [JsonProperty("qty")]
        public long? Qty { get; set; }
    }

    public partial class FullNutrient
    {
        [JsonProperty("attr_id")]
        public long? AttrId { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("is_raw_food")]
        public bool IsRawFood { get; set; }
    }

    public partial class Photo
    {
        public Photo()
        {
            ID = Guid.NewGuid();
        }

        [Key]
        public Guid ID { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("highres")]
        public string Highres { get; set; }

        [JsonProperty("is_user_uploaded")]
        public bool IsUserUploaded { get; set; }
    }

    public partial class Tags
    {
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("measure")]
        public object Measure { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("food_group")]
        public long? FoodGroup { get; set; }

        [JsonProperty("tag_id")]
        public long? TagId { get; set; }
    }

    public partial class GetFoodsNutrientsResultApi
    {
        public static GetFoodsNutrientsResultApi FromJson(string json) => JsonConvert.DeserializeObject<GetFoodsNutrientsResultApi>(json, FoodNutritionConverter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GetFoodsNutrientsResultApi self) => JsonConvert.SerializeObject(self, FoodNutritionConverter.Settings);
    }

    internal static class FoodNutritionConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}


