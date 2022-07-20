using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.CarName).NotEmpty().WithMessage("Araba İsmi Boş Olamaz.");
            RuleFor(car => car.BrandId).NotEmpty().WithMessage("Araba Marka Numarası Boş Olamaz.");
            RuleFor(car => car.ColorId).NotEmpty().WithMessage("Araba Renk Numarası Boş Olamaz.");
            RuleFor(car => car.ModelYear).NotEmpty().WithMessage("Araba Model Yılı Boş Olamaz.");
            RuleFor(car => car.CarName).MinimumLength(2).WithMessage("Araba İsmi 2 Karakterden fazla olmalıdır.");
            RuleFor(car => car.DailyPrice).GreaterThan(0).WithMessage("Kiralama ücreti 0(sıfır)'dan büyük olmalıdır.");
        }
    }
}
