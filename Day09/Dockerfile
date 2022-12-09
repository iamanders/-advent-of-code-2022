FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Day09/Day09.csproj", "Day09/"]
RUN dotnet restore "Day09/Day09.csproj"
COPY . .
WORKDIR "/src/Day09"
RUN dotnet build "Day09.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Day09.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Day09.dll"]
