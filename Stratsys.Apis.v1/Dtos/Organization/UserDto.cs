namespace Stratsys.Apis.v1.Dtos.Organization
{
    public class UserDto : UserProperties
    {
        public string Id { get; set; }
    }

    public class CreateUserDto : UserProperties
    {
        public string Password { get; set; }
    }

    public class UserProperties
    {
        public string MainGroupId { get; set; }
        public string MainDepartmentId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneRegular { get; set; }
        public string PhoneMobile { get; set; }
    }
}