using Domain.Entities;

namespace Contracts.Requests;

public record class UpdateCategoryRequest
{
    public string Name { get; set; }
}