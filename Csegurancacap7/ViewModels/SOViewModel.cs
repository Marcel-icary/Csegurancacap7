namespace Csegurancacap7.ViewModels
{
    public class SOViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ZoneId { get; set; }
        public DateTime FactDate { get; set; }
        public DateTime? Hour { get; set; }
    }
}
