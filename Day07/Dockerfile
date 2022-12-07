FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Day07/Day07.csproj", "Day07/"]
RUN dotnet restore "Day07/Day07.csproj"
COPY . .
WORKDIR "/src/Day07"
RUN dotnet build "Day07.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day07.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day07.dll"]
