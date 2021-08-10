using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new ReCapContext())
            {
                IQueryable<CarDetailDto> result =
                    from car in filter is null ? context.Cars : context.Cars.Where(filter)
                    join brand in context.Brands
                    on car.BrandId equals brand.BrandId
                    join color in context.Colors
                    on car.ColorId equals color.ColorId
                    select new CarDetailDto
                    {
                        Id = car.CarId,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        BrandId = brand.BrandId,
                        ColorId = color.ColorId,
                        ImagePath = (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).FirstOrDefault()
                    };
                return result.ToList();
                
            }
        } 
    }
}
