
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace DnDHitPointsServices.Dtos
{
    public class Defense
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(DamageTypesEnumConverter))]
        public DamageTypes DamageType;

        [JsonProperty("defense")]
        [JsonConverter(typeof(DefenseTypesEnumConverter))]
        public DefenseTypes DefenseType;
    }
}