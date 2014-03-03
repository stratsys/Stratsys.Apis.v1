using NUnit.Framework;
using Stratsys.Apis.v1.Tests;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class UserServiceUT : BaseTest
    {
        [TestCase(349)]
        public void Get_all_users(int expectedCount)
        {
            var users = Api.Users.List().Fetch().Result;
            Assert.That(users.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("ludant", 1)]
        [TestCase("ludvig", 1)]
        [TestCase("antonsson", 1)]
        [TestCase("ludvig antonsson", 1)]
        [TestCase("bengtsson", 5)]
        public void Get_user_by_name(string nameFilter, int expectedCount)
        {
            var users = Api.Users.Filter(name: nameFilter).Fetch().Result;
            Assert.That(users.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("98", "98", "ludant", "no@thanks.com")]
        [TestCase("ludant", "98", "ludant", "no@thanks.com")]
        [TestCase("no@thanks.com", "98", "ludant", "no@thanks.com")]
        public void Get_user_by_multiple_different_ids(string id, 
            string expectedId, string expectedUsername, string expectedEmail)
        {
            var user = Api.Users.Get(id).Fetch().Result;
            Assert.That(user.Id, Is.EqualTo(expectedId));
            Assert.That(user.Username, Is.EqualTo(expectedUsername));
            Assert.That(user.Email, Is.EqualTo(expectedEmail));
        }

        [TestCase("no@thanks.com", "98", "Ludvig", "Antonsson", "ludant")]
        [TestCase("no@mail.com", null, null, null, null)]
        public void Get_user_by_email(string emailFilter, 
            string expectedId, string expectedFirstName, string expectedLastName, string expectedUsername)
        {
            var users = Api.Users.Filter(emailFilter).Fetch().Result;
            if (expectedId != null)
            {
                var user = users[0];
                Assert.That(user.Id, Is.EqualTo(expectedId));
                Assert.That(user.FirstName, Is.EqualTo(expectedFirstName));
                Assert.That(user.LastName, Is.EqualTo(expectedLastName));
                Assert.That(user.Username, Is.EqualTo(expectedUsername));
                Assert.That(user.Email, Is.EqualTo(emailFilter));
            }
            else
            {
                Assert.That(users.Count, Is.EqualTo(0));
            }
        }
    }
}