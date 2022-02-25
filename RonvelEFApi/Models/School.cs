using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RonvelEFApi.Models
{
    public class School
    {
        //PK
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200,ErrorMessage ="Maksimum harf sınırını aştınız."),MinLength(3,ErrorMessage ="Minumum 20 karakter girmelisiniz.")]
        public string SchoolName { get; set; }


        [MaxLength(201, ErrorMessage = "Maksimum harf sınırını aştınız."), MinLength(3, ErrorMessage = "Minumum 20 karakter girmelisiniz.")]
        public string SchoolAdress { get; set; }
    }
}


/*
 * 
Okul Bilgisi - 1 den fazla olabilir
Derslik Bilgisi - her okula özgü olmalı
Öğretmen Bilgisi - he okula özgü olmalı - Dersliğe de özgü olmalı
Öğrenci Bilgisi - birden fazla ders alacak

 
 */