using Business.Abstarct;
using Business.businessAspects.Autofac;
using Business.ValidatoinRules.FluentValidation;
using Core.Aspect.Autofac.caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }
        
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        [CacheAspect(10)]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.Id == id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
