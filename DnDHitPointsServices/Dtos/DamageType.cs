using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace DnDHitPointsServices.Dtos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DamageTypes
    {
        bludgeoning,
        piercing,
        slashing,
        fire,
        cold,
        acid,
        thunder,
        lightning,
        poison,
        radiant,
        necrotic,
        psychic,
        force
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DefenseTypes
    {
        immunity,
        resistance
    }
}