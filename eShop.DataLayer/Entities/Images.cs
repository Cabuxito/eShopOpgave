namespace eShop.DataLayer.Entities
{
    public class Images
    {
        public int ImagesId { get; set; } // PK
        public string DefaultText { get; set; }
        public string ImgPath { get; set; }

        public int ProductId { get; set; } // FK
        public Product Products { get; set; }
    }
}
