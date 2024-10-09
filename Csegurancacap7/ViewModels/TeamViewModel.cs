namespace Csegurancacap7.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Specialty { get; set; } = string.Empty;
        public int Availability { get; set; }
        public int ZoneId { get; set; }
    }
}
