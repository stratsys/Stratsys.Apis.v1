using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class NodeUsersUT : ClientBaseTest
    {
        private const string ScorecardId = "1";
        private const string RoleId = "1";

        [TestCase("3030", "1", 1)]
        [TestCase("3030", "2", 1)]
        [TestCase("3030", "94", 1)]
        public void Get_users_for_node_in_role(string nodeId, string departmentId, int expectedCount)
        {
            var nodesPath = Api.Node(ScorecardId, departmentId, nodeId);
            var users = nodesPath.Role(RoleId).Users.List().Result;

            Assert.That(users.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("4", "1", "1", "265")]
        [TestCase("7", "1", "1", "265")]
        public void Create(string nodeId, string departmentId, string responsibilityRoleId, string userId)
        {
            var nodesPath = Api.Node(ScorecardId, departmentId, nodeId);
            var users = nodesPath.Role(responsibilityRoleId).Users;

            var metadata = users.Put(userId).Fetch();
            Assert.That(metadata, Has.Message.Null);

            Assert.That(metadata.Result, Is.EqualTo(userId));

            var getMetadata = users.List().Fetch();
            Assert.That(getMetadata.Message, Is.Null);
            Assert.That(getMetadata.Result.Count, Is.EqualTo(1));
        }

        [TestCase("4", "1", "1", "265")]
        [TestCase("7", "1", "1", "265")]
        public void Delete(string nodeId, string departmentId, string responsibilityRoleId, string userId)
        {
            var nodesPath = Api.Node(ScorecardId, departmentId, nodeId);
            var users = nodesPath.Role(responsibilityRoleId).Users;

            var metadata = users.Delete(userId).Fetch();
            Assert.That(metadata.Message, Is.Null);

            var getMetadata = users.List().Fetch();
            Assert.That(getMetadata.Message, Is.Null);
            Assert.That(getMetadata.Success);
            Assert.That(getMetadata.Result.Count, Is.EqualTo(0));
        }
    }
}