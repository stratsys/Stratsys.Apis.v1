using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class ScorecardNodeDto : PutNodeDto
    {
        public string ParentId { get; set; }
        public DepartmentDto Department { get; set; }
        public ScorecardDto Scorecard { get; set; }
        public ScorecardColumnDto ScorecardColumn { get; set; }
        public IList<DescriptionFieldValueDto> DescriptionFields { get; set; }
        public IList<KeywordDto> Keywords { get; set; }
        public IList<ResponsibleDto> Responsibles { get; set; }
        public IList<StatusDto> AvailableStatuses { get; set; }
        public double SortOrder { get; set; }
    }

    public class PutNodeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class PostNodeDto
    {
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string ScorecardColumnId { get; set; }
    }
}