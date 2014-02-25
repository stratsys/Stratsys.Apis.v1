using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class ExampleFlow_GetReportingListForUserAndTickOffItems : BaseTest
    {
        [TestCase("sa", 5, "2")]
        public void Get_reporting_list_items_for_user_And_change_status_or_comment(string userId, int numberOfExpectedItems, string newStatusId)
        {
            var reportingLists = Api.ReportingLists.List().Fetch().Result;
            var reportingList = reportingLists.Single(l => l.NodeType == NodeTypeDto.Activity && l.Name.Contains("Mina aktuella åtgärder") && l.Id == "2");

            var userReportingList = Api.ReportingLists.GetItemsForUser(reportingList.Id, userId).Fetch().Result;
            Assert.That(userReportingList.Nodes.Count, Is.EqualTo(5));

            var reportingListNode = userReportingList.Nodes.Single(n => n.NodeName == "Köp mer ost!");
            var updateStatusDto = new UpdateStatusDto
            {
                ActivityId = reportingListNode.NodeId,
                DepartmentId = reportingListNode.DepartmentId,
                UserId = userId,
                StatusId = newStatusId
            };
            Api.Activities.UpdateStatus(updateStatusDto).Fetch();

            userReportingList = Api.ReportingLists.GetItemsForUser(reportingList.Id, userId, false).Fetch().Result;
            Assert.That(userReportingList.Nodes.Count, Is.LessThan(5));

            var status = Api.Activities.GetStatus(reportingListNode.NodeId, reportingListNode.DepartmentId).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(newStatusId));
        }
    }
}