using MediatR;

namespace CnabImporter.Application.Commands.ImportCnab;

public class ImportCnabCommandHandler : IRequestHandler<ImportCnabCommand, bool>
{
    public async Task<bool> Handle(ImportCnabCommand request, CancellationToken cancellationToken)
    {
        return true;
    }
}