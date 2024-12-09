using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling
{
    public class ServiceResult
    {
        public int Status { get; set; }
        public ProblemDetails? ProblemDetails { get; set; }
    }
    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public static ServiceResult<T> Success(T data, int statusCode)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Status = statusCode


            };
        }

        public static ServiceResult<T> Fail(string message, int statusCode)
        {
            return new ServiceResult<T>
            {
                ProblemDetails = new ProblemDetails
                {
                    Status = statusCode,
                    Title = "Hata Oluştu",
                    Detail = message
                }


            };
        }

    }
}
