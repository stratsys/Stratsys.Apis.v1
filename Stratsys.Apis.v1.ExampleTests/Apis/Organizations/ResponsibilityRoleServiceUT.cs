using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class ResponsibilityRoleServiceUT : ClientBaseTest
    {
        [TestCase(7)]
        public void Get_all(int expectedCount)
        {
            var roleDtos = Api.ResponsibilityRoles.List().Result;
            Assert.That(roleDtos.Count, Is.EqualTo(expectedCount));
        }

        [TestCase(7)]
        public void Get_all_filter(int expectedCount)
        {
            var roleDtos = Api.ResponsibilityRoles.Filter().Result;
            Assert.That(roleDtos.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", "Ansvarig")]
        [TestCase("3", "Utförs av:")]
        [TestCase("505", "Vem rapporterar")]
        public void Get_by_id(string id, string name)
        {
            var responsibilityRoleDto = Api.ResponsibilityRoles.Get(id).Result;
            Assert.That(responsibilityRoleDto.Name, Is.EqualTo(name));
        }

        [Test]
        public void Get_all_properties()
        {
            const string id = "505";
            var fetch = Api.ResponsibilityRoles.Get(id).Fetch();
            Assert.That(fetch, Has.Message.Null);
            var responsibilityRoleDto = Api.ResponsibilityRoles.Get(id).Result;
            Assert.That(responsibilityRoleDto.Name, Is.EqualTo("Vem rapporterar"));
            Assert.That(responsibilityRoleDto.Description, Is.EqualTo("Den person som är ansvarig för rapporteringen i Stratsys"));
            Assert.That(responsibilityRoleDto.IsDepartmentSpecific);
        }

        [Test]
        public void Get_all_for_scorecard_column_by_filter()
        {
            var dtos = Api.Scorecard("1").Columns.Result;
            var scorecardColumnDto = dtos[1];
            Assert.That(scorecardColumnDto.NodeType, Is.EqualTo("Goal"));
            Assert.That(scorecardColumnDto.Id, Is.EqualTo("2"));

            var roleDtos = Api.ResponsibilityRoles.Filter(scorecardColumnDto.Id).Result;
            Assert.That(roleDtos.Count, Is.EqualTo(1));
        }

        [Test]
        public void Get_all_for_scorecard_column()
        {
            var roleDtos = Api
                .ScorecardColumn("2")
                .ResponsibilityRoles
                .List()
                .Result;
            Assert.That(roleDtos.Count, Is.EqualTo(1));
        }
    }
}