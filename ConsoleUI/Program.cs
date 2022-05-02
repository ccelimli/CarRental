using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

/*
Car car = new Car() {BrandId=1,CarName="CLA 180",ColorId=1,DailyPrice=350,ModelYear=2020,Description="Kullanılabilir" };
*/
CarManager carManager = new CarManager(new EfCarDal());

//carManager.Add(car);
/*
var resultCars = carManager.GetCarDetails();
if (resultCars.Success==true)
{
    foreach (var car in resultCars.Data)
    {
        Console.WriteLine("Marka: {0}\nModel: {1}\nRenk: {2}\nGünlük Ücret: {3}\nDurum: {4}", car.BrandName, car.CarName, car.ColorName, car.DailyPrice, car.Description);
        Console.WriteLine(resultCars.Message);
    }
}
else
{
    Console.WriteLine(resultCars.Message);
}
*/

Car car = new Car() { BrandId = 1, CarName = "aaa", ColorId = 1, DailyPrice = 0, Description = "adas", ModelYear=2020 };
var result = carManager.Add(car);
if (result.Success==true)
{
    carManager.Add(car);
}
else
{
    Console.WriteLine(result.Message); 
}
/*
BrandManager brandManager = new BrandManager(new EfBrandDal());

var result = brandManager.GetAll();
foreach (var brands in result.Data)
{
    Console.WriteLine(brands.Name);
    
}
*/