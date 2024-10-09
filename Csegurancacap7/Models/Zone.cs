using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csegurancacap7.Models
{
    [Table("T_ZONE")]
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ZONE")]
        public int Id { get; set; }

        [Column("NM_ZONE")]
        public string Name { get; set; } = string.Empty;

        [Column("DS_CATEGORIA")]
        public string? Category { get; set; }
    }
}
