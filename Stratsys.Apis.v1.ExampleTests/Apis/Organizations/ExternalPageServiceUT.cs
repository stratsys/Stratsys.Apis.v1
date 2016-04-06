using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class ExternalPageServiceUT : BaseTest
    {
        [Test]
        public void List()
        {
            var externalPages = Api.ExternalPages
                .List().Fetch().Result;
            Assert.That(externalPages.Count, Is.GreaterThan(0));
             
            var externalPage = externalPages[0];
            Assert.That(externalPage.Id, Is.EqualTo("1"));
            Assert.That(externalPage.Name, Is.EqualTo("Ekonomi/Personal"));
            Assert.That(externalPage.Url, Is.EqualTo("http://ekonomi.com"));
        }

        [TestCase("1")]
        public void Get(string id)
        {
            var externalPage = Api.ExternalPages
                .Get(id).Fetch().Result;

            Assert.That(externalPage.Id, Is.EqualTo("1"));
            Assert.That(externalPage.Name, Is.EqualTo("Ekonomi/Personal"));
            Assert.That(externalPage.Url, Is.EqualTo("http://ekonomi.com"));
        }

        [TestCase("My site", "https://www.mysite.com")]
        public void Create(string name, string url)
        {
            var dto = new CreateExternalPageDto
            {
                Name = name,
                Url = url
            };

            var externalPageId = Api.ExternalPages
                .Create(dto).Fetch().Result;

            var externalPage = Api.ExternalPages
                .Get(externalPageId).Fetch().Result;

            Assert.That(externalPage.Id, Is.EqualTo(externalPageId));
            Assert.That(externalPage.Name, Is.EqualTo(name));
            Assert.That(externalPage.Url, Is.EqualTo(url));
        }

        [Test]
        public void Delete()
        {
            var dto = new CreateExternalPageDto
            {
                Name = "My site",
                Url = "https://www.mysite.com"
            };

            var externalPageId = Api.ExternalPages
                .Create(dto).Fetch().Result;

            var result = Api.ExternalPages.
                Delete(externalPageId).Fetch().Result;

            Assert.True(result);
        }
    }
}