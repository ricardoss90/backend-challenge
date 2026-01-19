using CnabImporter.Domain.Models;

namespace CnabImporter.Infrastructure.Repositories.Stores;

public interface IStoreRepository
{
    Task<List<Store>> GetStoresAsync(int offset, int limit);
    Task<Store?> GetByNameAndOwnerAsync(string name, string owner);
    Task AddStoreAsync(Store store);
    Task SaveChangesAsync();
}