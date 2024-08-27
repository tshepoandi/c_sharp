# Gamestore Api

# Starting SQL Server

```powershell
    docker run -e "ACCEPT_EULA-Y" -e "MSSQL_SA_PASSWORD=YourStrong(!)Password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/msqlserver:2022-latest
```

2:49

Setting the connection string to secret manager

```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings: GamestoreContext" "Server=localhost; Database=Gamestore; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```
