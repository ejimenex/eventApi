namespace EventApi.Infrasestructure.Model
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }

    }
}
