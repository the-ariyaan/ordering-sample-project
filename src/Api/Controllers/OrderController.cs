using Domain.DTOs.Request;
using Domain.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<CreateOrderResponse> Create(CreateOrderRequest request)
    {
        var response = await _mediator.Send(request);
        return response;
    }

    [HttpGet]
    public async Task<ActionResult<GetOrderResponse>> Get([FromQuery] GetOrderRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}