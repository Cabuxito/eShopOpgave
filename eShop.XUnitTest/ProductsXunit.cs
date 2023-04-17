using eShop.ServiceLayer.DTOCollection;
using eShop.ServiceLayer.ModelsDTO;
using eShop.ServiceLayer.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace eShop.XUnitTest;

public class ProductsXunit
{
    [Fact]
    public async Task TestCreateProduct()
    {
        var _context = ContextCreater.CreateContext();
        var _service = new ProductServices(_context);
        //Arrange
        ProductsDTO productsDTO = new ProductsDTO
        {
            MasterKey = 1,
            Title = "Test",
            Description = "Test",
            Price = 22,
            Stock = 1,
            Manufacture = "asdasd"
        };

        //Act

        await _service.AddProductAsync(productsDTO);

        //Assert
        var actualProduct = _context.Products.ToList().Last();

        Assert.Equal(productsDTO.Title, actualProduct.Title);
        Assert.Equal(productsDTO.Description, actualProduct.Description);

    }

    //[Fact]
    //public void TestGetProducts()
    //{
    //    var _context = ContextCreater.CreateContext();
    //    var _service = new ProductServices(_context);
    //    //Arrange
    //    _context.Product.Add(new Product
    //    {
    //        Title = "Test",
    //        Description = "Test",
    //        Price = 22,
    //        Stock = 1,
    //        Manufacture = "asdasd"
    //    });
    //    _context.SaveChanges();    
    //    //Act

    //    var list = _service.GetAllProducts().Count();

    //    //Assert

    //    Assert.Equal(list, 1);

    //}

    [Fact]
    public void TestSearchProductByWord()
    {
        var _context = ContextCreater.CreateContext();
        var _service = new ProductServices(_context);
        //Arrange
        _context.Products.Add(new Product
        {
            Title = "test",
            Description = "Test",
            Price = 22,
            Stock = 1,
            Manufacture = "asdasd"
        });
        _context.Products.Add(new Product
        {
            Title = "test2",
            Description = "Test2",
            Price = 22,
            Stock = 1,
            Manufacture = "asdasd222"
        });
        _context.SaveChanges();
        //Act

        var products = _service.SearchProductByWord("test").First();

        //Assert

        Assert.Equal("test", products.Title);
    }

    //[Fact]
    //public async Task TestDeleteProduct()
    //{
    //    var _context = ContextCreater.CreateContext();
    //    var _service = new ProductServices(_context);
    //    //Arrange
    //    _context.Product.Add(new Product
    //    {
    //        Title = "test",
    //        Description = "Test",
    //        Price = 22,
    //        Stock = 1,
    //        Manufacture = "asdasd"
    //    });
    //    var product = new ProductsDTO
    //    {
    //        Title = "test",
    //        Description = "Test",
    //        Price = 22,
    //        Stock = 1,
    //        Manufacture = "asdasd"
    //    };
    //    _context.SaveChanges();
    //    //Act

    //    await _service.DeleteProductAsync(1);

    //    //Assert
    //    var products = _service.GetAllProducts();

    //    Assert.Empty(products);
    //}

    [Fact]
    public async Task TestUpdateProduct()
    {
        var _context = ContextCreater.CreateContext();
        var _myContext = ContextCreater.CreateContext();
        var _service = new ProductServices(_context);
        //Arrange
        ProductsDTO productsDTO = new ProductsDTO
        {
            MasterKey = 1,
            Title = "Test",
            Description = "Test",
            Price = 22,
            Stock = 1,
            Manufacture = "asdasd"

        };
        _myContext.Products.Add(productsDTO.ConvertFromDTOtoProduct());
        await _myContext.SaveChangesAsync();

        productsDTO.Description = "ITS WORKIIIING";
        productsDTO.Stock = 421;
        //Act

        await _service.UpdateProductAsync(productsDTO);

        //Assert
        var actualProduct = _myContext.Products.AsNoTracking().First();

        Assert.Equal(productsDTO.Stock, actualProduct.Stock);
        Assert.Equal(productsDTO.Description, actualProduct.Description);
    }
}