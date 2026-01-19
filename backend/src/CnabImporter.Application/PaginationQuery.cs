namespace CnabImporter.Application;

public abstract record PaginationQuery(int Offset, int Limit);