using CnabImporter.Domain.Models;
using CnabImporter.Infrastructure.Repositories.Stores;
using MediatR;

namespace CnabImporter.Application.Queries.GetStores;

public class GetStoresQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetStoresQuery, List<Store>>
{
    public async Task<List<Store>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        var stores = await storeRepository.GetStoresAsync(request.Offset, request.Limit);
        return stores;
    }
}
