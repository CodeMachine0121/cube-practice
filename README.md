# Quiz Project for Cube Interview

### Setup for Development with Docker
- Create a docker network
`docker network create my-network`
- ms-sql setup
```
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" \
   -p 1433:1433 --name ms-sql --network mynetwork --hostname ms-sql \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
```
- Build image for the project: `docker build -t cube-practice .`
- Run the project: `docker run -itd -p 8080:8080 --name cube --network my-network cube-practice`
---
### API Endpoints
| Endpoint | Method | Description |
| --- |--------| --- |
| /coindesk | GET    | Get the currency details with chinese name mapping |
| /api/currencyName/ | GET    | fetch all currency names |
| /api/currencyName/{id} | GET    | fetch currency name by id |
| /api/currencyName/ | POST   | create a new currency name mapping |
| /api/currencyName/{id} | PETCH  | update currency name mapping by id |
| /api/currencyName/{id} | DELETE | delete currency name mapping by id |
