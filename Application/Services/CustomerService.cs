using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class CustomerService(IBaseRepository<Customer> customerRepository) : IBaseService<Customer>
{
    public Task<Customer> GetAsync(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> CreateAsync(Customer entity, CancellationToken token = default)
    {
        return await customerRepository.CreateAsync(entity, token);
    }

    public Task<bool> UpdateAsync(Customer entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}