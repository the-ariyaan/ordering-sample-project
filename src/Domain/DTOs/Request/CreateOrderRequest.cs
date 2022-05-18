using Domain.DTOs.Response;
using MediatR;

namespace Domain.DTOs.Request;

public record CreateOrderRequest(List<ProductRequest> Products) : IRequest<CreateOrderResponse>;