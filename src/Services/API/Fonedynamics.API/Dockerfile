#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/API/Fonedynamics.API/Fonedynamics.API.csproj", "Services/API/Fonedynamics.API/"]
RUN dotnet restore "Services/API/Fonedynamics.API/Fonedynamics.API.csproj"
COPY . .
WORKDIR "/src/Services/API/Fonedynamics.API"
RUN dotnet build "Fonedynamics.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fonedynamics.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fonedynamics.API.dll"]