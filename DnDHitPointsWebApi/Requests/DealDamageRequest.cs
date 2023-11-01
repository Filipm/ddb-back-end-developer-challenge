using DnDHitPointsServices.Dtos;

namespace DnDHitPointsWebApi.Requests
{
    public class DealDamageRequest
    {
        public string name { get; set; }

        public int amount { get; set; }

        public string damageType { get; set; }
    }
}
