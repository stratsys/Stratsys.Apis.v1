using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.StratsysApps
{
    public class DashboardServiceUT : BaseTest
    {
        [TestCase("reporting.list@users.se", true, 1)]
        [TestCase("reporting.list@users.se", false, 10)]
        public void List(string userId, bool onlyStartpage, int expectedNrOfDashboards)
        {
            var dashboards = Api.Dashboards.List(userId, onlyStartpage).Fetch().Result;
            Assert.That(dashboards.Count, Is.EqualTo(expectedNrOfDashboards));
            var dashboardDto = dashboards[0];
            Assert.That(dashboardDto.Name, Is.EqualTo("Min startsida"));

            Assert.That(dashboardDto.ReportingLists.Count, Is.EqualTo(3));
            var reportingList = dashboardDto.ReportingLists[0];
            Assert.That(reportingList.Id, Is.EqualTo("3"));
            Assert.That(reportingList.Name, Is.EqualTo("Aktiviteter - mitt uppföljningsansvar"));
            Assert.That(reportingList.NodeType, Is.EqualTo("Activity"));

            Assert.That(dashboardDto.ReportLists.Count, Is.EqualTo(1));
            var reportList = dashboardDto.ReportLists[0];
            Assert.That(reportList.Name, Is.EqualTo("Rapporter"));
            Assert.That(reportList.Id, Is.EqualTo("103"));
        }
    }
}