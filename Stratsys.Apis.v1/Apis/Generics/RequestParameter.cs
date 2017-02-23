namespace Stratsys.Apis.v1.Apis.Generics
{
    public class RequestParameter
    {
        public RequestParameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}