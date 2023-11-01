using DnDHitPointsServices.Dtos;
using DnDHitPointsServices.Entities;

namespace DnDHitPointsServices
{
    public interface IHitPointsService
    {
        public HitPoints DealDamage(string characterName, int damageAmount, DamageTypes damageType);

        public HitPoints Heal(string characterName, int amount);

        public HitPoints AddTemporaryHitPoints(string characterName, int amount);
    }
}
