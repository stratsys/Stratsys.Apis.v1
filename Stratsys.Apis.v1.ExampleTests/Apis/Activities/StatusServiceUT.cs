using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class StatusServiceUT : BaseTest
    {
        [TestCase("200", 4)]
        [TestCase(null, 3)]
        public void Get_statuses(string scorecardColumnId, int expectedCount)
        {
            var statuses = Api.Statuses.Filter(scorecardColumnId).Fetch().Result;
            Assert.That(statuses.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", "Ej påbörjad", "Paused", "IconRenderer.mvc/FontAwesome?iconNames=fa-pause-circle&color=F1C40F&isStatusIcon=true&imageSize=18", 1)]
        [TestCase("3", "Pågående", "Ongoing", "IconRenderer.mvc/FontAwesome?iconNames=fa-play-circle&color=27AE60&isStatusIcon=true&imageSize=18", 3)]
        [TestCase("6", "Avslutad", "Finished", "IconRenderer.mvc/FontAwesome?iconNames=fa-check&color=27AE60&isStatusIcon=true&imageSize=18", 6)]
        public void Get_status(string id, string expectedName, string expectedStatusType, string expectedEndingIconUrl, int expectedSortOrder)
        {
            var status = Api.Statuses.Get(id).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(id));
            Assert.That(status.Name, Is.EqualTo(expectedName));
            Assert.That(status.StatusType, Is.EqualTo(expectedStatusType));
            Assert.That(status.IconUrl, Is.StringEnding(expectedEndingIconUrl));
            Assert.That(status.SortOrder, Is.EqualTo(expectedSortOrder));
        }
    }
}