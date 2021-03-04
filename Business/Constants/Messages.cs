using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string DailyPriceError = "Aracın günlük ücretini '0' dan fazla giriniz.";
       
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";
        
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandsListed = "Markalar listelendi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomersListed = "Müşteriler listelendi.";

        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string RentalsListed = "Kiralamalar listelendi.";
        public static string RentalError = "Kiralanmak istenen araç teslim edilmemiş.";

        public static string CarImageAdded = "Arabanın fotoğrafı eklendi.";
        public static string CarImageDeleted = "Arabanın fotoğrafı silindi.";
        public static string CarImageUpdated = "Arabanın fotoğrafı güncellendi.";
        public static string CarImagesListed = "Arabanın fotoğrafları listelendi.";
        public static string CarImageLimitExceeded = "Bu araç için 5den fazla fotoğraf eklenemez";
        
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı  mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
