using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(rental => rental.CarId).NotEmpty().WithMessage("Araba Bilgileri Boş Olamaz!");
            RuleFor(rental => rental.CustomerId).NotEmpty().WithMessage("Müşteri Bilgileri Boş Olamaz!");
            RuleFor(rental => rental.RentDate).NotEmpty().WithMessage("Kiralama Tarihi Boş Olamaz!");
        }
    }
}
