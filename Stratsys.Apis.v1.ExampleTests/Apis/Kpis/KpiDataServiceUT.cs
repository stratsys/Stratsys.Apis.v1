using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Kpis;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Kpis
{
    public class KpiDataServiceUT : BaseTest
    {
        [TestCase("1234567", "1")]
        public void When_filtering_on_kpiData_and_kpi_does_not_exist_Should_fail(string kpiId, string departmentIdFilter)
        {
            var stratsysApiMetadata = Api.KpiData.Filter(kpiId, departmentIdFilter).Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Kpi undefined: 1234567 ('Department: 1')"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }

        [TestCase("16365", "1", 18)]
        public void When_filtering_on_kpiData_by_departmentId_Should_get_filtered_kpiData(string kpiId, string departmentIdFilter, int expectedNumberOfKpiData)
        {
            var kpiData = Api.KpiData.Filter(kpiId, departmentIdFilter).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "18094", 3)]
        public void When_filtering_on_kpiData_by_kpiColumnId_Should_get_filtered_kpiData(string kpiId, string kpiColumnId, int expectedNumberOfKpiData)
        {
            var kpiData = Api.KpiData.Filter(kpiId, kpiColumnId: kpiColumnId).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "Utfall Kvinnor/Flickor", 6)]
        public void When_filtering_on_kpiData_by_kpiColumnName_Should_get_filtered_kpiData(string kpiId, string kpiColumnName, int expectedNumberOfKpiData)
        {
            var kpiData = Api.KpiData.Filter(kpiId, kpiColumnName: kpiColumnName).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", 0, 6)]
        public void When_filtering_on_kpiData_by_kpiColumnIndex_Should_get_filtered_kpiData(string kpiId, int kpiColumnIndex, int expectedNumberOfKpiData)
        {
            var kpiData = Api.KpiData.Filter(kpiId, kpiColumnIndex: kpiColumnIndex).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "2011-01-01", 22)]
        public void When_filtering_on_kpiData_by_startDate_Should_get_filtered_kpiData(string kpiId, DateTime startDate, int expectedNumberOfKpiData)
        {
            var kpiData = Api.KpiData.Filter(kpiId, startDate: startDate).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "2011-01-01", 14)]
        public void When_filtering_on_kpiData_by_endDate_Should_get_filtered_kpiData(string kpiId, DateTime endDate, int expectedNumberOfKpiData)
        {
            var kpiData = Api.KpiData.Filter(kpiId, endDate: endDate).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(expectedNumberOfKpiData));
        }

        [TestCase("16365", "1", "18094", "2011-01-01", "2011-12-31", "2011-12-31", "Utfall Kvinnor/Flickor", 0, 22.0)]
        public void When_filtering_on_single_kpiData_Should_get_single_kpiData(
            string kpiId, string departmentIdFilter, string kpiColumnId, DateTime startDate, DateTime endDate,
            string expectedDate, string expectedKpiColumnName, int expectedKpiColumnIndex, double? expectedValue
            )
        {
            var kpiData = Api.KpiData.Filter(kpiId, departmentIdFilter, kpiColumnId, startDate: startDate, endDate: endDate).Fetch().Result;
            Assert.That(kpiData.Count, Is.EqualTo(1));
            var kpiDataSingle = kpiData[0];
            Assert.That(kpiDataSingle.KpiId, Is.EqualTo(kpiId));
            Assert.That(kpiDataSingle.DepartmentId, Is.EqualTo(departmentIdFilter));
            Assert.That(kpiDataSingle.KpiColumnId, Is.EqualTo(kpiColumnId));
            Assert.That(kpiDataSingle.Date, Is.EqualTo(expectedDate));
            Assert.That(kpiDataSingle.KpiColumnName, Is.EqualTo(expectedKpiColumnName));
            Assert.That(kpiDataSingle.KpiColumnIndex, Is.EqualTo(expectedKpiColumnIndex));
            Assert.That(kpiDataSingle.Value, Is.EqualTo(expectedValue));
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

            var newValue = Api.KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(value));
        }

        [TestCase("16365", "5", "1", "Utfall Kvinnor/Flickor", "2011-12-31", 22.0)]
        public void When_updating_kpiData_for_consolidation_child_Should_update_chain(
            string kpiId, string departmentId, string parentId, string kpiColumnName, string date, double? value)
        {
            var kpiData = new KpiDataDto
            {
                Date = date,
                DepartmentId = departmentId,
                KpiColumnName = kpiColumnName,
                KpiId = kpiId,
                Value = value
            };

            var newValue = Api.KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(value));
            var kpiDataDtos = Api.KpiData.Filter(kpiId, parentId, kpiColumnName: kpiColumnName, startDate: DateTime.Parse(date), endDate: DateTime.Parse(date)).Fetch().Result;
            Assert.That(kpiDataDtos.Count, Is.EqualTo(1));
            Assert.That(kpiDataDtos[0].Value, Is.EqualTo(value));
        }

        [TestCase("16365", "5", "utfall kvinnor/flickor", "2011-12-31", 22.0)]
        public void When_updating_kpiData_by_kpiColumnName_Should_return_new_value(
            string kpiId, string departmentId, string kpiColumnName, string date, double? value)
        {
            var kpiData = new KpiDataDto
            {
                Date = date,
                DepartmentId = departmentId,
                KpiColumnName = kpiColumnName,
                KpiId = kpiId,
                Value = value
            };

            var newValue = Api.KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(value));
        }

        [TestCase("16365", "5", 0, "2011-12-31", 22.0)]
        public void When_updating_kpiData_by_kpiColumnIndex_Should_return_new_value(
            string kpiId, string departmentId, int kpiColumnIndex, string date, double? value)
        {
            var kpiData = new KpiDataDto
            {
                Date = date,
                DepartmentId = departmentId,
                KpiColumnIndex = kpiColumnIndex,
                KpiId = kpiId,
                Value = value
            };

            var newValue = Api.KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(value));
        }

        [TestCase("16365", "1", "18094", "2011-12-31", 22.0, 75.0)]
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

            var newValue = Api.KpiData.SaveOrUpdate(kpiData).Fetch().Result;
            Assert.That(newValue, Is.EqualTo(oldValue));
        }
    }
}