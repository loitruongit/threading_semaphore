namespace threading_semaphore.Models.Responses
{
    public class AppResponse<TData>
    {
        public bool IsSuccess { get; set; }

        public TData? Data { get; set; }

        public string Message { get; set; }

        public AppResponse()
        {
            IsSuccess = false;
            Data = default;
            Message = string.Empty;
        }

        internal AppResponse(TData? data, bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public static AppResponse<TData> Success(TData data, string message = null)
        {
            return new AppResponse<TData>(data, true, message ?? "Successfully");
        }

        public static AppResponse<TData> Error(TData data, string message)
        {
            return new AppResponse<TData>(data, false, message);
        }

        public static AppResponse<TData> Error(string message)
        {
            return new AppResponse<TData>(default, false, message);
        }
    }

    public class AppResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public AppResponse()
        {
            IsSuccess = false;
            Message = string.Empty;
        }

        internal AppResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static AppResponse Success()
        {
            return new AppResponse(true, "Successfully");
        }

        public static AppResponse Error(string message)
        {
            return new AppResponse(false, message);
        }
    }
}
