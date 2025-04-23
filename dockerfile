# Etapa 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY RO.DevTest.WebApi/*.csproj ./RO.DevTest.WebApi/
COPY RO.DevTest.Application/*.csproj ./RO.DevTest.Application/
COPY RO.DevTest.Domain/*.csproj ./RO.DevTest.Domain/
COPY RO.DevTest.Persistence/*.csproj ./RO.DevTest.Persistence/
COPY RO.DevTest.Infrastructure/*.csproj ./RO.DevTest.Infrastructure/

RUN dotnet restore

# Copia tudo e compila o projeto
COPY . .
WORKDIR /src/RO.DevTest.WebApi
RUN dotnet publish -c Release -o /app/publish

# Etapa 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta usada no app
EXPOSE 5087
EXPOSE 7014

ENTRYPOINT ["dotnet", "RO.DevTest.WebApi.dll"]