using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class ScorecardColumnServiceUT : BaseTest
    {
        [TestCase("2", "Områden", "Områdena ska vara vägledande vid fastställande av mål", "Goal", "1")]
        public void Get(string id,
            string expectedName,
            string expectedDefinition,
            string expectedNodeType,
            string expectedScorecardId
            )
        {
            var column = Api.ScorecardColumns.Get(id).Fetch().Result;

            Assert.That(column.Id, Is.EqualTo(id));
            Assert.That(column.Name, Is.EqualTo(expectedName));
            Assert.That(column.Index, Is.EqualTo(1));
            Assert.That(column.Definition, Is.EqualTo(expectedDefinition));
            Assert.That(column.NodeType, Is.EqualTo(expectedNodeType));
            Assert.That(column.ScorecardId, Is.EqualTo(expectedScorecardId));
        }

        [TestCase(96)]
        public void Get_all_columns(int expectedCount)
        {
            var scorecardColumns = Api.ScorecardColumns.Filter().Fetch().Result;
            Assert.That(scorecardColumns.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", 9)]
        public void Filter_by_scorecardId(string scorecardId, int expectedCount)
        {
            var scorecardColumns = Api.ScorecardColumns.Filter(scorecardId).Fetch().Result;
            Assert.That(scorecardColumns.Count, Is.EqualTo(expectedCount));

            var visionColumn = scorecardColumns[0];
            Assert.That(visionColumn.Index, Is.EqualTo(0));
            Assert.That(visionColumn.Name, Is.EqualTo("Vision"));
        }

        [TestCase("område", 11)]
        [TestCase("områden", 4)]
        public void Filter_by_name(string name, int expectedCount)
        {
            var scorecardColumns = Api.ScorecardColumns.Filter(name: name).Fetch().Result;
            Assert.That(scorecardColumns.Count, Is.EqualTo(expectedCount));
        }

        [TestCase(0, 19)]
        [TestCase(7, 2)]
        public void Filter_by_index(int index, int expectedCount)
        {
            var scorecardColumns = Api.ScorecardColumns.Filter(index: index).Fetch().Result;
            Assert.That(scorecardColumns.Count, Is.EqualTo(expectedCount));
        }

        [TestCase(NodeTypeDto.Goal, 58)]
        [TestCase(NodeTypeDto.Activity, 19)]
        public void Filter_by_nodeType(NodeTypeDto nodeType, int expectedCount)
        {
            var scorecardColumns = Api.ScorecardColumns.Filter(nodeType: nodeType).Fetch().Result;
            Assert.That(scorecardColumns.Count, Is.EqualTo(expectedCount));
        }
    }
}