using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

/*
Car car = new Car() {BrandId=1,CarName="CLA 180",ColorId=1,DailyPrice=350,ModelYear=2020,Description="Kullanılabilir" };
*/
CarManager carManager = new CarManager(new EfCarDal());

//carManager.Add(car);

foreach (var car in carManager.GetCarDetails())
{
    Console.WriteLine("Marka: {0}\nModel: {1}\nRenk: {2}\nGünlük Ücret: {3}\nDurum: {4}", car.BrandName,car.CarName,car.ColorName,car.DailyPrice,car.Description);
}
