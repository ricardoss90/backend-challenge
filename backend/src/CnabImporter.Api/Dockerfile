# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all project files
COPY ./src/CnabImporter.Api/CnabImporter.Api.csproj ./CnabImporter.Api/
COPY ./src/CnabImporter.Application/CnabImporter.Application.csproj ./CnabImporter.Application/
COPY ./src/CnabImporter.Infrastructure/CnabImporter.Infrastructure.csproj ./CnabImporter.Infrastructure/
COPY ./src/CnabImporter.Domain/CnabImporter.Domain.csproj ./CnabImporter.Domain/

# Restore all projects
RUN dotnet restore ./CnabImporter.Api/CnabImporter.Api.csproj

# Copy the rest of the code
COPY ./src/ ./ 

# Publish
RUN dotnet publish ./CnabImporter.Api/CnabImporter.Api.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "CnabImporter.Api.dll"]
