# RugbyManager
This is an API for managing a rugby team. It is based on .Net 6 web api. It consists of the following projects. RugbyManager.API, RugbyManager.Domain, RugbyManager.Persistence,
RugbyManager.Services, RugbyManager.Shared, and RugbyManager.Tests. The persistence layer depends on Entity Framework Core 7, using SQL Server database.

# How to run solution on your local machine

To run the solution on your local machine, 

1. Clone this repo to your local machine.
2. Restore the solution dependencies by either executing dotnet restore command on the command line of the root of the project or using Visual Studio Restore Nuget Packages
3. Run the tests either from Visual Studio or from the command line.
3. Make sure SQL Server is installed and running on you local machine.
4. Run migrations to create the RugbyManagerDB.
5. Choose RugbyManager.API as your default project to run.
6. Run the project in Visual Studio or on the command line.
7. Access the swagger page of the api on https://localhost:7220/swagger/index.html
