FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet test ./UnitTests/UnitTests.csproj
RUN dotnet publish -c Release -o /release

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
ENV DB_SERVER=ms-sql
ENV DB_NAME=CubeDB
ENV DB_USER=sa
ENV DB_PASS=<YourStrong@Passw0rd>
WORKDIR /app
COPY --from=build /release .
EXPOSE 8080
ENTRYPOINT ["dotnet", "cube-practice.dll"]
