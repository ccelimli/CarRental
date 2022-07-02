
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(color => color.Name).MinimumLength(2).WithMessage("Renk Adı 2 Karakterden Daha Az Olamaz.");
            RuleFor(color => color.Name).NotEmpty().WithMessage("Renk Adı Boş Olamaz.");
        }
    }
}
