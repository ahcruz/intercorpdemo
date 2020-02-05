FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Intercop.Services.Cliente/Intercop.Services.Cliente.csproj", "src/Services/Intercop.Services.Cliente/"]
COPY ["src/Common/Intercop.Common.Utils/Intercop.Common.Utils/Intercop.Common.Utils.csproj", "src/Common/Intercop.Common.Utils/Intercop.Common.Utils/"]
RUN dotnet restore "src/Services/Intercop.Services.Cliente/Intercop.Services.Cliente.csproj"
COPY . .
WORKDIR "/src/src/Services/Intercop.Services.Cliente"
RUN dotnet build "Intercop.Services.Cliente.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Intercop.Services.Cliente.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Intercop.Services.Cliente.dll"]