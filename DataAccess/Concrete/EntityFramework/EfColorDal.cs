using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalContext>, IColorDal
    {
        public List<ColorDetailDto> GetColorDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from color in context.Colors
                             select new ColorDetailDto
                             {
                                 ColorName = color.Name
                             };
                return result.ToList();
            }
        }
    }
}
