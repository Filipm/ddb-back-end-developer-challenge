using DnDHitPointsServices;
using DnDHitPointsServices.Dtos;
using System.Reflection;
using Newtonsoft.Json;

namespace DnDHitPointsInfrastructure
{
    public class CharacterRepository : ICharacterRepository
    {
        List<Character> _characterList = new List<Character>();        

        public Character? Get(string characterName)
        {
            return _characterList.FirstOrDefault(x => x.Name == characterName);
        }

        public void Add(Character character)
        {
            _characterList.Add(character);
        }
    }
}
