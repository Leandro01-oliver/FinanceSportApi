FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todos os arquivos do projeto
COPY . .

# Instala o CLI do EF Core (para criar e aplicar migrations se necessário)
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Restaura, compila e executa testes
RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet test FinanceSportApi.Test/FinanceSportApi.Test.csproj --no-build --verbosity normal

# Publica o app
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "FinanceSportApi.dll"]
