using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public Result(bool succes, string message):this(succes)  //:this ile Bu ctor çalışırken otomatik olarak tek paramtereli ctor da çalışır 
        {
            Message = message;
        }

        public Result(bool success) //2 farklı parametrelere sahip ctor oluşturduk buna overloading denir.
        {
            Success = success;  
        }

        public string Message { get; }
    }
}
