using Core.Enums;
using Core.Response.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Info { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
