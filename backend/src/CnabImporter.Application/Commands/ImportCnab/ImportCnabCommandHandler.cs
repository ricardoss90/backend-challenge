using System.Globalization;
using CnabImporter.Domain.Models;
using CnabImporter.Infrastructure.Repositories.Stores;
using CnabImporter.Infrastructure.Repositories.Transactions;
using MediatR;

namespace CnabImporter.Application.Commands.ImportCnab;

public class ImportCnabCommandHandler(
    IStoreRepository storeRepository,
    ITransactionRepository transactionRepository)
    : IRequestHandler<ImportCnabCommand, bool>
{
    public async Task<bool> Handle(ImportCnabCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.FileContent))
            return false;

        var lines = request.FileContent.Split(
            ["\r\n", "\r", "\n"],
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (var line in lines)
        {
            if (line.Length < 81)
                continue; // skip invalid lines

            try
            {
                // Parse fixed-width fields
                int type = int.Parse(line.Substring(0, 1));
                var dateStr = line.Substring(1, 8); // YYYYMMDD
                var valueStr = line.Substring(9, 10); // 10 digits
                var cpf = line.Substring(19, 11).Trim();
                var card = line.Substring(30, 12).Trim();
                var timeStr = line.Substring(42, 6); // HHMMSS
                var owner = line.Substring(48, 14).Trim();
                var storeName = line.Substring(62, 19).Trim();

                // Parse date and time
                var date = DateTime.ParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture);
                var time = TimeSpan.ParseExact(timeStr, "hhmmss", CultureInfo.InvariantCulture);
                var dateTime = date.Add(time);

                // Parse value
                var value = decimal.Parse(valueStr) / 100m;

                // Check if store exists
                var store = await storeRepository.GetByNameAndOwnerAsync(storeName, owner);
                if (store == null)
                {
                    store = new Store
                    {
                        Name = storeName,
                        Owner = owner
                    };
                    await storeRepository.AddStoreAsync(store);
                    await storeRepository.SaveChangesAsync();
                }

                // Create transaction
                var transaction = new Transaction
                {
                    StoreId = store.Id,
                    TransactionType = type,
                    Date = dateTime,
                    Cpf = cpf,
                    Card = card,
                    Value = value
                };

                await transactionRepository.AddTransactionAsync(transaction);
            }
            catch(Exception e)
            {
                // skip invalid line, could also log errors
                continue;
            }
        }

        // Save all transactions at the end
        await transactionRepository.SaveChangesAsync();

        return true;
    }
}