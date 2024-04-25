using Domain.Entities;

namespace Contracts.Requests;

public record class GetAllCategoryRequest
{
    public IEnumerable<Category> Items { get; init; } = Enumerable.Empty<Category>();

}