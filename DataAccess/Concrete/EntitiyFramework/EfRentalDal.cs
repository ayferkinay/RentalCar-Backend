using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfRentalDall : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalDetails()
        {
            using CarContext context = new CarContext();
            var result = from ren in context.Rentals
                         join us in context.Users
                         on ren.CustomerId equals us.Id
                         join bra in context.Brands
                         on ren.CarId equals bra.BrandId
                         select new RentalDetailDto
                         {
                             BrandName = bra.BrandName,
                             FullName = us.FirstName + " " + us.LastName,
                             RentDate = ren.RentDate,
                             ReturnDate = ren.ReturnDate,
                         };
            return result.ToList();

            }

        }
    }

