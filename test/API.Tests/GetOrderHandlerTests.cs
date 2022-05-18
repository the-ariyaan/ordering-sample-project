using System.Collections.ObjectModel;
using Api;
using Api.Exceptions;
using Api.Handlers;
using AutoMapper;
using Core.EntityFramework.Entity;
using Domain.Contracts.Repository;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Entities;
using Domain.ValueObjects;
using Moq;

namespace API.Tests;

public class GetOrderHandlerTests
{
    private readonly Mock<IOrderRepository> _orderRepository = new();
    private readonly IMapper _mockMapper;

    public GetOrderHandlerTests()
    {
        //AutoMapper configuration
        var mockMapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mockMapper = mockMapperConfiguration.CreateMapper();
    }

    [Fact]
    public async Task Throw_Exception_If_The_Order_Id_Is_Not_Valid()
    {
        // arrange
        const long orderId = 100L;
        OrderEntity order = null!;
        _orderRepository
            .Setup(r => r.GetAsync(orderId, It.IsAny<CancellationToken>()))!
            .ReturnsAsync(order);

        var request = new GetOrderRequest(orderId);
        var handler = new GetOrderHandler(_orderRepository.Object, _mockMapper);

        // act
        async Task<GetOrderResponse> Action() => await handler.Handle(request, default);

        // assert
        await Assert.ThrowsAsync<NotFoundException<OrderEntity, Id>>((Func<Task<GetOrderResponse>>) Action);
    }

    [Fact]
    public async Task Get_Order_By_Id_Should_Return_The_Requested_Order()
    {
        // arrange
        const long orderId = 1L, productTypeId = 1L, productId = 1L;
        const int quantity = 3, stackSize = 1;
        const float productTypeWidth = 94.0F;
        const string productName = "Mug";
        var now = DateTime.Now;
        var productType = new ProductTypeEntity
        {
            Id = productTypeId,
            Title = productName,
            Width = productTypeWidth,
            StackSize = stackSize,
            EntityState = TrackingState.Unchanged
        };
        var products = new Collection<ProductEntity>
        {
            new()
            {
                Id = productId,
                OrderId = orderId,
                Quantity = quantity,
                ProductTypeId = productTypeId,
                ProductType = productType,
                EntityState = TrackingState.Unchanged
            }
        };
        var order = new OrderEntity
        {
            Id = orderId,
            Products = products,
            CreationDateTime = now,
            EntityState = TrackingState.Unchanged
        };

        _orderRepository
            .Setup(repository => repository.GetAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);


        var request = new GetOrderRequest(Id: orderId);
        var expected = new GetOrderResponse(Id: orderId,
            Products: new List<ProductResponse> {new(productId, productName, quantity)}, productTypeWidth * quantity);

        var handler = new GetOrderHandler(_orderRepository.Object, _mockMapper);

        // act
        var actual = await handler.Handle(request, default);

        // assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.RequiredBinWidth, actual.RequiredBinWidth);
    }

    [Fact]
    public async Task Get_Order_By_Id_Should_Return_Correct_Packaging_According_To_StackSize()
    {
        // arrange
        const long orderId = 1L, productTypeId = 1L, productId = 1L;
        const int quantity = 3, stackSize = 2;
        // Line below calculates the items that could be in a package
        var packageItemsCount = (int) Math.Ceiling((float) quantity / stackSize);
        const float productTypeWidth = 94.0F;
        const string productName = "Pen";
        var now = DateTime.Now;
        var productType = new ProductTypeEntity
        {
            Id = productTypeId,
            Title = productName,
            Width = productTypeWidth,
            StackSize = stackSize,
            EntityState = TrackingState.Unchanged
        };
        var products = new Collection<ProductEntity>
        {
            new()
            {
                Id = productId,
                OrderId = orderId,
                Quantity = quantity,
                ProductTypeId = productTypeId,
                ProductType = productType,
                EntityState = TrackingState.Unchanged
            }
        };
        var order = new OrderEntity
        {
            Id = orderId,
            Products = products,
            CreationDateTime = now,
            EntityState = TrackingState.Unchanged
        };

        _orderRepository
            .Setup(repository => repository.GetAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);


        var request = new GetOrderRequest(Id: orderId);
        var expected = new GetOrderResponse(Id: orderId,
            Products: new List<ProductResponse> {new(productId, productName, quantity)},
            productTypeWidth * packageItemsCount);

        var handler = new GetOrderHandler(_orderRepository.Object, _mockMapper);

        // act
        var actual = await handler.Handle(request, default);

        // assert
        Assert.Equal(expected.RequiredBinWidth, actual.RequiredBinWidth);
    }
}