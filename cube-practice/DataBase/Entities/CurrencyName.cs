using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cube_practice.DataBase.Entities;

[Table("CurrencyName")]
public class CurrencyName: BaseEntityIntId
{
    [Required]
    [StringLength(3)]
    public string Code { get; set; }
    
    [Required]
    public string ChineseName { get; set; }
}