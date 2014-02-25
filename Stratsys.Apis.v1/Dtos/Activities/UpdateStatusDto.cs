namespace Stratsys.Apis.v1.Dtos.Activities
{
    public class UpdateStatusDto
    {
        public string UserId { get; set; }
        public string DepartmentId { get; set; }
        public string ActivityId { get; set; }
        public string StatusId { get; set; }
    }
}