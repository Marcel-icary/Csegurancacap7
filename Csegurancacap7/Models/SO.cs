using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csegurancacap7.Models
{
    [Table("T_SO")]
    public class SO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SO")]
        public int Id { get; set; }

        [Column("ID_USER")]
        public int UserId { get; set; }

        [Column("DS_TIPO")]
        public string Type { get; set; } = string.Empty;

        [Column("DS_DESCRICAO")]
        public string? Description { get; set; }

        [Column("ID_ZONE")]
        public int ZoneId { get; set; }

        [Column("DT_FATO")]
        public DateTime FactDate { get; set; }

        [Column("DT_HORA")]
        public DateTime? Hour { get; set; }

        public User User { get; set; } = null!;
        public Zone Zone { get; set; } = null!;
    }
}
