#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GQLServer/GQLServer.csproj", "GQLServer/"]
COPY ["GQLServer.Domain/GQLServer.Domain.csproj", "GQLServer.Domain/"]
COPY ["GQLServer.Service/GQLServer.Service.csproj", "GQLServer.Service/"]
COPY ["GQLServer.Data/GQLServer.Data.csproj", "GQLServer.Data/"]
RUN dotnet restore "GQLServer/GQLServer.csproj"
COPY . .
WORKDIR "/src/GQLServer"
RUN dotnet build "GQLServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GQLServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GQLServer.dll"]