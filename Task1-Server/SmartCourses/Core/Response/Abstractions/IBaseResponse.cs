using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response.Abstractions
{
    public interface IBaseResponse<T>
    {
        public string Info { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
