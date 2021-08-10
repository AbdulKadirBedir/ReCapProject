using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFrameWork.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarImageDal: EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
    }
}
