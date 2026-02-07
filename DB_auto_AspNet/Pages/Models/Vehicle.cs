namespace DB_auto_AspNet.Pages.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; 
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}
