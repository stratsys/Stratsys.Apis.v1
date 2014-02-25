using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Activities;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Activities
{
    public class ActivityServiceUT : BaseTest
    {
        [TestCase("1", 98)]
        public void When_filtering_by_scorecard_Should_get_filtered_activities(string scorecardId, int expectedNumberOfActivities)
        {
            var filterActivitiesRequest = Api.Activities.Filter(scorecardId: scorecardId);
            var activities = filterActivitiesRequest.Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("ta fram en arbetsgrupp", 2)]
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

        [TestCase("3", 164)]
        public void When_filtering_by_statusId_Should_get_filtered_activities(string statusId, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(statusId: statusId).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("21513", 2)]
        public void When_filtering_by_id_Should_get_filtered_activities(string id, int expectedNumberOfActivities)
        {
            var activities = Api.Activities.Filter(id).Fetch().Result;
            Assert.That(activities.Count, Is.EqualTo(expectedNumberOfActivities));
        }

        [TestCase("ta fram en arbetsgrupp", "5", @"Ta fram en arbetsgrupp för att inrätta ""Lilla miljöpriset""", "3", "21513")]
        public void When_filtering_on_unique_activity_Should_get_filtered_activity(
            string nameFilter, string departmentId,
            string expectedName, string expectedStatusId, string expectedId)
        {
            var nodes = Api.Activities.Filter(name: nameFilter, departmentId: departmentId).Fetch().Result;
            Assert.That(nodes.Count, Is.EqualTo(1));
            var activity = nodes[0];
            Assert.That(activity.Name, Is.EqualTo(expectedName));
            Assert.That(activity.Id, Is.EqualTo(expectedId));
            Assert.That(activity.DepartmentId, Is.EqualTo(departmentId));
            Assert.That(activity.StatusId, Is.EqualTo(expectedStatusId));
        }

        [TestCase("sa", "1", "20707", "4")]
        public void Update_status(string userId, string departmentId, string activityId, string statusId)
        {
            var updateStatus = new UpdateStatusDto
            {
                ActivityId = activityId,
                DepartmentId = departmentId,
                UserId = userId,
                StatusId = statusId
            };

            var result = Api.Activities.UpdateStatus(updateStatus).Fetch().Result;
            Assert.That(result, Is.EqualTo(statusId));
        }

        [TestCase("20707", "1", "4")]
        public void Get_status(string activityId, string departmentId, string expectedStatusId)
        {
            var status = Api.Activities.GetStatus(activityId, departmentId).Fetch().Result;
            Assert.That(status.Id, Is.EqualTo(expectedStatusId));
        }
    }
}