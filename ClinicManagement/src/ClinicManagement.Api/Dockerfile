FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ClinicManagement.Api/ClinicManagement.Api.csproj", "ClinicManagement.Api/"]
COPY ["src/ClinicManagement.BlazorShared/ClinicManagement.BlazorShared.csproj", "ClinicManagement.BlazorShared/"]
COPY ["src/ClinicManagement.Infrastructure/ClinicManagement.Infrastructure.csproj", "ClinicManagement.Infrastructure/"]
COPY ["src/ClinicManagement.Core/ClinicManagement.Core.csproj", "ClinicManagement.Core/"]
COPY . .
WORKDIR "src/ClinicManagement.Api"
RUN dotnet restore "ClinicManagement.Api.csproj"
RUN dotnet build "ClinicManagement.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ClinicManagement.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClinicManagement.Api.dll"]
