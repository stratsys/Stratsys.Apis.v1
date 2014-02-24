using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class StatusServiceUT : BaseTest
    {
        [TestCase(3)]
        public void Get_all_statuses(int expectedCount)
        {
            var statuses = Api.Statuses.List().Fetch().Result;
            Assert.That(statuses.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("3", "Pågående ", "Images/NodeColors/inprogress.png", 3)]
        public void Get_status(string id, string expectedName, string expectedEndingIconUrl, int expectedSortOrder)
        {
            var status = Api.Statuses.Get(id).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(id));
            Assert.That(status.IconUrl, Is.StringEnding(expectedEndingIconUrl));
            Assert.That(status.Name, Is.EqualTo(expectedName));
            Assert.That(status.SortOrder, Is.EqualTo(expectedSortOrder));
        }
    }
}