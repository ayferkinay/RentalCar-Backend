using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba bilgisi Eklendi";
        public static string CarUpdated= "Araba bilgisi Güncellendi";
        public static string CarDeleted = "Araba bilgisi Silindi";
        public static string CarDescInvalid = "Araba bilgisi yeterli değil";
        public static string MaintananceTime = "Sistem şu an bakımda";
        public static string CarListed = "Arabalar Listelendi";


        public static string ColorListed = "Renkler listelendi";
        public static string ColorIsInvalid = "Renk bilgileri hatalı";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";


        public static string BrandListed = "Markalar listelendi";
        public static string BrandIsInvalid = "Marka bilgileri hatalı";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";

        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserIsInvalid = "Kullanıcı bilgileri hatalı";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerIsInvalid = "Müşteri bilgileri hatalı";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        
        
        public static string RentListed = "Kiralama Bilgilerilistelendi";
        public static string RentIsInvalid = "Kiralama  bilgileri hatalı";
        public static string RentAdded = "Kiralama Bilgileri eklendi";
        public static string RentDeleted = "Kiralama bilgileri silindi";
        public static string rentUpdated = "Kiralama Bilgileri güncellendi";

        public static string AuthorizationDenied = "yetkiniz Yok";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

        //public static string AuthorizationDenied = "Yetkiniz yok";
        //public static string UserRegistered = "Kayıt oldu";
        //public static string UserNotFound = "Kullanıcı bulunamadı";
        //public static string PasswordError = "Parola hatası";
        //public static string SuccessfulLogin = "Başarılı giriş";
        //public static string UserAlreadyExists = "Kullanıcı mevcut";
        //public static string AccessTokenCreated = "Token oluşturuldu";



    }
}
