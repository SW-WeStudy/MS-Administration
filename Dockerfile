FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["westudy_administration_webapi_csharp.csproj", ""]
RUN dotnet restore "westudy_administration_webapi_csharp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "westudy_administration_webapi_csharp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "westudy_administration_webapi_csharp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "westudy_administration_webapi_csharp.dll"]