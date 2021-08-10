using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
        IDataResult<List<Car>> GetCarByDailyPrice(decimal min, decimal max);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
