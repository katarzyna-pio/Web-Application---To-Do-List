using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nowa_aplikacja.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]

        public int TaskId { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [MaxLengthAttribute(50)]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [MaxLength(2000)]
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}



