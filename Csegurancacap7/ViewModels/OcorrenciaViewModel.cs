using System;

namespace Csegurancacap7.ViewModels
{
    public class OcorrenciaViewModel
    {
        public int Id { get; set; }
        public int SOId { get; set; }  // "SOId" para ser consistente com o modelo "Ocorrencia"
        public string Status { get; set; } = string.Empty;
        public int ZoneId { get; set; }
        public int? TeamId { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Resolved { get; set; }  // Mantido como bool para a lógica do código
        public string? Observation { get; set; }
    }
}
