# Scarico l'immage di .net 8 e la espongo sulle port 80 e 443
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# le immagini di .NET 8 utilizzano per default la porta 8080,
# mentre le versioni precedenti utilizzano la porta 80
EXPOSE 8080
EXPOSE 8081

# Faccio la build del progetto, importando tutti i progetti a cui è referenziato
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProgettoCloud.Blazor/ProgettoCloud.Blazor.csproj", "ProgettoCloud.Blazor/"]
COPY ["ProgettoCloud.Service/ProgettoCloud.Service.csproj", "ProgettoCloud.Service/"]
COPY ["ProgettoCloud.Model/ProgettoCloud.Model.csproj", "ProgettoCloud.Model/"]
RUN dotnet restore "ProgettoCloud.Blazor/ProgettoCloud.Blazor.csproj"
COPY . .
WORKDIR "/src/ProgettoCloud.Blazor"
RUN dotnet build "ProgettoCloud.Blazor.csproj" -c Release -o /app/build

# Pubblico la mia app
FROM build AS publish
RUN dotnet publish "ProgettoCloud.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Crea l'immagine finale
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProgettoCloud.Blazor.dll"]


# run with command: docker run --rm -it -p 8080:8080 blazor-cloud-project