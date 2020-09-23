using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }


        public ApiResponse(int statusCode, string message = null)
        {
            this.statusCode = statusCode;
            this.message = message ?? GetDefaultMessage(statusCode);

        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "you have made a bad request",
                401 => "Unauthorized request made",
                404 => "Resource not found",
                500 => "Error from the server side!",
                _ => null

            };
        }
    }
}