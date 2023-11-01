using Newtonsoft.Json;

namespace DnDHitPointsServices.Dtos
{
    public class DefenseTypesEnumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DefenseTypes defenseType = (DefenseTypes)value;
            writer.WriteValue(Enum.GetName(typeof(DefenseTypes), defenseType));
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(DefenseTypes), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
