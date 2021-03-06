﻿using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Activities;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class ExampleFlow_GetReportingListForUserAndTickOffItems : BaseTest
    {
        [TestCase("reporting.list@users.se", "Aktiviteter - mitt uppföljningsansvar", "6")]
        public void Get_reporting_list_items_for_user_And_change_status_for_delayed_activity(
            string userId, string reportingListName, string newStatusId)
        {
            var reportingList = Api.ReportingLists.Filter(reportingListName).Fetch().Result.FirstOrDefault();

            var userReportingList = Api.ReportingLists.GetItemsForUser(reportingList.Id, userId).Fetch().Result;
            Assert.That(userReportingList.Nodes.Count, Is.EqualTo(1));

            //Delayed activity
            var reportingListNode = userReportingList.Nodes.FirstOrDefault();
            Assert.That(reportingListNode.Deadline.DaysDelayed, Is.GreaterThan(0));
            var oldStatusId = Api.Activities.GetStatus(reportingListNode.NodeId, reportingListNode.DepartmentId).Fetch().Result.Id;

            var updateStatusDto = new UpdateStatusDto
            {
                ActivityId = reportingListNode.NodeId,
                DepartmentId = reportingListNode.DepartmentId,
                UserId = userId,
                StatusId = newStatusId
            };

            //Update status to finished
            Api.Activities.SetStatus(updateStatusDto.ActivityId, updateStatusDto.StatusId).Fetch();

            userReportingList = Api.ReportingLists.GetItemsForUser(reportingList.Id, userId).Fetch().Result;
            Assert.That(userReportingList.Nodes.Count, Is.EqualTo(0));

            var status = Api.Activities.GetStatus(reportingListNode.NodeId, reportingListNode.DepartmentId).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(newStatusId));

            //Reset status
            updateStatusDto.StatusId = oldStatusId;
            Api.Activities.SetStatus(updateStatusDto.ActivityId, updateStatusDto.StatusId).Fetch();
            status = Api.Activities.GetStatus(reportingListNode.NodeId, reportingListNode.DepartmentId).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(oldStatusId));

            userReportingList = Api.ReportingLists.GetItemsForUser(reportingList.Id, userId).Fetch().Result;
            Assert.That(userReportingList.Nodes.Count, Is.EqualTo(1));
        }
    }
}