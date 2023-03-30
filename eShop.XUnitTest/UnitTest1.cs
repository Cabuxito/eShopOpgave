using eShop.ServiceLayer.Services;
using System.Collections.Immutable;

namespace eShop.XUnitTest;

public class UnitTest1
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
}