using Domain.Entities;

namespace Contracts.Responses;

public record class SingleCategoryResponse
{
    public Guid Id { get; init; }
    public string Name { get; set; }
   
}