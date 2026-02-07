using System.ComponentModel.DataAnnotations;

namespace DB_auto_AspNet.Pages.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Тип транспорта обязателен")]
        [StringLength(10, ErrorMessage = "Тип не должен превышать 10 символов")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Бренд обязателен")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Бренд должен быть от 2 до 50 символов")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Модель обязательна")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Модель должна быть от 1 до 100 символов")]
        public string Model { get; set; } = string.Empty;

        [Range(1995, 2026, ErrorMessage = "Год должен быть между 1995 и 2026")]
        public int Year { get; set; }

        [Range(1000, 10_000_000, ErrorMessage = "Цена должна быть от 15 000 до 10 000 000 ₽")]
        public decimal Price { get; set; }
    }
}
