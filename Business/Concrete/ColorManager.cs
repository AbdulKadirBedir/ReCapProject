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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        [CacheAspect(10)]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
