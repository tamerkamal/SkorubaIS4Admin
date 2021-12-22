FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SkorubaIS4Admin.Admin/SkorubaIS4Admin.Admin.csproj", "src/SkorubaIS4Admin.Admin/"]
COPY ["src/SkorubaIS4Admin.Admin.EntityFramework.Shared/SkorubaIS4Admin.Admin.EntityFramework.Shared.csproj", "src/SkorubaIS4Admin.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaIS4Admin.Admin.EntityFramework.SqlServer/SkorubaIS4Admin.Admin.EntityFramework.SqlServer.csproj", "src/SkorubaIS4Admin.Admin.EntityFramework.SqlServer/"]
COPY ["src/SkorubaIS4Admin.Admin.EntityFramework.PostgreSQL/SkorubaIS4Admin.Admin.EntityFramework.PostgreSQL.csproj", "src/SkorubaIS4Admin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/SkorubaIS4Admin.Shared/SkorubaIS4Admin.Shared.csproj", "src/SkorubaIS4Admin.Shared/"]
COPY ["src/SkorubaIS4Admin.Admin.EntityFramework.MySql/SkorubaIS4Admin.Admin.EntityFramework.MySql.csproj", "src/SkorubaIS4Admin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/SkorubaIS4Admin.Admin/SkorubaIS4Admin.Admin.csproj"
COPY . .
WORKDIR "/src/src/SkorubaIS4Admin.Admin"
RUN dotnet build "SkorubaIS4Admin.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaIS4Admin.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaIS4Admin.Admin.dll"]