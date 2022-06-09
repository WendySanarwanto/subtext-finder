#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./subtext-finder-api.csproj", "subtext-finder-api/"]
#COPY ["subtext-finder-api/subtext-finder-api.csproj", "subtext-finder-api/"]

RUN dotnet restore "subtext-finder-api/subtext-finder-api.csproj"
COPY . .
WORKDIR "/src/subtext-finder-api"
RUN dotnet build "subtext-finder-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "subtext-finder-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "subtext-finder-api.dll"]