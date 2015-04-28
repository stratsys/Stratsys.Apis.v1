using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class StatusServiceUT : BaseTest
    {
        [TestCase("200", 3)]
        public void Get_statuses(string scorecardColumnId, int expectedCount)
        {
            var statuses = Api.Statuses.List(scorecardColumnId).Fetch().Result;
            Assert.That(statuses.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", "Ej påbörjad", "Images/NodeColors/halted.png", 1)]
        [TestCase("3", "Pågående", "Images/NodeColors/inprogress.png", 3)]
        [TestCase("6", "Avslutad", "Images/NodeColors/finished.png", 6)]
        public void Get_status(string id, string expectedName, string expectedEndingIconUrl, int expectedSortOrder)
        {
            var status = Api.Statuses.Get(id).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(id));
            Assert.That(status.Name, Is.EqualTo(expectedName));
            Assert.That(status.IconUrl, Is.StringEnding(expectedEndingIconUrl));
            Assert.That(status.SortOrder, Is.EqualTo(expectedSortOrder));
        }
    }
}