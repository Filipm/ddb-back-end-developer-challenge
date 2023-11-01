using DnDHitPointsServices;
using DnDHitPointsServices.Dtos;
using DnDHitPointsServices.Entities;

namespace DnDHitPointsInfrastructure
{
    public class HitPointsRepository : IHitPointsRepository
    {
        private readonly HitPointsContext _hitPointsContext;

        public HitPointsRepository(HitPointsContext hitPointsContext)
        {
            this._hitPointsContext = hitPointsContext;
        }

        public HitPoints? Get(string characterName)
        {
            return _hitPointsContext.HitPoints.SingleOrDefault(x => x.CharacterName == characterName);            
        }

        public void Update(HitPoints hitPoints)
        {
            _hitPointsContext.Update(hitPoints);
            _hitPointsContext.SaveChanges();
        }
    }
}
