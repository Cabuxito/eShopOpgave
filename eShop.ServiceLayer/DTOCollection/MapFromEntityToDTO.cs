using eShop.DataLayer.Entities;
using eShop.ServiceLayer.ModelsDTO;


namespace eShop.ServiceLayer.DTOCollection;

public static class MapFromEntityToDTO
{
    public static IQueryable<ProductsDTO> ConvertProductsToProductsDTO(this IQueryable<Product> product)
    {
        return product.Select(x => new ProductsDTO
        {
            MasterKey = x.ProductId,
            Title = x.Title,
            Description = x.Description,
            Manufacture = x.Manufacture,
            Categories = (ICollection<string>)x.Categories
        });
    }

    public static IQueryable<OrderProductsDTO> ConvertOrdersTOOrdersDTO(this IQueryable<Orders> orders)
    {
        return orders.Select(x => new OrderProductsDTO
        (
            x.OrdersId,
            x.BuyDate,
            2,
            new List<Product>()
            //x.Products.Sum(p => p.Price),
            //x.Products.ToList()
        ));

    }

}
