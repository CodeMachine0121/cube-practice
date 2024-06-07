using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cube_practice.DataBase.Entities;

public class BaseEntity
{
    public virtual DateTime CreatedOn { get; set; }

    [Required]
    [StringLength(50)]
    public virtual string CreatedBy { get; set; }
}

public class BaseEntityIntId: BaseEntity
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; set; }

}