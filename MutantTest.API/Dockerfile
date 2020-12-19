FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MutantTest.API/MutantTest.API.csproj", "MutantTest.API/"]
COPY ["MutantTest.Domain/MutantTest.Domain.csproj", "MutantTest.Domain/"]
COPY ["MutantTest.Infra/MutantTest.Infra.csproj", "MutantTest.Infra/"]
RUN dotnet restore "MutantTest.API/MutantTest.API.csproj"
COPY . .
WORKDIR "/src/MutantTest.API"
RUN dotnet build "MutantTest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MutantTest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MutantTest.API.dll"]