FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Day05/Day05.csproj", "Day05/"]
RUN dotnet restore "Day05/Day05.csproj"
COPY . .
WORKDIR "/src/Day05"
RUN dotnet build "Day05.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day05.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day05.dll"]
