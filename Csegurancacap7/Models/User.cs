using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csegurancacap7.Models
{
    [Table("T_USER")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que o valor é gerado pelo banco de dados
        [Column("ID_USER")]
        public int Id { get; set; }

        [Column("NM_USER")]
        public string Name { get; set; } = string.Empty;

        [Column("DS_EMAIL")]
        public string Email { get; set; } = string.Empty;

        [Column("DS_SENHA")]
        public string Password { get; set; } = string.Empty;

        [Column("DS_TELEFONE")]
        public string? PhoneNumber { get; set; } // Campo nullable

        [Column("DT_CRIACAO")]
        public DateTime CreatedAt { get; set; }
    }
}
