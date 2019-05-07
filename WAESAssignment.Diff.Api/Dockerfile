FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WAESAssignment.DiffApi/WAESAssignment.DiffApi.csproj", "WAESAssignment.DiffApi/"]
RUN dotnet restore "WAESAssignment.DiffApi/WAESAssignment.DiffApi.csproj"
COPY . .
WORKDIR "/src/WAESAssignment.DiffApi"
RUN dotnet build "WAESAssignment.DiffApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WAESAssignment.DiffApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WAESAssignment.DiffApi.dll"]