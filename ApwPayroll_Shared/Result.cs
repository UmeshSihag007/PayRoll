using ApwPayroll_Shared.Interfaces;

namespace ApwPayroll_Shared
{
    public class Result<T> : IResult<T>
    {
        public List<string> Messages { get; set; }
        public bool succeeded { get; set; }
        public T Data { get; set; }
        public int code { get; set; }
        public string Token { get; set; }

        #region Helper Method

        #endregion

        #region Success Methods
        public static Result<T> Success(T? data = default, string? message = default, string? token = default)
        {
            return new Result<T>
            {
                code = 200,
                Messages = new List<string> { message ?? "Inserted..." },
                succeeded = true,
                Data = data,
                Token = token
            };
        }
        #endregion

        #region  Bad Request Method

        public static Result<T> BadRequest(string message = default, T? data = default)
        {
            return new Result<T>
            {
                succeeded = false,
                Messages = new List<string> { message ?? $"Invalid {typeof(T).Name} Id" },
                code = 400,
                Data = data
            };
        }
        #endregion

        #region NotFound Method
        public static Result<T> NotFound()
        {

            return new Result<T>
            {
                code = 404,
                Messages = new List<string> { $"No Data Found {typeof(T).Name}.." },
                succeeded = false,
            };
        }
        #endregion
        #region UnAuthorize Methods
        public static Result<T> UnAuthorize()
        {
            return new Result<T>
            {
                code = 401,
                Messages = new List<string> { $"UnAuthorize  request.." },
                succeeded = false,
            };
        }
        #endregion
    }
}
