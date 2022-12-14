using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyLetters.Entities
{
    public class ImageRiddle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        [Required]
        [MaxLength(50)]
        public string Answer { get; set; }
        [Required]
        [MaxLength(500)]
        public string ImagePath { get; set; }
    }
}
