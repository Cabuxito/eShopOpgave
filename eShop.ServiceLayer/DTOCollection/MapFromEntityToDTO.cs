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
            ImgPath = x.Image.ImgPath,
            Price = x.Price,
            Stock = x.Stock
            
        });
    }

    public static IQueryable<OrderDTO> ConvertOrdersTOOrdersDTO(this IQueryable<Orders> orders)
    {
        return orders.Select(x => new OrderDTO
        (
            x.OrdersId,
            x.BuyDate,
            x.Products.Sum(x => x.Products.Price),
            new List<ProductsDTO>(),
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
            x.ZipCode.ZipCodeId,
            x.Email,
            x.Address,
            x.IsAdmin,
            x.Password
        ));
        
    }

    public static ProductsDTO ConvertProductsToProductsDTO(this Product product)
    {
        return new ProductsDTO
        {
            MasterKey = product.ProductId,
            Title = product.Title,
            Description = product.Description,
            Manufacture = product.Manufacture,
            ImgPath = product.Image.ImgPath,
            Price = product.Price,
            Stock = product.Stock

        };
    }

}
