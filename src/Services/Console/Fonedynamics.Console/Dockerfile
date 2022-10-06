#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Console/Fonedynamics.Console/Fonedynamics.Console.csproj", "Services/Console/Fonedynamics.Console/"]
RUN dotnet restore "Services/Console/Fonedynamics.Console/Fonedynamics.Console.csproj"
COPY . .
WORKDIR "/src/Services/Console/Fonedynamics.Console"
RUN dotnet build "Fonedynamics.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fonedynamics.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fonedynamics.Console.dll"]