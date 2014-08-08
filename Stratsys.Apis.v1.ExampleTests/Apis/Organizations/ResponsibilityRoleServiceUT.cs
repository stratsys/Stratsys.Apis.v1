using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class ResponsibilityRoleServiceUT : BaseTest
    {
        [TestCase(7)]
        public void Get_all(int expectedCount)
        {
            var metadata = Api.ResponsibilityRoles.Filter().Fetch();
            Assert.That(metadata.Message, Is.Null);
            Assert.That(metadata.Success);
            var roleDtos = metadata.Result;
            Assert.That(roleDtos.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", "Ansvarig")]
        [TestCase("3", "Utförs av:")]
        [TestCase("505", "Vem rapporterar")]
        public void Get_by_id(string id, string name)
        {
            var metadata = Api.ResponsibilityRoles.Get(id).Fetch();
            Assert.That(metadata.Message, Is.Null);
            Assert.That(metadata.Success);
            var responsibilityRoleDto = metadata.Result;
            Assert.That(responsibilityRoleDto.Name, Is.EqualTo(name));
        }

        [Test]
        public void Get_all_properties()
        {
            const string id = "505";
            var metadata = Api.ResponsibilityRoles.Get(id).Fetch();
            Assert.That(metadata.Message, Is.Null);
            Assert.That(metadata.Success);
            var responsibilityRoleDto = metadata.Result;
            Assert.That(responsibilityRoleDto.Name, Is.EqualTo("Vem rapporterar"));
            Assert.That(responsibilityRoleDto.Description, Is.EqualTo("Den person som är ansvarig för rapporteringen i Stratsys"));
            Assert.That(responsibilityRoleDto.IsDepartmentSpecific);
        }

    }
}