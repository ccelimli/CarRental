using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

Car car = new Car() {ColorId=1,BrandId=1,DailyPrice=1231,ModelYear=2020,Description="New Car" };
CarManager carManager = new CarManager(new EfCarDal());
carManager.Add(car);
