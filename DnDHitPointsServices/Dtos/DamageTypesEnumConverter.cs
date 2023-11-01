using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDHitPointsServices.Dtos
{
    internal class DamageTypesEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(DamageTypes), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            DamageTypes damageType = (DamageTypes)value;
            writer.WriteValue(Enum.GetName(typeof(DamageTypes), damageType));
        }
    }
}
