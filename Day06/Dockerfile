FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Day06/Day06.csproj", "Day06/"]
RUN dotnet restore "Day06/Day06.csproj"
COPY . .
WORKDIR "/src/Day06"
RUN dotnet build "Day06.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day06.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day06.dll"]
