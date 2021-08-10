using Business.Abstarct;
using Business.businessAspects.Autofac;
using Business.Constants;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult();
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Get")]
        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }
        [CacheAspect(10)]
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Message.CarListed);
        }

        public IDataResult<List<Car>> GetCarByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
