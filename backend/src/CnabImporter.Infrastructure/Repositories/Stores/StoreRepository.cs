using CnabImporter.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CnabImporter.Infrastructure.Repositories.Stores;

public class StoreRepository(AppDbContext context) : IStoreRepository
{
    public async Task<List<Store>> GetStoresAsync(int offset, int limit)
    {
        return await context.Stores
            .Include(s => s.Transactions)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Store?> GetByNameAndOwnerAsync(string name, string owner)
    {
        return await context.Stores
            .Include(s => s.Transactions)
            .FirstOrDefaultAsync(s => s.Name == name && s.Owner == owner);
    }

    public async Task AddStoreAsync(Store store)
    {
        await context.Stores.AddAsync(store);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}