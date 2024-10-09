namespace Csegurancacap7.Models
{
    public class Auditoria
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Availability { get; set; }
        public int ZoneId { get; set; }
        public DateTime ActionTimestamp { get; set; }
    }
}
