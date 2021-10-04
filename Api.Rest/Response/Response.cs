using System;

namespace Api.Rest.Response
{
    public class Response<T>
    {
        public bool Success { get; private set; }
        public string Exception { get; private set; }
        public T Result { get; set; }
        public Response(T arg)
        {
            Result = arg;
            Success = true;
            Exception = null;
        }
        public Response(Exception ex)
        {
            Exception = ex.Message;
            Success = false;
            Result = default(T);
        }
    }
}