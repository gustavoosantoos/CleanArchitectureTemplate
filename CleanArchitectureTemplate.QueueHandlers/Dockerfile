#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CleanArchitectureTemplate.QueueHandlers/CleanArchitectureTemplate.QueueHandlers.csproj", "CleanArchitectureTemplate.QueueHandlers/"]
RUN dotnet restore "CleanArchitectureTemplate.QueueHandlers/CleanArchitectureTemplate.QueueHandlers.csproj"
COPY . .
WORKDIR "/src/CleanArchitectureTemplate.QueueHandlers"
RUN dotnet build "CleanArchitectureTemplate.QueueHandlers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitectureTemplate.QueueHandlers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitectureTemplate.QueueHandlers.dll"]