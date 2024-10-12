using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Frameworks;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPITests;

public class ProductControllerTests
{
    private readonly Mock<IProductServices> _mock;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mock = new Mock<IProductServices>();
        _controller = new ProductController(_mock.Object);
    }

    private static List<Product> GetTestProducts()
    {
        return new List<Product>
        {

            new Product {ProductId = 1, ProductName = "Hammer", Price = 76.0m},
            new Product {ProductId = 2, ProductName = "Water Bottle", Price = 30.0m},
            new Product {ProductId = 3, ProductName = "Keyboard", Price = 1299.90m}
        };
    }

    // GET
    [Fact]
    public async Task GetAll_ReturnsCorrectType()
    {
        //Arrange
        _mock.Setup(service => service.GetAll()).ReturnsAsync(GetTestProducts);

        //Act
        var result = await _controller.GetAll();

        //Assert
        Assert.IsType<List<Product>>(result);
        if (result != null) Assert.Equal(3, result.Count);

    }

    [Fact]
    public async Task Get_Specific_Id()
    {
        var specificId = 1;

        var product = GetTestProducts().ElementAt(0);
        _mock.Setup(service => service.Get(specificId)).ReturnsAsync(product);

        var result = await _controller.Get(specificId) as OkObjectResult;

        Assert.NotNull(result);
        if (result != null) Assert.Equal(product, result.Value);
    }


    [Fact]
    public async void Get_ReturnNotFound_WhenProductDoesNotExist()
    {
        var specificId = 5;

        _mock.Setup(service => service.Get(specificId)).ReturnsAsync((Product)null);

        //act
        var result = await _controller.Get(specificId);

        //ASSERT
        if(result != null) Assert.IsType<NotFoundObjectResult>(result);
        else Assert.NotNull(result);
    }

    [Fact]
    public async Task Delete_ReturnOK_WhenProductExists()
    {
        var specificId = 2;
        var product = new Product { ProductId = specificId, ProductName = "Water Bottle", Price = 30.0m };

        _mock.Setup(service => service.Get(specificId)).ReturnsAsync(product);
        _mock.Setup(service => service.Delete(specificId));

        var result = await _controller.Delete(specificId) as OkObjectResult;

        Assert.NotNull(result);
        if(result != null) Assert.Equal("Product 2 - Water Bottle deleted successfully.", result.Value);
    }

    [Fact]
    public async Task Delete_ReturnNotFound_WhenProductDoesNotExist()
    {
        var specificId = 5;
        _mock.Setup(service => service.Get(specificId)).ReturnsAsync((Product)null);

        var result = await _controller.Delete(specificId);

        Assert.IsType<NotFoundObjectResult>(result);
    }

    

}

