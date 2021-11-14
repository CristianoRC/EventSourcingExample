FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FakeBank.Api/FakeBank.Api.csproj", "FakeBank.Api/"]
RUN dotnet restore "FakeBank.Api/FakeBank.Api.csproj"
COPY . .
WORKDIR "/src/FakeBank.Api"
RUN dotnet build "FakeBank.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FakeBank.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FakeBank.Api.dll"]
