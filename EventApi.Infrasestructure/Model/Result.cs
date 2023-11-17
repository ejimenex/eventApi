namespace EventApi.Infrasestructure.Model
{
    public class Result<T>
    {
        public bool Succeeded { get; set; }
        public string? FriendlyMessage { get; set; }
        public T? Items { get; set; }
        public int Total { get; set; }
        public string? StatusCode { get; set; }
        public string? StackTrace { get; set; }

        public static Result<T> Fail(string friendlyMessage, string statusCode, string? stackTrace = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                FriendlyMessage = friendlyMessage,
                StackTrace = stackTrace,
                StatusCode = statusCode
            };
        }

        public static Result<T> Success(T data, int total, string? message = null)
        {
            return new Result<T> { Succeeded = true, Items = data, Total = total, FriendlyMessage = message };
        }
    }
}
