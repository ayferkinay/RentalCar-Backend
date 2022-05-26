using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("customer.add")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }


        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("customer.delete")]
        [PerformanceAspect(5)]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);  
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Customer>> GetAll()
        {
            
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }



        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Customer> GetById(int customerId)
        {
            
            return new SuccessDataResult<Customer>(_customerDal.GetById(c => c.Id == customerId),Messages.CustomerIsInvalid);
        }



        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.update")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
