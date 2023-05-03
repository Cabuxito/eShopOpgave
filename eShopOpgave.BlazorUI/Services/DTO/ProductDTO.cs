namespace eShopOpgave.BlazorUI.Services.DTO
{

    public class ProductsBase
    {
        public Item[] items { get; set; } = new Item[0];
        public int total { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
    }

    public class Item
    {
        public int masterKey { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int stock { get; set; }
        public string manufacture { get; set; }
        public string imgPath { get; set; }
    }

}
