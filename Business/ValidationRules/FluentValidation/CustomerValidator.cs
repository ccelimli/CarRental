using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.UserId).NotEmpty().WithMessage("Customer UserId Boş Olamaz!");
            RuleFor(customer => customer.CompanyName).NotEmpty().WithMessage("Müşteri Şirket İsmi Boş Olamaz!");
            RuleFor(customer => customer.CompanyName).MinimumLength(5).WithMessage("Müşteri Şirket İsmi 5 Karakterden Daha Az Olamaz!");
        }
    }
}
