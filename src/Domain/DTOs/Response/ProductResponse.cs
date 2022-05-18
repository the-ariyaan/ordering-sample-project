namespace Domain.DTOs.Response;

public record ProductResponse(long Id, string ProductTypeTitle, int Quantity)
{
    public ProductResponse() : this(0L, string.Empty, 0)
    {
    }
};