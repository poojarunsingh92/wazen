using System;
using System.Collections.Generic;
using System.Text;

namespace WazenAdmin.Application.Responses
{
    public class ServiceBaseResponse2<T>
    {
        public ServiceBaseResponse2()
        {
        }
        public ServiceBaseResponse2(T data, string message = null)
        {
            succeeded = true;
            this.message = message;
            this.data = data;
        }
        public ServiceBaseResponse2(string message)
        {
            succeeded = false;
            message = message;
        }
        public bool succeeded { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }
        public T data { get; set; }
    }


}
