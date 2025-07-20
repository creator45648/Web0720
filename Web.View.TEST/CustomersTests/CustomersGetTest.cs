using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.API.Client;

namespace Web.View.TEST.CustomersTests;

[TestClass]
public class CustomersGetTest
{
    private Mock<IWebApiClient<string, Customer>> _mockWebApiClient;
    private CustomersController _controller;

    [TestInitialize]
    public void Setup()
    {
        _mockWebApiClient = new Mock<IWebApiClient<string, Customer>>();
        _controller = new CustomersController(_mockWebApiClient.Object);
    }

    [TestMethod]
    public async Task Get_ReturnsOkResult_WithCustomersList()
    {
        // Arrange
        var expectedCustomers = new List<Customer>
        {
            new Customer 
            { 
                CustomerId = "ALFKI", 
                CompanyName = "Alfreds Futterkiste", 
                ContactName = "Maria Anders",
                City = "Berlin"
            },
            new Customer 
            { 
                CustomerId = "ANATR", 
                CompanyName = "Ana Trujillo Emparedados y helados", 
                ContactName = "Ana Trujillo",
                City = "México D.F."
            }
        };

        _mockWebApiClient.Setup(client => client.GetAsync())
                         .ReturnsAsync(expectedCustomers);

        // Act
        var result = await _controller.Get();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        
        var returnedCustomers = okResult.Value as IEnumerable<Customer>;
        Assert.IsNotNull(returnedCustomers);
        Assert.AreEqual(2, returnedCustomers.Count());
    }

    [TestMethod]
    public async Task Get_ReturnsEmptyList_WhenNoCustomers()
    {
        // Arrange
        var emptyCustomersList = new List<Customer>();
        _mockWebApiClient.Setup(client => client.GetAsync())
                         .ReturnsAsync(emptyCustomersList);

        // Act
        var result = await _controller.Get();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        
        var returnedCustomers = okResult.Value as IEnumerable<Customer>;
        Assert.IsNotNull(returnedCustomers);
        Assert.AreEqual(0, returnedCustomers.Count());
    }

    [TestMethod]
    public async Task Get_ReturnsInternalServerError_WhenExceptionThrown()
    {
        // Arrange
        var exceptionMessage = "Database connection failed";
        _mockWebApiClient.Setup(client => client.GetAsync())
                         .ThrowsAsync(new Exception(exceptionMessage));

        // Act
        var result = await _controller.Get();

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        Assert.IsTrue(statusCodeResult.Value?.ToString()?.Contains(exceptionMessage));
    }

    [TestMethod]
    public async Task Get_CallsWebApiClientGetAsync_Once()
    {
        // Arrange
        var customers = new List<Customer>();
        _mockWebApiClient.Setup(client => client.GetAsync())
                         .ReturnsAsync(customers);

        // Act
        await _controller.Get();

        // Assert
        _mockWebApiClient.Verify(client => client.GetAsync(), Times.Once);
    }
}
