using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class CategoryService (IBaseRepository<Category> CategoryRepository) : IBaseService<Category>
{   
    public async Task<Category> CreateAsync(Category building, CancellationToken token = default)
    {
        return await CategoryRepository.CreateAsync(building, token);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        var building = await CategoryRepository.GetAsync(id, token);

        if (building == null)
            return false;

        return await CategoryRepository.DeleteAsync(building, token);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken token = default)
    {
        return await CategoryRepository.GetAllAsync(token);
    }

    public async Task<Category> GetAsync(Guid id, CancellationToken token = default)
    {
        return await CategoryRepository.GetAsync(id, token);
    }

    public async Task<bool> UpdateAsync(Category building, CancellationToken token = default)
    {
        var buildingExist = await CategoryRepository.GetAsync(building.Id, token);

        if (buildingExist == null)
        {
            return false;
        }

        return await CategoryRepository.UpdateAsync(building, token);
    }
}