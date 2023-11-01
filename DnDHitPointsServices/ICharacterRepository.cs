using DnDHitPointsServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDHitPointsServices
{
    public interface ICharacterRepository
    {
        void Add(Character character);
        Character? Get(string characterName);        
    }
}
