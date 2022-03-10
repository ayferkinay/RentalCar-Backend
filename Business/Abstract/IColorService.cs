using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
       IDataResult<List<Colorr>> GetAll();
        IDataResult<Colorr >GetById(int ColorId);

        IResult Add(Colorr Color);
        IResult Update(Colorr Color);
        IResult Delete(Colorr Color);
    }
}
