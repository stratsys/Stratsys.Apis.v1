using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class ScorecardNodeDto
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public DepartmentDto Department { get; set; }
        public ScorecardDto Scorecard { get; set; }
        public ScorecardColumnDto Column { get; set; }
        public IList<DescriptionFieldValueDto> Descriptions { get; set; }
        public IList<KeywordDto> Keywords { get; set; }
        public IList<NodeResponsibleDto> Responsibles { get; set; }
    }
}