FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PromoCodes/PromoCodes.csproj", "PromoCodes/"]
RUN dotnet restore "PromoCodes/PromoCodes.csproj"
COPY . .
WORKDIR "/src/PromoCodes"
RUN dotnet build "PromoCodes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PromoCodes.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "PromoCodes.dll"]
ENTRYPOINT ["dotnet", "myproject.dll","urls=http://*:5000"]
