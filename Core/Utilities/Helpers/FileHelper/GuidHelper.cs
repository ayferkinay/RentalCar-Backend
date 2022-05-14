using System;

namespace Core.Utilities.Helpers.FileHelper
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
            
            //yüklenen dosya için yeni bir isim oluşturduk ve onu tostrin ile stringe çevirdik
        }
    }
}