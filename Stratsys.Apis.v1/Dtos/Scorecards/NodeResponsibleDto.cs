namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class NodeResponsibleDto
    {
        public string NodeId { get; set; }
        public string DepartmentId { get; set; }
        public string UserId { get; set; }
        public string ResponsibilityRoleId { get; set; }
    }

    //public class UpdateNodeResponsibleDto
    //{
    //    public NodeDto NodeDto { get; set; }
    //    public ResponsibleDto ResponsibleDto { get; set; }
    //}

    //public class ResponsibleDto
    //{
    //    public string DepartmentId { get; set; }
    //    public string UserId { get; set; }
    //    public string ResponsibilityRoleId { get; set; }
    //}
   
}