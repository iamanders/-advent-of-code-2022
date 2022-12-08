FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Day08/Day08.csproj", "Day08/"]
RUN dotnet restore "Day08/Day08.csproj"
COPY . .
WORKDIR "/src/Day08"
RUN dotnet build "Day08.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day08.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day08.dll"]
