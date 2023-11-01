using DnDHitPointsServices.Entities;

namespace DnDHitPointsServices
{
    public interface IHitPointsRepository
    {
        HitPoints? Get(string characterName);
        void Update(HitPoints hitPoints);
    }
}
