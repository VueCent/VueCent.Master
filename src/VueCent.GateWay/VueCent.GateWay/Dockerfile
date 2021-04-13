#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["VueCent.GateWay/VueCent.GateWay.csproj", "VueCent.GateWay/"]
RUN dotnet restore "VueCent.GateWay/VueCent.GateWay.csproj"
COPY . .
WORKDIR "/src/VueCent.GateWay"
RUN dotnet build "VueCent.GateWay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VueCent.GateWay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VueCent.GateWay.dll"]