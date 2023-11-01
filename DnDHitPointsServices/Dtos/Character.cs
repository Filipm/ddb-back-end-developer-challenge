using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDHitPointsServices.Dtos
{
    
    public class Character
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("hitPoints")]
        public int HitPoints { get; set; }

        //public IEnumerable<DnDClass> Classes { get; set; }

        //public Stats Stats { get; set; }

        //public IEnumerable<Item> Items { get; set; }

        [JsonProperty("defenses")]        
        //[JsonConverter(typeof(List<Defense>))]
        public List<Defense> Defenses { get; set; }
    }
}
