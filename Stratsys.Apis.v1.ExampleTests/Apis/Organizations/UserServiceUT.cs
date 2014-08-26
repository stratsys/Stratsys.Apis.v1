using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class UserServiceUT : BaseTest
    {
        [TestCase(348)]
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

        [TestCase("johnsmith123", "password123", "john.smith@somedomain.com", "1", "1", "John", "Smith")]
        public void Insert_and_remove_user(string username, string password, string email,
            string departmentId, string groupId, string firstName, string lastName)
        {
            var newUser = new CreateUserDto
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                DepartmentId = departmentId,
                GroupId = groupId,
                Password = password,
                Username = username,
                PhoneMobile = "070-123 45 67",
                PhoneRegular = "+46 31 123 45 67"
            };
            // Guard if test fails half way
            var stratsysApiMetadata = Api.Users.Get(username).Fetch();
            if (stratsysApiMetadata.Success)
            {
                var b = Api.Users.Delete(username).Fetch();
            }
            var metadata = Api.Users.Create(newUser).Fetch();
            Assert.That(metadata.Message, Is.Null);
            Assert.That(metadata.Success);
            var id = metadata.Result;
            var metadata2 = Api.Users.Get(id).Fetch();
            Assert.That(metadata2.Message, Is.Null);
            Assert.That(metadata2.Success);
            var result = metadata2.Result;
            Assert.That(result.Username, Is.EqualTo(newUser.Username));
            Assert.That(result.Email, Is.EqualTo(newUser.Email));
            Assert.That(result.FirstName, Is.EqualTo(newUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(newUser.LastName));
            Assert.That(result.DepartmentId, Is.EqualTo(newUser.DepartmentId));
            Assert.That(result.GroupId, Is.EqualTo(newUser.GroupId));
            Assert.That(result.PhoneMobile, Is.EqualTo(newUser.PhoneMobile));
            Assert.That(result.PhoneRegular, Is.EqualTo(newUser.PhoneRegular));

            Api.Users.Delete(username).Fetch();
        }

        [TestCase("494", "user123", "user.123@somedomain.com", "1", "1", "User", "123")]
        public void Update_user(string id, string username, string email,
            string departmentId, string groupId, string firstName, string lastName)
        {
            var user = new UserDto
            {
                Id = id,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                DepartmentId = departmentId,
                GroupId = groupId,
                Username = username,
                PhoneMobile = "070-123 45 67",
                PhoneRegular = "+46 31 123 45 67"
            };
            var userId = Api.Users.Update(user).Fetch().Result;

            var result = Api.Users.Get(userId).Fetch().Result;
            Assert.That(result.Username, Is.EqualTo(user.Username));
            Assert.That(result.Email, Is.EqualTo(user.Email));
            Assert.That(result.FirstName, Is.EqualTo(user.FirstName));
            Assert.That(result.LastName, Is.EqualTo(user.LastName));
            Assert.That(result.DepartmentId, Is.EqualTo(user.DepartmentId));
            Assert.That(result.GroupId, Is.EqualTo(user.GroupId));
            Assert.That(result.PhoneMobile, Is.EqualTo(user.PhoneMobile));
            Assert.That(result.PhoneRegular, Is.EqualTo(user.PhoneRegular));
        }
    }
}