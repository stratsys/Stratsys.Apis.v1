namespace Stratsys.Apis.v1.Dtos
{
    public class StratsysApiMetadata<T>
    {
        public StratsysApiMetadata(T result, bool success = true)
        {
            Success = success;
            Result = result;
        }

        public T Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}