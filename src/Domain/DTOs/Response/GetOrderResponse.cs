using Domain.DTOs.Request;

namespace Domain.DTOs.Response;

public record GetOrderResponse(long Id, IEnumerable<ProductResponse> Products, float RequiredBinWidth);