using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class TextNodeServiceUT : BaseTest
    {
        [TestCase("1", 310)]
        public void When_filtering_by_scorecard_Should_get_filtered_nodes(string scorecardId, int expectedNumberOfNodes)
        {
            var nodes = Api.TextNodes.Filter(scorecardId: scorecardId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("medborgare & brukare", 1)]
        public void When_filtering_by_name_Should_get_filtered_nodes(string nameFilter, int expectedNumberOfNodes)
        {
            var nodes = Api.TextNodes.Filter(name: nameFilter).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("5", 153)]
        public void When_filtering_by_departmentId_Should_get_filtered_nodes(string departmentId, int expectedNumberOfNodes)
        {
            var nodes = Api.TextNodes.Filter(departmentId: departmentId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("4")]
        public void When_filtering_by_id_Should_get_filtered_node(string id)
        {
            var nodes = Api.TextNodes.Filter(id).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(1));
        }

        [TestCase("4", "1", "1")]
        [TestCase("4", "5", "1")]
        [TestCase("4", "75", "1")]
        public void When_filtering_by_id_and_department_Should_get_filtered_visible_node(string id, string departmentId, string mainDepartmentId)
        {
            var nodes = Api.TextNodes.Filter(id).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(1));
            var textNode = nodes[0];
            Assert.That(textNode.Id, Is.EqualTo(id));
            Assert.That(textNode.DepartmentId, Is.EqualTo(mainDepartmentId));
        }

        [TestCase("medborgare & brukare", "5", "MEDBORGARE & BRUKARE", "4", "1")]
        public void When_filtering_on_unique_node_Should_get_filtered_node(
            string nameFilter, string departmentId,
            string expectedName, string expectedId, string expectedDepartmentId)
        {
            var nodes = Api.TextNodes.Filter(name: nameFilter, departmentId: departmentId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(1));
            var node = nodes[0];
            Assert.That(node.Name, Is.EqualTo(expectedName));
            Assert.That(node.Id, Is.EqualTo(expectedId));
            Assert.That(node.DepartmentId, Is.EqualTo(expectedDepartmentId));
        }
    }
}