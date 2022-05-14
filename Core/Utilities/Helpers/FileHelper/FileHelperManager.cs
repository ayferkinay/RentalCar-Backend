using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    // ilgili yorum satırları sayfanın sonunda bulunmaktadır.

    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath) // a 
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root) //b
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length>0) //1
            {
                if (!Directory.Exists(root))  //2 
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); //3 
                string guid = GuidHelper.CreateGuid(); // 4
                string filePath = guid + extension; //5 

                using (FileStream fileStream = File.Create(root + filePath)) // 6 

                {
                    file.CopyTo(fileStream); // 7
                    fileStream.Flush(); //8 
                    return filePath; //9
                }
            }
            return null;
        }

     
    }
}



// a: filePath carManager dan gelen dosyanın kaydedildiği adres ve adı. if ile böye bir dosya var mı varsa silsin işlemi yapıyoruz

// b : dosya varsa siler ve yerine upload metodundaki işleme göre yeni ad ve adres belirler

// 1 : file.length : dosya uzunluğunu byte olarak alır. bu if bloğunda dosya göndeirlmiş mi gönderilmemiş mi diye test ediyoruz 

//2: Directory => System.IO'nın bir class'ı.burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte. pathconstants.ıamgespath içinde bir string ifade ile kök dizin içinde yükleyeceğimiz dosyaların adresini oluştruduk. bu if bloğu dosyanın kaydedileceği bir adres dizini var mı? varsa iften çıkar yoksa da bir dizin oluşturur.

//    3 : seçmiş oldupumuz dsoyanın uzantısını elde ediyoruz.

//     4: gerekli bilgi guidHelper da var.
//    5: dosya için oluşturduğumuz guid ile uzantısını bir araya getirerel eşsiz bir isim oluşturduk.
//    6: File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.

//     7: kopyalancak dosyanın akışı belirtildi. yukarıdan gelen IFormFile türündeki dosyanın nreye kopyalancağı belirlendi.
//    8 : arabellekten siler

//     9: db ya dosya eklenirekne adı ile eklenmesi için dosyanın tam adını geri döndürüyoruz.