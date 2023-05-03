using eShop.DataLayer.Entities;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace eShop.WebApp.Pages.eShopPages.Admin.CRUD
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductServices _productServices;

        public UpdateProductModel(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [BindProperty, MaxLength(50)]
        public string NewName { get; set; }
        [BindProperty, MaxLength(100)]
        public string NewDescription { get; set; }
        public string NewManufacture { get; set; }
        public double NewPrice { get; set; }
        public int NewStock { get; set; }
        public string NewImage { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<int> NewCategoryIds { get; set; }
        public ProductsDTO Product { get; set; }

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
            Product = new ProductsDTO
            {
                Title = NewName,
                Description = NewDescription,
                Manufacture = NewManufacture,
                Price = NewPrice,
                ImgPath = NewImage,
                Stock = NewStock
            };
            if (Product != null)
            {
                await _productServices.UpdateProductAsync(Product);
                return RedirectToPage("/eShopPage/Admin/AdminPage");
            }
            else
            {
                return Page();
            }
        }
    }
}
