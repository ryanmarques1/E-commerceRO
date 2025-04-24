using FluentAssertions;
using Moq;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Application.Contracts.Persistence.Repositories;
using RO.DevTest.Application.Features.Sale.Commands.CreateSaleCommand;
using RO.DevTest.Domain.Entities;
using Xunit;

namespace RO.DevTest.Tests.Unit.Application.Features.Sale.Commands;

public class CreateSaleCommandHandlerTests
{
    private readonly Mock<ISaleRepository> _saleRepositoryMock = new();
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly Mock<IProductRepository> _productRepositoryMock = new();
    private readonly CreateSaleCommandHandler _sut;

    public CreateSaleCommandHandlerTests()
    {
        _sut = new CreateSaleCommandHandler(
            _saleRepositoryMock.Object,
            _userRepositoryMock.Object,
            _productRepositoryMock.Object
        );
    }

    [Fact(DisplayName = "Given valid data should create a sale and return result")]
    public async Task Handle_WhenDataIsValid_ShouldCreateSale()
    {
        // Arrange
        var userId = Guid.NewGuid().ToString();
        var productId = Guid.NewGuid();

        _userRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new RO.DevTest.Domain.Entities.User());

        _productRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new RO.DevTest.Domain.Entities.Product());

        var command = new CreateSaleCommand
        {
            IdUser = userId,
            Items = new List<CreateItemSaleDto>
            {
                new() { ProductId = productId, QuantitySale = 2 }
            }
        };

        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.IdSale.Should().NotBeEmpty();
        _saleRepositoryMock.Verify(r => r.AddAsync(It.IsAny<RO.DevTest.Domain.Entities.Sale>()), Times.Once);
    }

    [Fact(DisplayName = "Given empty user ID should throw ArgumentNullException")]
    public void Handle_WhenUserIdIsEmpty_ShouldThrowArgumentNullException()
    {
        var command = new CreateSaleCommand
        {
            IdUser = "",
            Items = new List<CreateItemSaleDto>()
        };

        Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact(DisplayName = "Given non-existing user should throw Exception")]
    public void Handle_WhenUserNotFound_ShouldThrowException()
    {
        _userRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((RO.DevTest.Domain.Entities.User?)null);

        var command = new CreateSaleCommand
        {
            IdUser = Guid.NewGuid().ToString(),
            Items = new List<CreateItemSaleDto>()
        };

        Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

        act.Should().ThrowAsync<Exception>().WithMessage("Usuário não encontrado.");
    }

    [Fact(DisplayName = "Given non-existing product should throw Exception")]
    public void Handle_WhenProductNotFound_ShouldThrowException()
    {
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();

        _userRepositoryMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(new RO.DevTest.Domain.Entities.User());

        _productRepositoryMock.Setup(r => r.GetByIdAsync(productId))
            .ReturnsAsync((RO.DevTest.Domain.Entities.Product?)null);

        var command = new CreateSaleCommand
        {
            IdUser = userId.ToString(),
            Items = new List<CreateItemSaleDto>
            {
                new() { ProductId = productId, QuantitySale = 1 }
            }
        };

        Func<Task> act = async () => await _sut.Handle(command, CancellationToken.None);

        act.Should().ThrowAsync<Exception>().WithMessage($"O Produto com ID {productId} não existe.");
    }
}
