FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 81
EXPOSE 444

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get -y install python3
WORKDIR /src
COPY ["NNostr.UI.csproj", "NNostr.UI/"]
RUN dotnet workload restore "NNostr.UI/NNostr.UI.csproj"
RUN dotnet restore "NNostr.UI/NNostr.UI.csproj"
WORKDIR "/src/NNostr.UI"
COPY . .
RUN dotnet build "NNostr.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NNostr.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NNostr.UI.dll"]
