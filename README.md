## API

### SOMETHINGS TO KEEP IN MIND

* Entities: Model
* Reset the server when adding new controllers
* DTO: Data transfer object
* If sending data in body, need to create a class acting as a model to parse it
* The Extension folder contains static classes that extends a specific class by adding static functions
### GENERAL DEFINITIONS

Naming convention: 
* class members start with "_", Ex: _config
* interface name starts with "I" as prefix, Ex: ITokenService.cs 

Entity Framework: Object Relational Mapper, translate code -> SQL that update db tables
* Automate process "open connections->create dataset to fetch/submit data->convert dataset to .Net object"
* Like mongoose for Mongo, add another layer on top of queries

Migrations: the concept covers: create db without writing SQL, modify db after changed backend models, revert changes

IEnumerable: use simple iteration over a collection of a specified type

An ActionResult is a return type of a controller method, also called an action method, and serves as the base class for *Result classes

Dependencies Injection:
* create objects, know which classes required those objects, provide them all those objects

When adding a middleware, need RequestDelegate "next"

Ilogger: display useful info to terminal

IHostEnvironment: check what environment 

### EXTENSIONS (API.csproj) 

Nuget VSCode extension: to find and install packages (for Visual Studio, it's already built-in)

Microsoft.EntityFrameworkCore.Sqlite (tick on the API.csproj to install with the project)

dotnet-ef: can't install using Nuget Gallery, have to use cmd line: 
* ```dotnet tool install --global dotnet-ef --version 5.0.1```
* Requirements: Microsoft.EntityFrameworkCore.Design from Nuget Gallery
    
### DATA CONTEXT

DBContext class: act as a bridge between our code and db, It use the entities to map/create tables in database and return DBSets for backend to use

If an entity need to have a db table but there is no API use of that entity (users can store photo, so there is a need to get photos of a specific user, but no need to get photo without user itself)

### DATABASE 

File: appsettings.Development.json
* ```"ConnectionStrings": {"Default": "Data source=datingapp.db"}``` 

### COMMANDS 

dotnet run: run the app

dotnet watch run: rerun whenever updated

dotnet new sln: create a solution that can be opened by visual studio

dotnet new webapi -o [name]: create a new API project, -o mean put them in a separated container

dotnet sln add API: add the pj to the solution

dotnet dev-certs https --trust: tell browser to trust the certificates provided by dotnet sdk

#### Migrations

dotnet ef migrations add <NAME> --output-dir <PATH>, 
Ex: dotnet ef migrations add InitialCreate -o Data/Migrations

dotnet ef database update: create/update current db from last migration

dotnet ef migrations remove: remove the last migration

dotnet ef database drop: drop current db


### CONFIGS 

File: appsettings.Development.json
* "Microsoft": "Information" gives useful details on accessing the route

### MODELS/ENTITIES 

public methods: we need the Entity Framework to both get/set itself

"Id", "ID": Entity Framework will recognize it as primary key, automatically increment in db

"UserName": to separate from "Username" of ASP.NET CORE Identity

### EXTRAS

* return Ok(); // Http status code 200
* return Created(); // Http status code 201
* return NoContent(); // Http status code 204
* return BadRequest(); // Http status code 400
* return Unauthorized(); // Http status code 401
* return Forbid(); // Http status code 403
* return NotFound(); // Http status code 404


### EXTERNAL TOOLS

json-generator.com
randomuser.me/