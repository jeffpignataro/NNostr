FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 81
EXPOSE 444

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NNostr.UI/NNostr.UI.csproj", "NNostr.UI/"]
RUN dotnet restore "NNostr.UI.csproj"
COPY . .
WORKDIR "/src/NNostr.UI"
RUN dotnet build "NNostr.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NNostr.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NNostr.UI.dll"]
