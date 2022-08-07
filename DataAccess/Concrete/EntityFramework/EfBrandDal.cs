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
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from brand in context.Brands
                             select new BrandDetailDto
                             {
                                 BrandName = brand.Name
                             };
                return result.ToList();
            }
            
        }
    }
}

