FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["westudy_administration_webapi_csharp/westudy_administration_webapi_csharp.csproj", "westudy_administration_webapi_csharp/"]
RUN dotnet restore "westudy_administration_webapi_csharp/westudy_administration_webapi_csharp.csproj"
COPY . .
WORKDIR "/src/westudy_administration_webapi_csharp"
RUN dotnet build "westudy_administration_webapi_csharp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "westudy_administration_webapi_csharp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "westudy_administration_webapi_csharp.dll"]