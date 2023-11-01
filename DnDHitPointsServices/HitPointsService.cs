using DnDHitPointsServices.Dtos;
using DnDHitPointsServices.Entities;

namespace DnDHitPointsServices
{
    public class HitPointsService : IHitPointsService
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IHitPointsRepository hitPointsRepository;

        public HitPointsService(ICharacterRepository characterRepository, IHitPointsRepository hitPointsRepository)
        {
            this.characterRepository = characterRepository;
            this.hitPointsRepository = hitPointsRepository;
        }

        /// <summary>
        /// Adds Temporary Hit Points for character identified by character's name
        /// If current temporary hit points are higher this method does nothing
        /// </summary>
        /// <param name="characterName">Name of the character we dealing damage to</param>
        /// <param name="amount"></param>
        public HitPoints AddTemporaryHitPoints(string characterName, int amount)
        {
            // Grabs character hit points from repository by character's name
            HitPoints hitPoints = this.hitPointsRepository.Get(characterName);

            // Check if repository returned any object, else throw an missing character hit points exception
            if (hitPoints == null)
            {
                throw new KeyNotFoundException("The given character name was not present in the database");
            }

            // update only if character temporary hit points are lower than a new amount
            UpdateTempHitPoints(amount, hitPoints);

            return hitPoints;
        }

        /// <summary>
        /// Deals damage of specific damage type to specific character identified by his/her name
        /// </summary>
        /// <param name="characterName">Name of the character we dealing damage to</param>
        /// <param name="damageAmount">Amount of damage that is being delt</param>
        /// <param name="damageType">Type of the damage that is being delt</param>        
        public HitPoints DealDamage(string characterName, int damageAmount, DamageTypes damageType)
        {
            // Grabs character from repository by character's name
            Character character = this.characterRepository.Get(characterName);
            HitPoints hitPoints = this.hitPointsRepository.Get(characterName);

            // Check if repository returned necessary data, else throw an missing data exception
            if (character == null || hitPoints == null)
            {
                throw new KeyNotFoundException("The given character name was not present in the database");
            }

            // Include defenses against damage that's going to be delt
            damageAmount = CalculateDamageAfterDefenses(damageType, damageAmount, character);

            if (hitPoints.TemporaryHitPoints > 0)
            {   
                //int temp = hitPoints.TemporaryHitPoints;
                hitPoints.TemporaryHitPoints -= damageAmount;

                if (hitPoints.TemporaryHitPoints <= 0)
                {
                    damageAmount = -hitPoints.TemporaryHitPoints;
                    hitPoints.TemporaryHitPoints = 0;
                }
            }

            // 
            hitPoints.CurrentHitPoints = Math.Max(hitPoints.CurrentHitPoints - damageAmount, 0);

            // update temp and current hit points
            this.hitPointsRepository.Update(hitPoints);

            return hitPoints;
        }

        public HitPoints Heal(string characterName, int amount)
        {
            // Grabs character from repository by character's name
            Character character = this.characterRepository.Get(characterName);
            HitPoints hitPoints = this.hitPointsRepository.Get(characterName);

            // Check if repository returned necessary data, else throw an missing data exception
            if (character == null || hitPoints == null)
            {
                throw new KeyNotFoundException("The given character name was not present in the database");
            }

            // Heal by the amount but no more than max character hit points
            hitPoints.CurrentHitPoints = Math.Min(hitPoints.CurrentHitPoints + amount, character.HitPoints);

            // Update character hit points
            this.hitPointsRepository.Update(hitPoints);

            return hitPoints;
        }

        private HitPoints DealTempDamage(HitPoints hitPoints, int damageAmount)
        {
            int tempValue = hitPoints.TemporaryHitPoints;
            if (hitPoints.TemporaryHitPoints < damageAmount)
            {
                hitPoints.TemporaryHitPoints = 0;
                this.hitPointsRepository.Update(hitPoints);
                hitPoints.CurrentHitPoints = damageAmount - tempValue;
                return hitPoints;
            }

            hitPoints.TemporaryHitPoints -= damageAmount;
            this.hitPointsRepository.Update(hitPoints);

            return hitPoints;
        }

        private int CalculateDamageAfterDefenses(DamageTypes damageType, int damageAmount, Character character)
        {
            var defensesWithTheSameDamageType = character.Defenses.ToList().Where((defense) 
                => defense.DamageType == damageType).ToArray();

            if (defensesWithTheSameDamageType.Any(defense => defense.DefenseType == DefenseTypes.resistance))
            {
                damageAmount = (int)(damageAmount * 0.5f);
            }

            if (defensesWithTheSameDamageType.Any(defense => defense.DefenseType == DefenseTypes.immunity))
            {
                damageAmount = 0;
            }

            return damageAmount;
        }

        private void UpdateTempHitPoints(int amount, HitPoints hitPoints)
        {
            if (hitPoints.TemporaryHitPoints >= amount)
            {
                return;
            }

            hitPoints.TemporaryHitPoints = amount;

            this.hitPointsRepository.Update(hitPoints);
        }
    }
}
