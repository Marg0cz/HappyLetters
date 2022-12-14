using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyLetters.Entities;

public class LetterRiddle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Guid { get; set; }
    [Required]
    [MaxLength(50)]
    public string Content { get; set; }
    [Required]
    [MaxLength(50)]
    public string Solution { get; set; }
}
