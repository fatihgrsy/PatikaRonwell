using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RonvelEFApi.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "Maksimum harf sınırını aştınız.")]
        public string TeacherNameSurname { get; set; }

        public int ClassRoomId { get; set; }
        public virtual ICollection<ClassRoom> ClassRoom { get; set; }
    }
}

