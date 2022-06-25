using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Brand
        public static string BrandAdded = "Marka Eklendi"; 
        public static string BrandDeleted = "Marka Silindi"; 
        public static string BrandUpdated = "Marka Güncellendi"; 
        public static string BrandListed = "Marka Listelendi"; 
        public static string BrandsListed = "Markalar Listelendi"; 

        //Car
        public static string CarAdded = "Araba Eklendi.";
        public static string CarDeleted = "Araba Silindi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarsListed = "Arabalar Listelendi.";
        public static string CarListed = "Araba Listelendi.";
        public static string InvalidCarName = "Geçersiz Araba İsmi.";
        public static string InvalidDailyPrice = "Geçersiz Günlük Ücret.";
        public static string CannotRent = "Bu araç şu an kiralanamaz!";

        //User
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        public static string UserListed = "Kullanıcı Listelendi.";
        public static string UsersListed = "Kullanıcılar Listelendi.";
        public static string InvalidFirstName = "İsim En Az 2 Karakter Olmalıdır!";
        public static string InvalidPassword="Parola uzunluğu 6-20 arasında olmalıdır!";
        public static string InvalidPhoneNumber = "Lütfen telefon numaranızı başında 0(sıfır) olmadan giriniz!";
        public static string NotFoundUser = "Kullanıcı Bulunamadı.";

        //Color
        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";
        public static string ColorListed = "Renk Listelendi.";
        public static string ColorsListed = "Renkler Listelendi.";
        public static string InvalidColorName = "Renk adı en az 2 karakter olmalıdır.";

        //Rental
        public static string RentalAdded = "Kayıt Oluşturuldu.";
        public static string RentalDeleted = "Kayıt Silindi.";
        public static string RentalUpdated = "Kayıt bilgileri güncellendi.";
        public static string RentalListed = "Kayıt bilgisi listelendi.";
        public static string RentalsListed = "Kayıt bilgileri listelendi.";

        //Customer
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string NotFoundCustomer = "Müşteri bulunamadı";

        //System
        public static string MaintenanceTime = "Sistem Bakımda!";

    }
}
