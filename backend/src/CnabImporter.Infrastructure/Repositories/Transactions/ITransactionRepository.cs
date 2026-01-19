namespace CnabImporter.Infrastructure.Repositories.Transactions;

public interface ITransactionRepository
{
    Task AddTransactionAsync(Domain.Models.Transaction transaction);
    Task SaveChangesAsync();
}