FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PaynauApp/PaynauApp.csproj", "PaynauApp.API/"]
COPY ["PaynauApp_Application/PaynauApp_Application.csproj", "PaynauApp_Application/"]
COPY ["PaynauApp_Domain/PaynauApp_Domain.csproj", "PaynauApp_Domain/"]
COPY ["PaynauApp_Infrastructure/PaynauApp_Infrastructure.csproj", "PaynauApp_Infrastructure/"]
RUN dotnet restore "PaynauApp/PaynauApp.csproj"
COPY . .
WORKDIR "/src/PaynauApp"
RUN dotnet build "PaynauApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaynauApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaynauApp.dll"]
