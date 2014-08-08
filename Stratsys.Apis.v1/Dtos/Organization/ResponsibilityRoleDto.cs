namespace Stratsys.Apis.v1.Dtos.Organization
{
    public class ResponsibilityRoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDepartmentSpecific { get; set; }         
    }
}