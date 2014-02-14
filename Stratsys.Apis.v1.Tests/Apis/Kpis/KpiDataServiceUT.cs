using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Kpis;
using Stratsys.Apis.v1.Apis.Kpis.Resources;
using Stratsys.Apis.v1.Apis.Kpis.Services;
using Stratsys.Apis.v1.Dtos.Kpis;
using Stratsys.Apis.v1.Tests;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Kpis
{
    public class KpiDataServiceUT : BaseTest
    {
        [TestCase("1234567", "1")]
        public void When_filtering_on_kpiData_and_kpi_does_not_exist_Should_fail(string kpiId, string departmentIdFilter)
        {
            var stratsysApiMetadata = KpiData.Filter(kpiId, departmentIdFilter).Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Kpi undefined: 1234567 ('Department: 1')"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }

        [TestCase("16365", "1", 18)]
        public void When_filtering_on_kpiData_by_departmentId_Should_get_filtered_kpiData(string kpiId, string departmentIdFilter, int expectedNumberOfKpiData)
        {
            var kpiData = KpiData.Filter(kpiId, departmentIdFilter).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "18094", 3)]
        public void When_filtering_on_kpiData_by_kpiColumnId_Should_get_filtered_kpiData(string kpiId, string kpiColumnId, int expectedNumberOfKpiData)
        {
            var kpiData = KpiData.Filter(kpiId, kpiColumnId: kpiColumnId).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "2011-01-01", 22)]
        public void When_filtering_on_kpiData_by_startDate_Should_get_filtered_kpiData(string kpiId, string startDate, int expectedNumberOfKpiData)
        {
            var kpiData = KpiData.Filter(kpiId, startDate: startDate).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "2011-01-01", 14)]
        public void When_filtering_on_kpiData_by_endDate_Should_get_filtered_kpiData(string kpiId, string endDate, int expectedNumberOfKpiData)
        {
            var kpiData = KpiData.Filter(kpiId, endDate: endDate).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "1", "18094", "2011-01-01", "2011-12-31", "2011-12-31", 50.0)]
        public void When_filtering_on_single_kpiData_Should_get_single_kpiData(
            string kpiId, string departmentIdFilter, string kpiColumnId, string startDate, string endDate,
            string expectedDate, double? value
            )
        {
            var kpiData = KpiData.Filter(kpiId, departmentIdFilter, kpiColumnId, startDate, endDate).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(1));
            var kpiDataSingle = kpiData[0];
            Assert.That(kpiDataSingle.KpiId, Is.EqualTo(kpiId));
            Assert.That(kpiDataSingle.DepartmentId, Is.EqualTo(departmentIdFilter));
            Assert.That(kpiDataSingle.KpiColumnId, Is.EqualTo(kpiColumnId));
            Assert.That(kpiDataSingle.Date, Is.EqualTo(expectedDate));
            Assert.That(kpiDataSingle.Value, Is.EqualTo(value));
        }

        [TestCase("16365", "5", "18791", "2011-12-31", 22.0)]
        public void When_updating_kpiData_Should_return_new_value(
            string kpiId, string departmentId, string kpiColumnId, string date, double? value)
        {
            var kpiData = new KpiDataDto
            {
                Date = date,
                DepartmentId = departmentId,
                KpiColumnId = kpiColumnId,
                KpiId = kpiId,
                Value = value
            };

            var newValue = KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(value));
        }

        [TestCase("16365", "1", "18094", "2011-12-31", 50.0, 75.0)]
        public void When_updating_kpiData_for_locked_input_Should_return_old_value(
            string kpiId, string departmentId, string kpiColumnId, string date, double? oldValue, double? value)
        {
            var kpiData = new KpiDataDto
            {
                Date = date,
                DepartmentId = departmentId,
                KpiColumnId = kpiColumnId,
                KpiId = kpiId,
                Value = value
            };

            var newValue = KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(oldValue));
        }

        private KpiDataResource KpiData
        {
            get
            {
                return new KpiDataService(ClientId, ClientSecret).KpiData;
            }
        }
    }
}