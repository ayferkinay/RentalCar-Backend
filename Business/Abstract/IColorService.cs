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
        List<Colorr> GetAll();
        Colorr GetById(int ColorId);

        void Add(Colorr Color);
        void Update(Colorr Color);
        void Delete(Colorr Color);
    }
}
