using CnabImporter.Domain.Models;
using MediatR;

namespace CnabImporter.Application.Queries.GetStores;

public record GetStoresQuery(int Offset = 0, int Limit = 10) : PaginationQuery(Offset, Limit), IRequest<List<Store>>;
