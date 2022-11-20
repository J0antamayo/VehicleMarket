
# Vehicle Market

Vehicle Market is an online platform to help people find vehicles on sale and connect them with sellers. 

## Some Features

-	Application built with ASP .NET Core MVC.
-	Login with Role based access.
-	Administrator user can do operations that manipulates database records from the platform.
-	Executive user can post a vehicle sale ad.
- Any anonymous user can see vehicles sale ads on the platform.
-	Frontend developed with AdminLTE Template. 

## Getting Started 

1. Clone the project.

```bash
  git clone https://github.com/joantamayodev/VehicleMarket
```

2. Create a Microsoft SQL Server local database.

3. Add connection string to app settings.json. It will look something like this:

```bash
  Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VehicleMarket;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
```
4. From the Package Manager Console run command "Update-Database" to create database and schema from migrations:

```bash
  PM> Update-Database
```
5. From the Developer Powershell locate inside the MVC project:

```bash
  PS C:\Users\developer\project\VehicleMarket\VehicleMarket>
```
6. Run this commands to seed database:

```bash
  PS C:\Users\developer\project\VehicleMarket\VehicleMarket>dotnet run seeddata
```
```bash
  PS C:\Users\developer\project\VehicleMarket\VehicleMarket>dotnet run seedusers
```
7. Credentials for users are:

Admin Credentials\
User: admin@vehiclemarket.com\
Password: Password123#

Executive Credentials\
User: executive@vehiclemarket.com\
Password: Password123#

## Authors

- [@joantamayodev](https://www.github.com/joantamayodev)


## Additional Information

This project is still in process.
