using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class NodeServiceUT : BaseTest
    {
        [TestCase("1", 1007)]
        public void When_filtering_by_scorecard_Should_get_filtered_nodes(string scorecardId, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(scorecardId: scorecardId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("activity", 592)]
        public void When_filtering_on_activities_Should_get_filtered_nodes(string nodeTypeFilter, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(nodeTypeFilter).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("kpi", 1861)]
        public void When_filtering_on_kpis_Should_get_filtered_nodes(string nodeTypeFilter, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(nodeTypeFilter).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("text", 643)]
        public void When_filtering_on_textnodes_Should_get_filtered_nodes(string nodeTypeFilter, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(nodeTypeFilter).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("ta fram en arbetsgrupp", 2)]
        public void When_filtering_by_name_Should_get_filtered_nodes(string nameFilter, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(name: nameFilter).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("5", 73)]
        public void When_filtering_by_departmentId_Should_get_filtered_nodes(string departmentId, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(departmentId: departmentId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("21513", 2)]
        public void When_filtering_by_id_Should_get_filtered_nodes(string id, int expectedNumberOfNodes)
        {
            var nodes = Api.Nodes.Filter(id: id).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("ta fram en arbetsgrupp", "5", @"Ta fram en arbetsgrupp för att inrätta ""Lilla miljöpriset""", "Activity", "21513")]
        public void When_filtering_on_unique_node_Should_get_filtered_node(
            string nameFilter, string departmentId,
            string expectedName, string expectedNodeType, string expectedId)
        {
            var nodes = Api.Nodes.Filter(name: nameFilter, departmentId: departmentId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(1));
            var node = nodes[0];
            Assert.That(node.Name, Is.EqualTo(expectedName));
            Assert.That(node.NodeType, Is.EqualTo(expectedNodeType));
            Assert.That(node.Id, Is.EqualTo(expectedId));
            Assert.That(node.DepartmentId, Is.EqualTo(departmentId));
        }
    }
}