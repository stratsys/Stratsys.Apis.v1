using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.Gadgets
{
    public class UserReportingListDto
    {
        public bool ShowScorecardName { get; set; }
        public bool ShowAll { get; set; }
        public bool ShowPeriod { get; set; }
        public List<ReportingListNode> Nodes { get; set; }
    }
}