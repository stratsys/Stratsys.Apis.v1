using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class ScorecardColumnDto
    {
        public string Id { get; set; }
        public string ScorecardId { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public int Index { get; set; }
        public string NodeType { get; set; }
    }
}