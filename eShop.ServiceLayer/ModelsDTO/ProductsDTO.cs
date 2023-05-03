using eShop.DataLayer.Entities;

namespace eShop.ServiceLayer.ModelsDTO
{
    public class ProductsDTO
    {
        public int MasterKey { get; set; } // PK
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Manufacture { get; set; }
        public string ImgPath { get; set; }
    }

    public class CategoryDTO
    {
        public string Name { get; set; }
    }
}
