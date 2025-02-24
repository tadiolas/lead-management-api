namespace LeadManagement.Domain.Entities.Response
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }

        public BaseResponse() { }
        public BaseResponse(T data, string message, bool error)
        {
            Data = data;
            Message = message;
            Error = error;
        }
    }
}
