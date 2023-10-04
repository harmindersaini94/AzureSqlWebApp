using AzureSqlWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureSqlWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Product;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ProductController cntrllr = new ProductController();
            Product = cntrllr.GetProducts();

        }
    }
}