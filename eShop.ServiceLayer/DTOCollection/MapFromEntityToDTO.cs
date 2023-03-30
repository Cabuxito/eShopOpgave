﻿using eShop.DataLayer.Entities;
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
            Categories = x.Categories
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

    public static IQueryable<CustomerDTO> ConvertFromCustomertoDTO(this IQueryable<Customer> customer)
    {
        return customer.Select(x => new CustomerDTO
        (
            x.CustomerID,
            x.Firstname,
            x.Lastname,
            x.Address,
            x.Email
        ));
        
    }

}
