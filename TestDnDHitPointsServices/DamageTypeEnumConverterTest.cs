using DnDHitPointsServices.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDnDHitPointsServices
{
    [TestFixture]
    public class DamageTypeEnumConverterTest
    {
        [TestCase("bludgeoning", DamageTypes.bludgeoning)]
        [TestCase("piercing", DamageTypes.piercing)]
        [TestCase("slashing", DamageTypes.slashing)]
        [TestCase("fire", DamageTypes.fire)]
        [TestCase("cold", DamageTypes.cold)]
        [TestCase("acid", DamageTypes.acid)]
        [TestCase("thunder", DamageTypes.thunder)]
        [TestCase("lightning", DamageTypes.lightning)]
        [TestCase("poison", DamageTypes.poison)]
        [TestCase("radiant", DamageTypes.radiant)]
        [TestCase("necrotic", DamageTypes.necrotic)]
        [TestCase("psychic", DamageTypes.psychic)]
        [TestCase("force", DamageTypes.force)]
        public void DeserializeDefenseTypesTest(string jsonEnumName, DamageTypes damageType)
        {
            // Arrange
            var jsonString = string.Format("{{ \"type\" : \"{0}\" }}", jsonEnumName);

            // Act
            var deserializedObject = JsonConvert.DeserializeObject<Defense>(jsonString);

            // Assert
            Assert.That(deserializedObject.DamageType, Is.EqualTo(damageType));
        }

        [TestCase("bludgeoning", DamageTypes.bludgeoning)]
        [TestCase("piercing", DamageTypes.piercing)]
        [TestCase("slashing", DamageTypes.slashing)]
        [TestCase("fire", DamageTypes.fire)]
        [TestCase("cold", DamageTypes.cold)]
        [TestCase("acid", DamageTypes.acid)]
        [TestCase("thunder", DamageTypes.thunder)]
        [TestCase("lightning", DamageTypes.lightning)]
        [TestCase("poison", DamageTypes.poison)]
        [TestCase("radiant", DamageTypes.radiant)]
        [TestCase("necrotic", DamageTypes.necrotic)]
        [TestCase("psychic", DamageTypes.psychic)]
        [TestCase("force", DamageTypes.force)]
        public void SerializeDefenseTypesTest(string jsonEnumName, DamageTypes damageType)
        {
            // Arrange
            var obj = new Defense { DamageType = damageType };
            var expectedJsonString = string.Format("{{\"type\":\"{0}\",\"defense\":\"immunity\"}}", jsonEnumName);

            // Act
            var actualJsonString = JsonConvert.SerializeObject(obj);

            // Assert
            Assert.That(actualJsonString, Is.EqualTo(expectedJsonString));
        }
    }
}
