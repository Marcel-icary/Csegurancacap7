using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Csegurancacap7.Models
{
    [Table("T_OCORRENCIA")] // Define o nome da tabela no banco de dados
    public class Ocorrencia
    {
        [Key] // Define a propriedade como chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Define a geração automática do valor da chave primária
        [Column("ID_OCORRENCIA")] // Mapeia a propriedade para a coluna "ID_OCORRENCIA"
        public int Id { get; set; }

        [Column("ID_SO")]
        public int SOId { get; set; }  // "SOId" para ser consistente com "OcorrenciaViewModel"

        [Column("DS_STATUS")]
        public string Status { get; set; } = string.Empty;

        [Column("ID_ZONE")]
        public int ZoneId { get; set; }

        [Column("ID_TEAM")]
        public int? TeamId { get; set; }

        [Column("DT_SERVICE")]
        public DateTime ServiceDate { get; set; }

        [Column("DT_END")]
        public DateTime? EndDate { get; set; }

        [Column("DS_RESOLVIDO")]
        public int Resolved { get; set; }  // int para representar 0 ou 1 no banco de dados

        [Column("DS_OBSERVACAO")]
        public string? Observation { get; set; }
    }
}
