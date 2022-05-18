using Domain.Models;

namespace Domain.DTOs.Response;

public record CreateOrderResponse(long Id, List<ProductResponse> Products);