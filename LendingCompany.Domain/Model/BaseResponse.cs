namespace LendingCompany.Domain.Model
{
    public class BaseResponse<T>
    {
        public BaseResponse(string message)
        {
            Message = message;
            Success = false;
        }

        public BaseResponse(T item)
        {
            Item = item;
            Success = true;
        }

        public string Message { get; }
        public T Item { get; }
        public bool Success { get; }
    }
}
