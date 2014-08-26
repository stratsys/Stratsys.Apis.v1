using System.Linq;
using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class DescriptionFieldServiceUT : BaseTest
    {
        [TestCase(35)]
        public void Get_all(int count)
        {
            var descriptionFieldDtos = Api.DescriptionFields.Filter().Result;
            Assert.That(descriptionFieldDtos.Count, Is.EqualTo(count));
        }

        [TestCase("1", "Syfte", "Svara på frågan ”Varför?”")]
        [TestCase("2", "Mätmetod och rutiner", "Beskriv vilka rutiner ni har")]
        [TestCase("4", "Syfte och önskad effekt", "Med detta menas...")]
        public void Get_by_id(string id, string name, string description)
        {
            var descriptionFieldDto = Api.DescriptionFields.Get(id).Fetch().Result;
            Assert.That(descriptionFieldDto.Id, Is.EqualTo(id));
            Assert.That(descriptionFieldDto.Name, Is.EqualTo(name));

            var take = descriptionFieldDto.Description.Substring(0, description.Length);
            Assert.That(take, Is.EqualTo(description));
        }

        [TestCase("32", "Förtydligande av process/rutin", "Här skrivs en förklarande te")]
        [TestCase("6", "Enhetsbeteckning", "Används i KKiK")]
        public void Get_by_name(string id, string name, string description)
        {
            var descriptionFieldDto = Api.DescriptionFields.Filter(name).Result.Single();
            Assert.That(descriptionFieldDto.Id, Is.EqualTo(id));
            Assert.That(descriptionFieldDto.Name, Is.EqualTo(name));

            var take = descriptionFieldDto.Description.Substring(0, description.Length);
            Assert.That(take, Is.EqualTo(description));
        }


    }
}