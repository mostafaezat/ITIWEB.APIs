namespace ITIWEB.APIs.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string _details {  get; set; }
        public ApiExceptionResponse(int statusCode, string message = null, string details = null ) : base(statusCode, message)
        {
            _details = details;
        }
    }
}
