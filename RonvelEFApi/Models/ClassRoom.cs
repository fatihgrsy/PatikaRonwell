using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RonvelEFApi.Models
{
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "Maksimum harf sınırını aştınız."), MinLength(10, ErrorMessage = "Minumum 10 karakter girmelisiniz.")]
        public string ClassRoomName { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}