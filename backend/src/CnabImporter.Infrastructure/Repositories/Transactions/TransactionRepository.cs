using CnabImporter.Domain.Models;

namespace CnabImporter.Infrastructure.Repositories.Transactions;

public class TransactionRepository(AppDbContext context) : ITransactionRepository
{
    public async Task AddTransactionAsync(Transaction transaction)
    {
        await context.Transactions.AddAsync(transaction);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}