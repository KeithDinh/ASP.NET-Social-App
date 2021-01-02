# DOCUMENTATIONS

## GENERAL DEFINITIONS

Naming convention: class members start with "_", Ex: _config
Entity Framework: Object Relational Mapper, translate code -> SQL that update db tables
* Automate process "open connections->create dataset to fetch/submit data->convert dataset to .Net object"
* Like mongoose for Mongo, add another layer on top of queries
Migrations: the concept covers: create db without writing SQL, modify db after changed backend models, revert changes

## EXTENSIONS (API.csproj) 

Nuget VSCode extension: to find and install packages (for Visual Studio, it's already built-in)
Microsoft.EntityFrameworkCore.Sqlite (tick on the API.csproj to install with the project)
dotnet-ef: can't install using Nuget Gallery, have to use cmd line: 
* ```dotnet tool install --global dotnet-ef --version 5.0.1```
* Requirements: Microsoft.EntityFrameworkCore.Design from Nuget Gallery
    
IEnumerable: use simple iteration over a collection of a specified type

## DATABASE 

File: appsettings.Development.json
* ```"ConnectionStrings": {"Default": "Data source=datingapp.db"}``` 

## COMMANDS 
dotnet run: run the app
dotnet watch run: rerun whenever updated

dotnet new sln: create a solution that can be opened by visual studio
dotnet new webapi -o [name]: create a new API project, -o mean put them in a separated container
dotnet sln add API: add the pj to the solution
dotnet dev-certs https --trust: tell browser to trust the certificates provided by dotnet sdk

### Migrations
dotnet ef migrations add <NAME> --output-dir <PATH>, Ex: dotnet ef migrations add InitialCreate -o Data/Migrations
dotnet ef database update

## CONFIGS 

File: appsettings.Development.json
* "Microsoft": "Information" gives useful details on accessing the route

## MODELS/ENTITIES 

public methods: we need the Entity Framework to both get/set itself
"Id", "ID": Entity Framework will recognize it as primary key, automatically increment in db
"UserName": to separate from "Username" of ASP.NET CORE Identity