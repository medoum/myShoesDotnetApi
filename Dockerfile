# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "./myShoesDotnetApi/myShoesDotnetApi.csproj" --disable-parallel
RUN dotnet publish "./myShoesDotnetApi/myShoesDotnetApi.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
ENTRYPOINT ["dotnet", "myShoesDotnetApi.dll"]
