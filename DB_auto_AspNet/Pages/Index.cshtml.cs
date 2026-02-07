using DB_auto_AspNet.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DB_auto_AspNet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<IndexModel> _logger;


        public List<Vehicle> Vehicles { get; private set; } = new();
        public IndexModel(ApplicationContext context, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            _context.Database.EnsureCreated();
            if (!_context.Vehicles.Any())
            {
                SeedData.Initialize(_context);
            }
            Vehicles = _context.Vehicles.AsNoTracking().ToList();
        }
    }
}
