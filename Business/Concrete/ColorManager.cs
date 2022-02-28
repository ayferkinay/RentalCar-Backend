using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Colorr Color)
        {
            _colorDal.Add(Color);
        }

        public void Delete(Colorr Color)
        {
            _colorDal.Delete(Color);
        }

        public List<Colorr> GetAll()
        {
           return _colorDal.GetAll();
        }

        public Colorr GetById(int colorId)
        {
            return _colorDal.Get(c=>c.ColorId == colorId);
        }

        public void Update(Colorr Color)
        {
            _colorDal.Update(Color);
        }
    }
}
