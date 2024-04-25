namespace Contracts.Responses;

public record class GetAllCategoryResponse
{
    public IEnumerable<SingleCategoryResponse> Items { get; init; } = Enumerable.Empty<SingleCategoryResponse>();
}