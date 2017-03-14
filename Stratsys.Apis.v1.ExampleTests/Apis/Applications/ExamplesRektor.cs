using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Applications
{
    public class ExamplesRektor : BaseTest
    {
        [Test]
        public void List_rektor_roles()
        {
            var metadata = new StratsysApi(ServiceAuthentication)
                .ResourcePlanning
                .Roles
                .List()
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result.ToList();

            Assert.That(list.Count, Is.EqualTo(5));
        }

        [Test]
        public void List_me_rektor_roles()
        {
            var metadata = new StratsysApi(BearerAuthentication)
                .ResourcePlanning
                .Me
                .Roles
                .List(departmentId:"2")
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result.ToList();

            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo("Admin"));
        }

        [Test]
        public void Filter_me_rektor_roles()
        {
            var metadata = new StratsysApi(BearerAuthentication)
                .ResourcePlanning
                .Me
                .Roles
                .Filter(departmentId:"2")
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result.ToList();

            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo("Admin"));
        }

        [Test]
        public void List_rektor_departments()
        {
            var metadata = new StratsysApi(ServiceAuthentication)
                .ResourcePlanning
                .Departments
                .List()
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result.ToList();

            Assert.That(list.Count, Is.EqualTo(3));


            Assert.That(string.Join(",", list.Select(d => d.Id)), Is.EqualTo("2,5,6"));
        }

        [Test]
        public void Get_rektor_department()
        {
            var metadata = new StratsysApi(ServiceAuthentication)
                .ResourcePlanning
                .Departments
                .Get("2")
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result;

            Assert.That(list.Id, Is.EqualTo("2"));
        }

        [Test]
        public void List_me_rektor_departments()
        {
            var metadata = new StratsysApi(BearerAuthentication)
                .ResourcePlanning
                .Me
                .Departments
                .List()
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result.ToList();

            Assert.That(list.Count, Is.EqualTo(3));


            Assert.That(string.Join(",", list.Select(d => d.Id)), Is.EqualTo("2,5,6"));
        }

        [Test]
        public void Get_me_rektor_department()
        {
            var metadata = new StratsysApi(BearerAuthentication)
                .ResourcePlanning
                .Me
                .Departments
                .Get("2")
                .Fetch();

            Assert.That(metadata.Success, metadata.Message);

            var list = metadata.Result;

            Assert.That(list.Id, Is.EqualTo("2"));
        }
    }
}