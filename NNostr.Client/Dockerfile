FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 82
EXPOSE 445

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NNostr.Client.csproj", "NNostr.Client/"]
RUN dotnet restore "NNostr.Client/NNostr.Client.csproj"
WORKDIR "/src/NNostr.Client"
COPY . .
RUN dotnet build "NNostr.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NNostr.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NNostr.Client.dll"]
