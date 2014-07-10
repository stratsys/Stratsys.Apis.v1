using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class GoalServiceUT : BaseTest
    {
        [TestCase("1", 310)]
        public void When_filtering_by_scorecard_Should_get_filtered_goals(string scorecardId, int expectedNumberOfGoals)
        {
            var goals = Api.Goals.Filter(scorecardId: scorecardId).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(expectedNumberOfGoals));
        }

        [TestCase("medborgare & brukare", 1)]
        public void When_filtering_by_name_Should_get_filtered_nodes(string nameFilter, int expectedNumberOfGoals)
        {
            var goals = Api.Goals.Filter(name: nameFilter).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(expectedNumberOfGoals));
        }

        [TestCase("5", 153)]
        public void When_filtering_by_departmentId_Should_get_filtered_goals(string departmentId, int expectedNumberOfGoals)
        {
            var goals = Api.Goals.Filter(departmentId: departmentId).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(expectedNumberOfGoals));
        }

        [TestCase("2", 4)]
        public void When_filtering_by_columnId_Should_get_filtered_goals(string columnId, int expectedNumberOfGoals)
        {
            var goals = Api.Goals.Filter(columnId: columnId).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(4));
        }

        [TestCase("4")]
        public void When_filtering_by_id_Should_get_filtered_goal(string id)
        {
            var goals = Api.Goals.Filter(id).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(1));
        }

        [TestCase("4", "1", "1")]
        [TestCase("4", "5", "1")]
        [TestCase("4", "75", "1")]
        public void When_filtering_by_id_and_department_Should_get_filtered_visible_node(string id, string departmentId, string mainDepartmentId)
        {
            var goals = Api.Goals.Filter(id).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(1));
            var goal = goals[0];
            Assert.That(goal.Id, Is.EqualTo(id));
            Assert.That(goal.DepartmentId, Is.EqualTo(mainDepartmentId));
        }

        [TestCase("medborgare & brukare", "5", "MEDBORGARE & BRUKARE", "4", "1")]
        public void When_filtering_on_unique_goal_Should_get_filtered_goal(
            string nameFilter, string departmentId,
            string expectedName, string expectedId, string expectedDepartmentId)
        {
            var goals = Api.Goals.Filter(name: nameFilter, departmentId: departmentId).Fetch().Result;
            Assert.That(goals.Count, Is.EqualTo(1));
            var goal = goals[0];
            Assert.That(goal.Name, Is.EqualTo(expectedName));
            Assert.That(goal.Id, Is.EqualTo(expectedId));
            Assert.That(goal.DepartmentId, Is.EqualTo(expectedDepartmentId));
        }

        [TestCase("5", "160", "619736", "159")]
        public void When_creating_new_goal_Should_get_id(string departmentId, string columnId, string parentNodeId, string parentColumnId)
        {
            var name = Guid.NewGuid() + "";
            var createGoalDto = new CreateGoalDto
            {
                ColumnId = columnId,
                DepartmentId = departmentId,
                Name = name,
                ParentColumnId = parentColumnId,
                ParentNodeId = parentNodeId
            };
            var goalId = Api.Goals.Create(createGoalDto).Fetch().Result;
            Assert.That(goalId, Is.Not.Null);

            var goal = Api.Goals.Filter(goalId).Fetch().Result[0];
            Assert.That(goal.Id, Is.EqualTo(goalId));
            Assert.That(goal.DepartmentId, Is.EqualTo(departmentId));
            Assert.That(goal.Name, Is.EqualTo(name));
        }
    }
}