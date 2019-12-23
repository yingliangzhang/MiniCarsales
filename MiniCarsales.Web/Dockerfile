#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MiniCarsales.Web/MiniCarsales.Web.csproj", "MiniCarsales.Web/"]
COPY ["MiniCarsales.Dtos/MiniCarsales.Dtos.csproj", "MiniCarsales.Dtos/"]
COPY ["MiniCarsales.Models/MiniCarsales.Models.csproj", "MiniCarsales.Models/"]
COPY ["MiniCarSales.Repositories/MiniCarsales.Repositories.csproj", "MiniCarSales.Repositories/"]
COPY ["MiniCarsales.Services/MiniCarsales.Services.csproj", "MiniCarsales.Services/"]
RUN dotnet restore "MiniCarsales.Web/MiniCarsales.Web.csproj"
COPY . .
WORKDIR "/src/MiniCarsales.Web"
RUN dotnet build "MiniCarsales.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniCarsales.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniCarsales.Web.dll"]