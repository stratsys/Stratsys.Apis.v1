using System;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class ScorecardColumnDto
    {
        public string Id { get; set; }
        [Obsolete("use property Scorecard")]
        public string ScorecardId { get; set; }
        public ScorecardDto Scorecard { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public int Index { get; set; }
        public string NodeType { get; set; }
    }
}