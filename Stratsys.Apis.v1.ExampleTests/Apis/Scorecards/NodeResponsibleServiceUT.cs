using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class NodeResponsibleServiceUT : BaseTest
    {
        [TestCase("3030", null, "1", 3)]
        [TestCase("3030", "1", "1", 1)]
        [TestCase("3030", "2", "1", 1)]
        [TestCase("3030", "94", "1", 1)]
        public void Get_for_node(string nodeId, string departmentId, string responsibilityRoleId, int expectedCount)
        {
            var nodeResponsibleDto = new NodeResponsibleDto
            {
                NodeId = nodeId,
                DepartmentId = departmentId,
                ResponsibilityRoleId = responsibilityRoleId
            };
            var responsibilites = Api.NodeResponsibles.Filter(nodeResponsibleDto).Fetch().Result;
            Assert.That(responsibilites.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("3030", null, "1", 3)]
        [TestCase("3030", "1", "1", 1)]
        [TestCase("3030", "2", "1", 1)]
        [TestCase("3030", "94", "1", 1)]
        public void Get_resp_for_node(string nodeId, string departmentId, string responsibilityRoleId, int expectedCount)
        {
           


            var nodeResponsibleDto = new NodeResponsibleDto
            {
                NodeId = nodeId,
                DepartmentId = departmentId,
                ResponsibilityRoleId = responsibilityRoleId
            };
            var responsibilites = Api.NodeResponsibles.Filter(nodeResponsibleDto).Fetch().Result;
            Assert.That(responsibilites.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("23", null, 1)]
        [TestCase("23", "1", 1)]
        [TestCase("3030", null, 3)]
        [TestCase("3030", "1", 1)]
        [TestCase("3030", "2", 1)]
        [TestCase("3030", "94", 1)]
        public void Get_all_for_node(string nodeId, string departmentId, int expectedCount)
        {
            var nodeResponsibleDto = new NodeResponsibleDto
            {
                NodeId = nodeId,
                DepartmentId = departmentId
            };
            var responsibilites = Api.NodeResponsibles.Filter(nodeResponsibleDto).Fetch().Result;
            Assert.That(responsibilites.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("265", "1", 23)]
        [TestCase("265", "2", 1)]
        [TestCase("265", null, 24)]
        public void Get_all_for_user(string userId, string departmentId, int expectedCount)
        {
            var nodeResponsibleDto = new NodeResponsibleDto
            {
                UserId = userId,
                DepartmentId = departmentId
            };
            var responsibilites = Api.NodeResponsibles.Filter(nodeResponsibleDto).Fetch().Result;
            Assert.That(responsibilites.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("4", "1", "1", "265")]
        [TestCase("7", "1", "1", "265")]
        public void Create(string nodeId, string departmentId, string responsibilityRoleId, string userId)
        {
            var nodeResponsibleDto = new NodeResponsibleDto
            {
                DepartmentId = departmentId,
                NodeId = nodeId,
                ResponsibilityRoleId = responsibilityRoleId,
                UserId = userId
            };
            var metadata = Api.NodeResponsibles.Create(nodeResponsibleDto).Fetch();
            Assert.That(metadata.Message, Is.Null);
            Assert.That(metadata.Success);
            var getMetadata = Api.NodeResponsibles.Filter(nodeResponsibleDto).Fetch();
            Assert.That(getMetadata.Message, Is.Null);
            Assert.That(getMetadata.Success);
            Assert.That(getMetadata.Result.Count, Is.EqualTo(1));
        }

        [TestCase("4", "1", "1", "265")]
        [TestCase("7", "1", "1", "265")]
        public void Delete(string nodeId, string departmentId, string responsibilityRoleId, string userId)
        {
            var nodeResponsibleDto = new NodeResponsibleDto
            {
                DepartmentId = departmentId,
                NodeId = nodeId,
                ResponsibilityRoleId = responsibilityRoleId,
                UserId = userId
            };
            var metadata = Api.NodeResponsibles.Delete(nodeResponsibleDto).Fetch();
            Assert.That(metadata.Message, Is.Null);
            Assert.That(metadata.Success);
            var getMetadata = Api.NodeResponsibles.Filter(nodeResponsibleDto).Fetch();
            Assert.That(getMetadata.Message, Is.Null);
            Assert.That(getMetadata.Success);
            Assert.That(getMetadata.Result.Count, Is.EqualTo(0));
        }
    }
}