using DnDHitPointsServices.Dtos;
using Newtonsoft.Json;

namespace TestDnDHitPointsServices
{
    [TestFixture]
    public class DefenseTypesEnumConverterTest
    {
        [TestCase("resistance", DefenseTypes.resistance)]
        [TestCase("immunity", DefenseTypes.immunity)]
        public void DeserializeDefenseTypesTest(string jsonEnumName, DefenseTypes defenseType)
        {
            // Arrange
            var jsonString = string.Format("{{ \"defense\" : \"{0}\" }}", jsonEnumName);

            // Act
            var deserializedObject = JsonConvert.DeserializeObject<Defense>(jsonString);

            // Assert
            Assert.That(deserializedObject.DefenseType, Is.EqualTo(defenseType));
        }

        [TestCase("resistance", DefenseTypes.resistance)]
        [TestCase("immunity", DefenseTypes.immunity)]
        public void SerializeDefenseTypesTest(string jsonEnumName, DefenseTypes defenseType)
        {
            // Arrange
            var obj = new Defense { DefenseType = defenseType };
            var expectedJsonString = string.Format("{{\"type\":\"bludgeoning\",\"defense\":\"{0}\"}}", jsonEnumName);

            // Act
            var actualJsonString = JsonConvert.SerializeObject(obj);

            // Assert
            Assert.That(actualJsonString, Is.EqualTo(expectedJsonString));
        }
    }
}
