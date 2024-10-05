#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PaynauApp/PaynauApp.csproj", "PaynauApp/"]
COPY ["PaynauApp.Application/PaynauApp_Application.csproj", "PaynauApp.Application/"]
COPY ["PaynauApp.Domain/PaynauApp_Domain.csproj", "PaynauApp.Domain/"]
COPY ["PaynauApp.Infrastructure/PaynauApp_Infrastructure.csproj", "PaynauApp.Infrastructure/"]
RUN dotnet restore "./PaynauApp/PaynauApp.csproj"
COPY . .
WORKDIR "/src/PaynauApp"
RUN dotnet build "./PaynauApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PaynauApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaynauApp.dll"]