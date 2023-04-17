using eShop.DataLayer.Entities;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace eShop.WebApp.Pages.eShopPages.Admin.CRUD
{
    
    public class CreateProductModel : PageModel
    {
        private readonly IProductServices _productServices;

        public CreateProductModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [BindProperty, MaxLength(50)]
        public string ProductName { get; set; }
        [BindProperty, MaxLength(100)]
        public string ProductDescription { get; set; }
        [BindProperty]
        public string Manufacture { get; set; }
        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public int Stock { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }
        [BindProperty]
        public List<SelectListItem> Categories { get; set; }
        [BindProperty]
        public List<int> CategoryIds { get; set; }

        public async Task OnGet()
        {
            Task<List<Category>> categories = _productServices.GetAllCategories();

            Categories = categories.Result.Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.Name,
            }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            string path = $@"~\eShop.WebApp\wwwroot\Images\{Image.FileName}";
            List<Category> cat = new List<Category>();
            Categories.ForEach(x => cat.Add(new Category { CategoryId = int.Parse(x.Value) }));
            ProductsDTO newProduct = new ProductsDTO
            {
                Title = ProductName,
                Description = ProductDescription,
                Manufacture = Manufacture,
                Price = Price,
                ImgPath = path,
                Stock = Stock,
                Categories = CategoryIds.Select(x => new Category { CategoryId = x }).ToList(),
            };
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }

            if (newProduct != null )
            {
                await _productServices.AddProductAsync(newProduct);
                return RedirectToPage("/eShopPages/Admin/AdminPage");
            }
            else
            {
                return Page();
            }

            
        }
    }
}
