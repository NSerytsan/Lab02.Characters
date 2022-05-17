#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lab02.Characters.API/Lab02.Characters.API.csproj", "Lab02.Characters.API/"]
COPY ["Lab02.Charcters.Models/Lab02.Characters.Models.csproj", "Lab02.Charcters.Models/"]
RUN dotnet restore "Lab02.Characters.API/Lab02.Characters.API.csproj"
COPY . .
WORKDIR "/src/Lab02.Characters.API"
RUN dotnet build "Lab02.Characters.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab02.Characters.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab02.Characters.API.dll"]
