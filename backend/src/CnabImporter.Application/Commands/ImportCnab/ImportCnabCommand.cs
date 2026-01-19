using MediatR;

namespace CnabImporter.Application.Commands.ImportCnab;

public record ImportCnabCommand(string FileContent, string FileName) : IRequest<bool>;