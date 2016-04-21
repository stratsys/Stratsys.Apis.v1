using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.StratsysApps;

namespace Stratsys.Apis.v1.ExampleTests.Apis.StratsysApps
{
    public class ReportListServiceUT : BaseTest
    {
        [TestCase("reporting.list@users.se")]
        public void GetItemsForUser(string userId)
        {
            var reportLists = Api.Dashboards.List(userId, true).Fetch().Result[0].ReportLists;
            Assert.That(reportLists.Count, Is.EqualTo(1));

            var userReportItems = Api.ReportLists.GetItemsForUser(reportLists[0].Id, userId).Fetch().Result;
            Assert.That(userReportItems.Count, Is.EqualTo(3));
            var item = userReportItems[0];

            Assert.That(item.Name, Is.EqualTo("Aktivitetsrapport"));
            Assert.That(item.Url, Is.EqualTo("https://www.stratsys.se/PermaLink/ApiPublicTestsDev/Report.mvc/ForId/208?ChangeDepartment=16"));
            Assert.That(item.Deadline.Text, Is.EqualTo("Försenad " + item.Deadline.DaysDelayed + " dagar"));
            Assert.That(item.ReportPeriod, Is.EqualTo("2015"));

            Assert.That(item.DepartmentId, Is.EqualTo("16"));
            Assert.That(item.DepartmentName, Is.EqualTo("Administrativa avdelningen"));

            var progress = item.ReportProgress;
            Assert.That(progress.ShouldShowProgressReady, Is.EqualTo(true));
            Assert.That(progress.ShouldShowProgressFinished, Is.EqualTo(true));
            Assert.That(progress.PercentageFinished, Is.EqualTo(2.0d));
            Assert.That(progress.PercentageReady, Is.EqualTo(67.0d));
        }
    }
}