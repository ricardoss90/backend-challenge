using CnabImporter.Domain.Models;
using MediatR;

namespace CnabImporter.Application.Queries.GetStores;

public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, List<Store>>
{
    public async Task<List<Store>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        return [];
    }
}