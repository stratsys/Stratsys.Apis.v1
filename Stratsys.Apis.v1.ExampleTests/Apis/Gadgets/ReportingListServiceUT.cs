using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Gadgets
{
    public class ReportingListServiceUT : BaseTest
    {
        [TestCase(10)]
        public void List_reportingLists(int expectedNumberOfReportingLists)
        {
            var reportingLists = Api.ReportingLists.List().Fetch().Result;
            Assert.That(reportingLists.Count, Is.EqualTo(expectedNumberOfReportingLists));
        }

        [TestCase("2", "sa", false, 5)]
        [TestCase("2", "sa", true, 6)]
        [TestCase("2", "sa", null, 6)]
        public void Get_detailed_reporting_list_for_user(string reportTableFilterId, string userId, bool? showAll, int expectedNumberOfNodes)
        {
            var userReportingListItems = Api.ReportingLists.GetItemsForUser(reportTableFilterId, userId, showAll).Fetch().Result;

            var reportingListNodes = userReportingListItems.Nodes;
            Assert.That(reportingListNodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }
    }
}