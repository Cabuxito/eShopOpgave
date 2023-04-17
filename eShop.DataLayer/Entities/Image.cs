namespace eShop.DataLayer.Entities
{
    public class Image
    {
        public int ImageId { get; set; } // PK
        public string DefaultText { get; set; } = "Image Not Load";
        public string ImgPath { get; set; }

        public Product Product { get; set; }
    }
}
