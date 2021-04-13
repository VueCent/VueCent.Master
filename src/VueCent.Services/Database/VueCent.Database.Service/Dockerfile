#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["VueCent.Database.Service/VueCent.Database.Service.csproj", "VueCent.Database.Service/"]
COPY ["VueCent.Database.DTO/VueCent.Database.DTO.csproj", "VueCent.Database.DTO/"]
COPY ["VueCent.Database.Entity/VueCent.Database.Entity.csproj", "VueCent.Database.Entity/"]
RUN dotnet restore "VueCent.Database.Service/VueCent.Database.Service.csproj"
COPY . .
WORKDIR "/src/VueCent.Database.Service"
RUN dotnet build "VueCent.Database.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VueCent.Database.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VueCent.Database.Service.dll"]