using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Organization;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.Tests.Apis.Organizations
{
    public class DepartmentServiceUT : BaseTest
    {
        [Test]
        public void When_listing_departments_Should_get_departments()
        {
            var departments = Departments.List().Fetch().Result;
            Assert.That(departments, Is.Not.Empty);
        }

        [TestCase("kommun", 3)]
        public void When_filtering_on_departments_by_name_Should_get_filtered_departments(string nameFilter, int expectedNumberOfDepartments)
        {
            var departments = Departments.Filter(nameFilter).Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments), "expectedNumberOfDepartments");
        }

        [TestCase("1", 8)]
        public void When_filtering_on_departments_by_parentId_Should_get_filtered_departments(string parentIdFilter, int expectedNumberOfDepartments)
        {
            var departments = Departments.Filter(parentId: parentIdFilter).Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments));
        }

        [TestCase("2", "Skol- och fritidsnämnden", "Skol- och fritidsnämnden", "1")]
        public void When_retrieving_department_by_id_Should_get_department(string id, string expectedName, string expectedShortName, string expectedParentId)
        {
            var department = Departments.Get(id).Fetch().Result;
            Assert.That(department, Is.Not.Null);
            Assert.That(department.Id, Is.EqualTo(id));
            Assert.That(department.Name, Is.EqualTo(expectedName));
            Assert.That(department.ShortName, Is.EqualTo(expectedShortName));
            Assert.That(department.ParentId, Is.EqualTo(expectedParentId));
        }

        [TestCase("123456")]
        public void When_retrieving_department_by_non_existing_id_Should_get_null(string id)
        {
            var stratsysApiMetadata = Departments.Get(id).Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.True);
            
            var department = stratsysApiMetadata.Result;
            Assert.That(department, Is.Null);
        }

        [TestCase("133")]
        public void When_creating_department_Should_get_created_department(string parentId)
        {
            var name = Guid.NewGuid().ToString();
            var shortName = Guid.NewGuid().ToString();

            var departmentDto = new DepartmentDto
            {
                Name = name,
                ShortName = shortName,
                ParentId = parentId
            };
            var department = Departments.SaveOrUpdate(departmentDto).Fetch().Result;
            Assert.That(department.Id, Is.Not.Null.Or.Empty);
            Assert.That(department.Name, Is.EqualTo(name));
            Assert.That(department.ShortName, Is.EqualTo(shortName));
            Assert.That(department.ParentId, Is.EqualTo(parentId));
        }

        [TestCase("133", "newName", "newShortName")]
        public void When_updating_name_for_department_Should_get_updated_department(string id, string newName, string newShortName)
        {
            var departmentDto = new DepartmentDto
            {
                Id = id,
                Name = newName,
                ShortName = newShortName
            };
            var department = Departments.SaveOrUpdate(departmentDto).Fetch().Result;
            Assert.That(department.Id, Is.Not.Null.Or.Empty);
            Assert.That(department.Name, Is.EqualTo(newName));
            Assert.That(department.ShortName, Is.EqualTo(newShortName));
        }

        private DepartmentResource Departments
        {
            get
            {
                return new DepartmentService(ClientId, ClientSecret).Departments;
            }
        }
    }
}
