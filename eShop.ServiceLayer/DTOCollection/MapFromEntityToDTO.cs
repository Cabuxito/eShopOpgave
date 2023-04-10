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
            ImgPath = x.Images.ImgPath
        });
    }

    public static IQueryable<OrderDTO> ConvertOrdersTOOrdersDTO(this IQueryable<Orders> orders)
    {
        return orders.Select(x => new OrderDTO
        (
            x.OrdersId,
            x.BuyDate,
            x.Products.Sum(x => x.Products.Price),
            new List<Product>(),
            new Customer()
        ));

    }

    public static IQueryable<CustomerDTO> ConvertFromCustomertoDTO(this IQueryable<Customer> customer)
    {
        return customer.Select(x => new CustomerDTO
        (
            x.CustomerID,
            x.Firstname,
            x.Lastname,
            x.Address,
            x.Email,
            x.IsAdmin
        ));
        
    }

}
