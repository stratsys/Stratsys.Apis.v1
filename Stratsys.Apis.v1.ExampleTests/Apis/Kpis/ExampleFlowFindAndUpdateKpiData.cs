using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos;
using Stratsys.Apis.v1.Dtos.Kpis;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Kpis
{
    public class ExampleFlowFindAndUpdateKpiData : BaseTest
    {
        [TestCase("kommunstyrelsen", "Arbetskraftens storlek 16-64", "Utfall Kvinnor/Flickor", "2011-12-31", 22.0)]
        public void Example_Find_and_update_kpiData(
            string uniqueDepartmentName, string uniqueKpiName, string uniqueKpiColumnName,
            string date, double? value)
        {
            var department = Api.Departments.Filter(uniqueDepartmentName).Fetch().Result.Single();
            var kpi = Api.Kpis.Filter(departmentId: department.Id, name: uniqueKpiName).Fetch().Result.Single();
            var kpiColumn = Api.KpiColumns.Filter(kpi.Id, department.Id, uniqueKpiColumnName).Fetch().Result.Single();
            var kpiData = new KpiDataDto
            {
                Date = date,
                DepartmentId = department.Id,
                KpiColumnId = kpiColumn.Id,
                KpiId = kpi.Id,
                Value = value
            };
            var stratsysApiMetadata = Api.KpiData.SaveOrUpdate(kpiData).Fetch();
            Assert.That(stratsysApiMetadata.Result, Is.EqualTo(value));
        }

        
       
    }
}