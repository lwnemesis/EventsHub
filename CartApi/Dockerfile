#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CartApi/CartApi.csproj", "CartApi/"]
RUN dotnet restore "CartApi/CartApi.csproj"
COPY . .
WORKDIR "/src/CartApi"
RUN dotnet build "CartApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CartApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartApi.dll"]