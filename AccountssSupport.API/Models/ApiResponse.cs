namespace AccountssSupport.API.Models
{
    namespace AccountsssSupport.API.Models
    {
        public class ApiResponse<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
            public string Error { get; set; }

            public static ApiResponse<T> SuccessResponse(T data, string message = "Operación exitosa")
            {
                return new ApiResponse<T>
                {
                    Success = true,
                    Message = message,
                    Data = data,
                    Error = null
                };
            }

            public static ApiResponse<T> ErrorResponse(string error, string message = "Error en la operación")
            {
                return new ApiResponse<T>
                {
                    Success = false,
                    Message = message,
                    Data = default(T),
                    Error = error
                };
            }
        }
    }
}
