# 1. Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia la solución y el csproj
COPY *.sln ./
COPY SolidProducts/SolidProducts.csproj ./SolidProducts/

# Restaura dependencias
RUN dotnet restore "./SolidProducts/SolidProducts.csproj"

# Copia el resto del código y publica
COPY . .
WORKDIR /src/SolidProducts
RUN dotnet publish -c Release -o /app/publish

# 2. Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS="http://+:80"
ENTRYPOINT ["dotnet", "SolidProducts.dll"]
