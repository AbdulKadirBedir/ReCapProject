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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        [CacheAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CarId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
