using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {//IREsult içindeki succes ve message dışında bi de data döndürüyor 
        T Data { get; }
    }
}
