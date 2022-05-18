using Api.Exceptions;
using AutoMapper;
using Domain.Contracts.Repository;
using Domain.DTOs.Request;
using Domain.DTOs.Response;
using Domain.Entities;
using Domain.Models;
using Domain.ValueObjects;
using MediatR;

namespace Api.Handlers;

/// <summary>
/// <see cref="GetOrderRequest"/> handler, handles getting order information including packaging of order 
/// </summary>
public class GetOrderHandler : IRequestHandler<GetOrderRequest, GetOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderResponse> Handle(GetOrderRequest request, CancellationToken cancellationToken)
    {
        var orderEntity = await _orderRepository.GetAsync(request.Id, cancellationToken);
        if (orderEntity is null)
            throw new NotFoundException<OrderEntity, Id>(request.Id);

        var order = _mapper.Map<Order>(orderEntity);
        var response = _mapper.Map<GetOrderResponse>(order);
        return response;
    }
}