#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["VueCent.OAth.Service/VueCent.OAth.Service.csproj", "VueCent.OAth.Service/"]
RUN dotnet restore "VueCent.OAth.Service/VueCent.OAth.Service.csproj"
COPY . .
WORKDIR "/src/VueCent.OAth.Service"
RUN dotnet build "VueCent.OAth.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VueCent.OAth.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VueCent.OAth.Service.dll"]