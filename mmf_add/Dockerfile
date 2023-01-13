FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5004

ENV ASPNETCORE_URLS=http://+:5004

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mmf_add.csproj", "./"]
RUN dotnet restore "mmf_add.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mmf_add.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mmf_add.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mmf_add.dll"]
