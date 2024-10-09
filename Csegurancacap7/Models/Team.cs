using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csegurancacap7.Models
{
    [Table("T_TEAM")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_TEAM")]
        public int Id { get; set; }

        [Column("NM_TEAM")]
        public string Name { get; set; } = string.Empty;

        [Column("NM_QTD")]
        public int Quantity { get; set; }

        [Column("DS_ESPECIALIDADE")]
        public string Specialty { get; set; } = string.Empty;

        [Column("NM_DISPONIBILIDADE")]
        public int Availability { get; set; }

        [Column("ID_ZONE")]
        public int ZoneId { get; set; }
    }
}
