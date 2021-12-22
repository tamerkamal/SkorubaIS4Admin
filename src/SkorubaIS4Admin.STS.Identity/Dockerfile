FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SkorubaIS4Admin.STS.Identity/SkorubaIS4Admin.STS.Identity.csproj", "src/SkorubaIS4Admin.STS.Identity/"]
COPY ["src/SkorubaIS4Admin.Admin.EntityFramework.Shared/SkorubaIS4Admin.Admin.EntityFramework.Shared.csproj", "src/SkorubaIS4Admin.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaIS4Admin.Shared/SkorubaIS4Admin.Shared.csproj", "src/SkorubaIS4Admin.Shared/"]
RUN dotnet restore "src/SkorubaIS4Admin.STS.Identity/SkorubaIS4Admin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/SkorubaIS4Admin.STS.Identity"
RUN dotnet build "SkorubaIS4Admin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaIS4Admin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaIS4Admin.STS.Identity.dll"]