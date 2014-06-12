using System;
using System.Net;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class DepartmentServiceUT : BaseTest
    {
        [TestCase(152)]
        public void When_listing_departments_Should_get_departments(int expectedNumberOfDepartments)
        {
            var departments = Api.Departments.List().Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments));
        }

        [TestCase(50)]
        public void When_filtering_on_departments_with_max_result_Should_get_departments(int expectedNumberOfDepartments)
        {
            var departments = Api.Departments.Filter(maxResults: 50).Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments));
        }

        [TestCase("kommun", 3)]
        public void When_filtering_on_departments_by_name_Should_get_filtered_departments(string nameFilter, int expectedNumberOfDepartments)
        {
            var departments = Api.Departments.Filter(nameFilter).Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments));
        }

        [TestCase("5", 10)]
        public void When_filtering_on_departments_by_parentId_Should_get_filtered_departments(string parentIdFilter, int expectedNumberOfDepartments)
        {
            var departments = Api.Departments.Filter(parentId: parentIdFilter).Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments));
        }

        [TestCase("2", "Skol- och fritidsnämnden", "Skol- och fritidsnämnden", "1")]
        public void When_retrieving_department_by_id_Should_get_department(string id, string expectedName, string expectedShortName, string expectedParentId)
        {
            var department = Api.Departments.Get(id).Fetch().Result;
            Assert.That(department, Is.Not.Null);
            Assert.That(department.Id, Is.EqualTo(id));
            Assert.That(department.Name, Is.EqualTo(expectedName));
            Assert.That(department.ShortName, Is.EqualTo(expectedShortName));
            Assert.That(department.ParentId, Is.EqualTo(expectedParentId));
        }

        [TestCase("123456")]
        public void When_retrieving_department_by_non_existing_id_Should_fail(string id)
        {
            var getDepartmentRequest = Api.Departments.Get(id);
            Assert.That(getDepartmentRequest.GetHttpResponse().StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            var stratsysApiMetadata = getDepartmentRequest.Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Department undefined: 123456"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }

        [TestCase("1", "Kommunfullmäktige", "organisation", null)]
        public void When_retrieving_root_department_Should_return_department(string id, string expectedName, string expectedShortName, string expectedParentId)
        {
            var department = Api.Departments.GetRoot().Fetch().Result;

            Assert.That(department, Is.Not.Null);
            Assert.That(department.Id, Is.EqualTo(id));
            Assert.That(department.Name, Is.EqualTo(expectedName));
            Assert.That(department.ShortName, Is.EqualTo(expectedShortName));
            Assert.That(department.ParentId, Is.EqualTo(expectedParentId));
        }

        [TestCase("133")]
        public void When_creating_department_Should_get_created_departmentId(string parentId)
        {
            var name = Guid.NewGuid().ToString();
            var shortName = Guid.NewGuid().ToString();

            var departmentDto = new DepartmentDto
            {
                Name = name,
                ShortName = shortName,
                ParentId = parentId
            };
            var departmentId = Api.Departments.SaveOrUpdate(departmentDto).Fetch().Result;
            Assert.That(departmentId, Is.Not.Null.Or.Empty);
            var department = Api.Departments.Get(departmentId).Fetch().Result;
            Assert.That(department.Id, Is.Not.Null.Or.Empty);
            Assert.That(department.Name, Is.EqualTo(name));
            Assert.That(department.ShortName, Is.EqualTo(shortName));
            Assert.That(department.ParentId, Is.EqualTo(parentId));
        }

        [TestCase("133", "newName", "newShortName")]
        [TestCase("133", "othernewName", "othernewShortName")]
        public void When_updating_name_for_department_Should_get_updated_department(string id, string newName, string newShortName)
        {
            var departmentDto = new DepartmentDto
            {
                Id = id,
                Name = newName,
                ShortName = newShortName
            };
            var departmentId = Api.Departments.SaveOrUpdate(departmentDto).Fetch().Result;
            Assert.That(departmentId, Is.Not.Null.Or.Empty);
            var department = Api.Departments.Get(departmentId).Fetch().Result;
            Assert.That(department.Id, Is.Not.Null.Or.Empty);
            Assert.That(department.Name, Is.EqualTo(newName));
            Assert.That(department.ShortName, Is.EqualTo(newShortName));
        }

        [TestCase("ChangedNameInPlanning", 1)]
        [TestCase("OtherNameInPlanning", 0)]
        [TestCase("DeletedInPlanning", 1)]
        [TestCase("MovedInPlanning", 1)]
        public void Filter_by_name_in_active_version(string nameFilter, int expectedNumberOfDepartments)
        {
            var departments = Api.Departments.Filter(nameFilter).Fetch().Result;
            Assert.That(departments.Count, Is.EqualTo(expectedNumberOfDepartments));
        }

        [TestCase("151", "MovedInPlanning", "MIP", "150")]
        public void Get_department_by_id_in_active_version(string id, string expectedName, string expectedShortName, string expectedParentId)
        {
            var department = Api.Departments.Get(id).Fetch().Result;
            Assert.That(department, Is.Not.Null);
            Assert.That(department.Id, Is.EqualTo(id));
            Assert.That(department.Name, Is.EqualTo(expectedName));
            Assert.That(department.ShortName, Is.EqualTo(expectedShortName));
            Assert.That(department.ParentId, Is.EqualTo(expectedParentId));
        }
    }
}
