using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
       public List<Product> productList { get; set; }
        public  IActionResult OnGet()
        {
           
            ProductService ps = new ProductService();
            productList =   ps.GetProducts();
            return Page();
        }
    }
}