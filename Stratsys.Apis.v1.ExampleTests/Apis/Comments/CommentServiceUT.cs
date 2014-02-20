using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Comments.Resources;
using Stratsys.Apis.v1.Apis.Comments.Services;
using Stratsys.Apis.v1.Dtos.Comments;

namespace Stratsys.Apis.v1.Tests.Apis.Comments
{
    public class CommentServiceUT : BaseTest
    {

        [TestCase("Arbetskraftens storlek 16-64 år", "1", 2)]
        [TestCase("Arbetskraftens storlek 16-64 år", null, 3)]
        public void Get_comments_for_kpi(
            string nameFilter, string departmentFilter, int expectedNumberOfComments)
        {
            var kpis = Api.Kpis.Filter(null, "1", nameFilter).Fetch().Result;
            Assert.That(kpis.Count, Is.EqualTo(1));

            var kpi = kpis[0];

            var comments = Api.Comments.Filter(kpi.Id, departmentFilter).Fetch().Result;
            Assert.That(comments.Count, Is.EqualTo(expectedNumberOfComments));
        }

        [TestCase("4", "1", 4)]
        [TestCase("4", "5", 5)]
        public void Get_comments_for_visible_node(
            string idFilter, string departmentFilter, int expectedNumberOfComments)
        {
            var comments = Api.Comments.Filter(idFilter, departmentFilter).Fetch().Result;
            Assert.That(comments.Count, Is.EqualTo(expectedNumberOfComments));
        }

        [TestCase("3", "5", "19")]
        public void Add_comment_Should_get_created_id(string nodeId, string departmentId, string userId)
        {
            var comment = new AddCommentDto
                {
                    DepartmentId = departmentId,
                    NodeId = nodeId,
                    UserId = userId,
                    Text = "<b>Bold comment</b>"
                };
            var id = Api.Comments.AddComment(comment).Fetch().Result;
            Assert.That(id, Is.Not.Null.Or.Empty);
        }

        [TestCase("1916", "<b>Bold comment</b>", "2014-01-01", "2014-02-20 18:15:41", "19", "5")]
        public void Get_comment_Should_get_comment(string id,
            string expectedText, string expectedDate, string expectedPostedDate,
            string expectedUserId, string expectedDepartmentId)
        {
            var comment = Api.Comments.Get(id).Fetch().Result;
            Assert.That(comment.Text, Is.EqualTo(expectedText));
            Assert.That(comment.PeriodDate, Is.EqualTo(expectedDate));
            Assert.That(comment.PostedDate, Is.EqualTo(expectedPostedDate));
            Assert.That(comment.LastUpdatedDate, Is.EqualTo(expectedPostedDate));
            Assert.That(comment.UserId, Is.EqualTo(expectedUserId));
            Assert.That(comment.DepartmentId, Is.EqualTo(expectedDepartmentId));
        }

        [TestCase("1915", "<b>Bold comment. Changed</b>", "18", "2014-01-01", "2014-02-20 18:02:42", "5")]
        public void Update_comment_Should_update_comment(
            string id, string text, string userId,
            string expectedDate, string expectedPostedDate, string expectedDepartmentId)
        {
            var updateCommentDto = new UpdateCommentDto
            {
                Id = id,
                Text = text,
                UserId = userId
            };
            var commentId = Api.Comments.Update(updateCommentDto).Fetch().Result;

            Assert.That(commentId, Is.EqualTo(id));
            var comment = Api.Comments.Get(commentId).Fetch().Result;
            Assert.That(comment.Text, Is.EqualTo(text));
            Assert.That(comment.PeriodDate, Is.EqualTo(expectedDate));
            Assert.That(comment.PostedDate, Is.EqualTo(expectedPostedDate));
            Assert.That(comment.LastUpdatedDate, Is.StringStarting(DateTime.Today.ToShortDateString()));
            Assert.That(comment.UserId, Is.EqualTo(userId));
            Assert.That(comment.DepartmentId, Is.EqualTo(expectedDepartmentId));
        }

    }
}