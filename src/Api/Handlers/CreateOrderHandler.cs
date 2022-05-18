using AutoMapper;
using Domain.Contracts.Repository;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Entities;
using MediatR;

namespace Api.Handlers;

/// <summary>
/// <see cref="CreateOrderHandler"/> handler, handles order creation
/// </summary>
public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var newOrder = _mapper.Map<OrderEntity>(request);
        var addedOrder = await _orderRepository.CreateAsync(newOrder, cancellationToken);
        return _mapper.Map<CreateOrderResponse>(addedOrder);
    }
}