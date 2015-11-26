using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.StratsysApps
{
    public class ReportingListServiceUT : BaseTest
    {
        [TestCase(6)]
        public void List_reportingLists(int expectedNumberOfReportingLists)
        {
            var reportingLists = Api.ReportingLists.List().Fetch().Result;
            Assert.That(reportingLists.Count, Is.EqualTo(expectedNumberOfReportingLists));
        }

        [TestCase("mitt uppföljningsansvar", null, 6)]
        [TestCase("Mål - mitt uppföljningsansvar", NodeTypeDto.Goal, 1)]
        [TestCase(null, NodeTypeDto.Activity, 3)]
        [TestCase(null, NodeTypeDto.Kpi, 2)]
        [TestCase(null, NodeTypeDto.Goal, 1)]
        public void Filter_reportingLists(string name, NodeTypeDto? nodeType, int expectedNumberOfReportingLists)
        {
            var reportingLists = Api.ReportingLists.Filter(name, nodeType).Fetch().Result;
            Assert.That(reportingLists.Count, Is.EqualTo(expectedNumberOfReportingLists));
        }

        [TestCase("1", 3)]
        public void Filter_dashboardId(string dashboardId, int expectedNumberOfReportingLists)
        {
            var reportingLists = Api.ReportingLists.Filter(dashboardId: dashboardId).Fetch().Result;
            Assert.That(reportingLists.Count, Is.EqualTo(expectedNumberOfReportingLists));
        }

        [TestCase("Mål - mitt uppföljningsansvar ", "Goal", "5")]
        public void Filter_reportingLists_unique_result(string name, string expectedNodeType, string expectedId)
        {
            var reportingLists = Api.ReportingLists.Filter(name).Fetch().Result;
            Assert.That(reportingLists.Count, Is.EqualTo(1));
            var reportingList = reportingLists[0];

            Assert.That(reportingList.Name, Is.EqualTo(name));
            Assert.That(reportingList.Id, Is.EqualTo(expectedId));
            Assert.That(reportingList.NodeType, Is.EqualTo(expectedNodeType));
        }

        [TestCase("3", "reporting.list@users.se", false, 1)]
        [TestCase("3", "reporting.list@users.se", true, 5)]
        public void Get_detailed_activity_reporting_list_for_user_Depends_on_show_all(string reportTableFilterId, string userId, bool? showAll, int expectedNumberOfNodes)
        {
            var userReportingListItems = Api.ReportingLists.GetItemsForUser(reportTableFilterId, userId, showAll).Fetch().Result;
            Assert.That(userReportingListItems.ShowPeriod, Is.EqualTo(false));
            Assert.That(userReportingListItems.ShowScorecardName, Is.EqualTo(true));
            Assert.That(userReportingListItems.ShowAll, Is.EqualTo(showAll));

            var reportingListNodes = userReportingListItems.Nodes;
            Assert.That(reportingListNodes.Count, Is.EqualTo(expectedNumberOfNodes));
        }

        [TestCase("3", "reporting.list@users.se")]
        public void Get_user(string reportTableFilterId, string userId)
        {
            var user = Api.Users.Get(userId).Fetch().Result;
            Assert.That(user.Username, Is.EqualTo("InLi1001"));
        }

        [TestCase("3", "reporting.list@users.se")]
        public void Get_detailed_reporting_list_for_user_Activity_is_delayed(string reportTableFilterId, string userId)
        {
            var userReportingListItems = Api.ReportingLists.GetItemsForUser(reportTableFilterId, userId, false).Fetch().Result;

            var reportingListNodes = userReportingListItems.Nodes;
            Assert.That(reportingListNodes.Count, Is.EqualTo(1));
            var reportingListNode = reportingListNodes[0];

            Assert.That(reportingListNode.NodeType, Is.EqualTo(NodeTypeDto.Activity + ""));
            Assert.That(reportingListNode.DepartmentId, Is.EqualTo("16"));
            Assert.That(reportingListNode.DepartmentName, Is.EqualTo("Administrativa avdelningen"));
            Assert.That(reportingListNode.NodeId, Is.EqualTo("7595"));
            Assert.That(reportingListNode.NodeName, Is.EqualTo("Återkoppling på ledningsgrupp per tertial"));
            Assert.That(reportingListNode.ScorecardId, Is.EqualTo("1"));
            Assert.That(reportingListNode.ScorecardName, Is.EqualTo("Verksamhetsplan"));
            Assert.That(reportingListNode.ImageTooltip, Is.EqualTo("Försenad"));
            Assert.That(reportingListNode.ImageUrl, Is.StringEnding("Images/NodeColors/delayed.png"));
            Assert.That(reportingListNode.PeriodName, Is.EqualTo("Delår 2 2015"));

            var actionModel = reportingListNode.Action;
            Assert.That(actionModel.CssClass, Is.EqualTo("reportNode"));
            Assert.That(actionModel.Text, Is.EqualTo("Slutuppfölj, Kommentera"));

            var deadlineModel = reportingListNode.Deadline;
            Assert.That(deadlineModel.CssClass, Is.EqualTo("deadlineOverdue"));
            Assert.That(deadlineModel.Text, Is.EqualTo("Försenad " + deadlineModel.DaysDelayed + " dagar"));
        }

        [TestCase("4", "reporting.list@users.se")]
        public void Get_detailed_reporting_list_for_user_Kpi_is_not_delayed(string reportTableFilterId, string userId)
        {
            var userReportingListItems = Api.ReportingLists.GetItemsForUser(reportTableFilterId, userId, true).Fetch().Result;

            var reportingListNodes = userReportingListItems.Nodes;
            Assert.That(reportingListNodes.Count, Is.EqualTo(6));
            var reportingListNode = reportingListNodes[5];

            Assert.That(reportingListNode.NodeType, Is.EqualTo(NodeTypeDto.Kpi + ""));
            Assert.That(reportingListNode.DepartmentId, Is.EqualTo("16"));
            Assert.That(reportingListNode.DepartmentName, Is.EqualTo("Administrativa avdelningen"));
            Assert.That(reportingListNode.NodeId, Is.EqualTo("7591"));
            Assert.That(reportingListNode.NodeName, Is.EqualTo("Nöjd uppdragsgivarindex"));
            Assert.That(reportingListNode.ScorecardId, Is.EqualTo("1"));
            Assert.That(reportingListNode.ScorecardName, Is.EqualTo("Verksamhetsplan"));
            Assert.That(reportingListNode.PeriodName, Is.EqualTo("2014"));
            Assert.That(reportingListNode.ImageUrl, Is.Null);
            Assert.That(reportingListNode.ImageTooltip, Is.Null);

            var actionModel = reportingListNode.Action;
            Assert.That(actionModel.CssClass, Is.EqualTo("showNode"));
            Assert.That(actionModel.Text, Is.EqualTo("Visa"));

            var deadlineModel = reportingListNode.Deadline;
            Assert.That(deadlineModel.CssClass, Is.EqualTo("deadlineDefault"));
            Assert.That(deadlineModel.DaysDelayed, Is.LessThan(0));
            Assert.That(deadlineModel.Text, Is.EqualTo("2014-12-31"));
        }

    }
}