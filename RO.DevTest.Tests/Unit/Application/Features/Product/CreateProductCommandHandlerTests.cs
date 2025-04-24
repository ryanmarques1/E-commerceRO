using FluentAssertions;
using Moq;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Domain.Exception;
using Xunit;

namespace RO.DevTest.Tests.Unit.Application.Features.Product.Commands;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IProductRepository> _repositoryMock = new();
    private readonly CreateProductCommandHandler _sut;

    public CreateProductCommandHandlerTests()
    {
        _sut = new CreateProductCommandHandler(_repositoryMock.Object);
    }

    [Fact(DisplayName = "Given valid data should create a product and return result")]
    public async Task Handle_WhenDataIsValid_ShouldCreateProduct()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            nameProd = "Laptop",
            descriptionProd = "High-end gaming laptop",
            priceProd = 999.99M,
            quantityStock = 10
        };

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.nameProd.Should().Be("Laptop");
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<RO.DevTest.Domain.Entities.Product>()), Times.Once);
    }

    [Fact(DisplayName = "Given empty product name should throw BadRequestException")]
    public void Handle_WhenNameIsEmpty_ShouldThrowBadRequestException()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            nameProd = "",
            descriptionProd = "Description",
            priceProd = 100,
            quantityStock = 5
        };

        // Act
        Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<BadRequestException>();
    }
}
