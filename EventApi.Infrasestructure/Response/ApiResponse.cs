﻿namespace EventApi.Infrasestructure.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }=true;
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
