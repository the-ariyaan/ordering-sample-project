using Domain.DTOs.Response;
using MediatR;

namespace Domain.DTOs.Request;

public record GetOrderRequest(long Id) : IRequest<GetOrderResponse>;