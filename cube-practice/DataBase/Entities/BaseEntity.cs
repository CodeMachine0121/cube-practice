using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cube_practice.DataBase.Entities;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public DateTime CreatedOn { get; set; }

    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; }
}