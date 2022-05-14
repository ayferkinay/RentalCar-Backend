using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
   public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarContext>, ICarImageDal
    {
        public void MultipleAdd(List<CarImage> images) // add ve deleteupdate işlemlerine ek olarak çoklu ekleme ve çoklu silme de yapma özelliği eklendi
        {
            for (int i = 0; i < images.Count; i++)
            {
                Add(images[i]);
            }
        }

        public void MultipleDelete(List<CarImage> images)
        {
            for (int i = 0; i < images.Count; i++)
            {
                Delete(images[i]);
            }
        }

    }
}

