# Est�gio base com runtime do ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Est�gio de build com o SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Csegurancacap7/Csegurancacap7.csproj", "Csegurancacap7/"]
RUN dotnet restore "./Csegurancacap7/Csegurancacap7.csproj"
COPY . .
WORKDIR "/src/Csegurancacap7"
RUN dotnet build "./Csegurancacap7.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Est�gio de publica��o
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Csegurancacap7.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Est�gio final para execu��o do cont�iner
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Csegurancacap7.dll"]
