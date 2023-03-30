using eShop.ServiceLayer.Services;
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

    [Fact]
    public void GetAllProducts()
    {
        var _context = ContextCreater.CreateContext();
        var _service = new ProductServices(_context);
        //Arrange
        _context.Products.Add(new Product
        {
            Title = "Test",
            Description = "Test",
            Price = 22,
            Stock = 1,
            Manufacture = "asdasd"
        });
        _context.SaveChanges();    
        //Act

        var list = _service.GetAllProducts().Count();

        //Assert

        Assert.Equal(list, 1);

    }

}