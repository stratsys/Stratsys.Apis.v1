namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class GoalDto
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
    }


    //public class NodeDto
    //{
    //    public string NodeId { get; set; }
    //    public string DepartmentId { get; set; }
    //}

    //public class NodeNameDto
    //{
    //    public NodeDto NodeDto { get; set; }
    //    public string Name { get; set; }
    //}

    //public class ScorecardNodeDto
    //{
    //    public string ScorecardColumnId { get; set; }
    //    public NodeDto NodeDto { get; set; }
    //}

    //public class ConnectionDto
    //{
    //    public ScorecardNodeDto Parent { get; set; }
    //    public ScorecardNodeDto Child { get; set; }
    //}
}