# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /app

# # RUN groupadd -r leastprivileges
# # RUN useradd -g leastprivileges testuser
# # RUN chown -R testuser:testuser /app

# COPY *.csproj ./
# RUN dotnet restore

# COPY . ./
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:5.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "PlatformService.dll"]


FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore

#RUN dotnet restore "docker-size-test/docker-size-test.csproj"
COPY . .
WORKDIR /app
ENTRYPOINT ["dotnet", "PlatformService.dll"]

FROM build AS publish
RUN dotnet publish "PlatformService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformService.dll"]