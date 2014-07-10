namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class CreateGoalDto
    {
        public string Name { get; set; }
        public string DepartmentId { get; set; }
        public string ColumnId { get; set; }
        public string ParentNodeId { get; set; }
        public string ParentColumnId { get; set; }
    }
}