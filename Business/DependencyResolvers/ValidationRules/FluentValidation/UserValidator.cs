using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Olamaz!");
            RuleFor(user => user.FirstName).MinimumLength(2).WithMessage("Kullanıcı İsmi 2 Karakteden Daha Az Olamaz!");
            RuleFor(user => user.FirstName).Must(ControlName).WithMessage("Kullanıcı İsmi Geçersiz Karakter İçeriyor!");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Kullanıcı Soyismi Boş Olamaz!");
            RuleFor(user => user.LastName).MinimumLength(2).WithMessage("Kullanıcı Soyismi 2 Karakterden Daha Az Olamaz!");
            RuleFor(user => user.LastName).Must(ControlName).WithMessage("Kullanıcı Soyismi Geçersiz Karakter İçeriyor!");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Kullanıcı Email Boş Olamaz!");
            RuleFor(user => user.Email).Must(ControlEmail).WithMessage("Geçersiz Email!");
            RuleFor(user => user.PhoneNumber).NotEmpty().WithMessage("Kullanıcı Telefon Numarası Boş Olamaz!");
            RuleFor(user => user.PhoneNumber).Must(ControlPhoneNumber).WithMessage("Geçersiz Telefon Numarası! Telefon Numarası 0(sıfır) ile başlayamaz veya rakamdan başka bir değer alamaz");
        }
        
        //ControlName
        private bool ControlName(string arg)
        {
            Regex regex = new Regex(@"^[A-ZİĞÜŞÖÇ][a-zA-ZğüşöçıİĞÜŞÖÇ]*$");
            var result = regex.Match(arg);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ControlEmail
        private bool ControlEmail(string arg)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var result = regex.Match(arg);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ControlPassword
        private bool ControlPassword(string arg)
        {
            Regex regex = new Regex("^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-])$");
            var result = regex.Match(arg);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ControlPhoneNumber
        private bool ControlPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"^[1-9]{10}$");
            var result = regex.Match(arg);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
