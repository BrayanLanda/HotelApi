namespace HotelApi.Errors.General
{
    public class ApiException(int statusCode, string message, string? details)
    {
        //generic class for sending capture messages
        public int StatusCode { get; set; } = statusCode;
        public string Message { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}