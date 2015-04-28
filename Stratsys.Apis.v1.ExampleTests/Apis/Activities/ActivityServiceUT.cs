using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Activities;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class ActivityServiceUT : BaseTest
    {
        [TestCase("1", 98)]
        public void Filter_ScorecardId(string scorecardId, int expectedNumberOfActivities)
        {
            var filterActivitiesRequest = Api.Activities.Filter(scorecardId: scorecardId);
            var activities = filterActivitiesRequest.Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase(true, 3)]
        public void Filter_SimpleOnly(bool simpleOnly, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(onlySimple: simpleOnly).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase(true, 597)]
        public void Filter_ExcludeFinished(bool excludeFinished, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(excludeFinished: excludeFinished).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("190", 1)]
        public void Filter_UserId(string userId, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(userId: userId, excludeFinished: true).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("Återkoppling på ledningsgrupp per tertial", 1)]
        public void When_filtering_by_name_Should_get_filtered_activities(string nameFilter, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(name: nameFilter).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("5", 9)]
        public void When_filtering_by_departmentId_Should_get_filtered_activities(string departmentId, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(departmentId: departmentId).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("3", 150)]
        public void When_filtering_by_statusId_Should_get_filtered_activities(string statusId, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(statusId: statusId).Fetch().Result;
            Assert.That(activities.Count, Is.GreaterThan(expectedNumberOfActivities));
            foreach (var activity in activities)
            {
                Assert.That(activity.StatusId, Is.EqualTo(statusId));
            }
        }

        [TestCase("21513", 2)]
        public void When_filtering_by_id_Should_get_filtered_activities(string id, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(id).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("ta fram en arbetsgrupp", "5", @"Ta fram en arbetsgrupp för att inrätta ""Lilla miljöpriset""", "3", "21513", "2015-05-14")]
        public void When_filtering_on_unique_activity_Should_get_filtered_activity(
            string nameFilter, string departmentId,
            string expectedName, string expectedStatusId, string expectedId, string expectedEndDate)
        {
            var nodes = Api.Activities.Filter(name: nameFilter, departmentId: departmentId, fields: "scorecardColumns").Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(1));
            var activity = nodes[0];
            Assert.That(activity.Name, Is.EqualTo(expectedName));
            Assert.That(activity.Id, Is.EqualTo(expectedId));
            Assert.That(activity.DepartmentId, Is.EqualTo(departmentId));
            Assert.That(activity.StatusId, Is.EqualTo(expectedStatusId));
            Assert.That(activity.EndDate, Is.EqualTo(expectedEndDate));
        }

        [TestCase("631354", "6")]
        public void Update_status(string activityId, string statusId)
        {
            var activities = Api.Activities;
            var activity = activities.Filter(activityId).Fetch().Result.FirstOrDefault();
            Assert.That(activity, Is.Not.Null);
            var oldStatusId = activity.StatusId;

            var result = activities.SetStatus(activityId, statusId).Fetch().Result;
            Assert.That(result, Is.EqualTo(statusId));

            //reset
            result = activities.SetStatus(activityId, oldStatusId).Fetch().Result;
            Assert.That(result, Is.EqualTo(oldStatusId));
        }

        [TestCase("21513", "5", "3")]
        public void Get_status(string activityId, string departmentId, string expectedStatusId)
        {
            var status = Api.Activities.GetStatus(activityId, departmentId).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(expectedStatusId));
        }


        [TestCase("631654", "2015-12-31")]
        public void Update_endDate(string activityId, string endDate)
        {
            var activities = Api.Activities;
            var activity = activities.Filter(activityId).Fetch().Result.FirstOrDefault();
            Assert.That(activity, Is.Not.Null);
            var oldEndDate = activity.EndDate;

            var result = activities.SetEndDate(activityId, endDate).Fetch().Result;
            Assert.That(result, Is.EqualTo(endDate));

            //reset
            result = activities.SetEndDate(activityId, oldEndDate).Fetch().Result;
            Assert.That(result, Is.EqualTo(oldEndDate));
        }
    }
}