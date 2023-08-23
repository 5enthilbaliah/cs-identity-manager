# cs-mssql-tribe-crafter

## Prerequisites
- Make sure dotnet tool ef is installed globally
```shell
dotnet tool list --global
```
- Install ef globally if not found
```shell
dotnet tool install --global dotnet-ef
```
- You should have a local instance of sql server; We recommend to docker compose up the ms-sql-foundation.

## About project

## Set up
- Clone the repository
```shell
git clone https://github.com/5enthilbaliah/cs-mssql-tribe-crafter.git
```

- navigate in the cs-mssql-tribe-crafter and at the solution level open command prompt and execute below command.
```shell
dotnet ef  database update -c AmritaTribeConfigurationDbContext -p cs-mssql-tribe-crafter-infrastructure -s cs-mssql-tribe-crafter-host

dotnet ef  database update -c AmritaTribeOperationDbContext -p cs-mssql-tribe-crafter-infrastructure -s cs-mssql-tribe-crafter-host

dotnet ef  database update -c AmritaTribeApplicationDbContext -p cs-mssql-tribe-crafter-infrastructure -s cs-mssql-tribe-crafter-host
```
