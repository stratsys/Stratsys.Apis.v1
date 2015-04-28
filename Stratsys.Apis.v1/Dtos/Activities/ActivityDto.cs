using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.Dtos.Activities
{
    public class ActivityDto
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string StatusId { get; set; }
        public string Name { get; set; }
        public string EndDate { get; set; }
        public IList<ScorecardColumnDto> ScorecardColumns { get; set; }
    }
}