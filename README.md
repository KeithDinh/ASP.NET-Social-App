## API

### Notes

* Entities: Model
* Reset the server when adding new controllers
* If sending data in body as JSON, need to create a class (a model) to parse it (match properties of JSON to the class properties)
* The Extension folder contains static classes that extends a specific class by adding static functions

### General Concepts

Naming convention: 
* class members start with "_", Ex: _config
* interface name starts with "I" as prefix, Ex: ITokenService.cs 

* DTO: Data transfer object

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

The concept of Repository is to add a abstract layer on top of EF (factor similar codes). This injects the repository interface and prevents using DataContext directly

Circular Reference: the relationship between two entities cause EF to query circularly

Eager loading is the process whereby a query for one type of entity also loads related entities as part of the query

appsettings.json: store private information (work as env). The app will use this file either in dev or prod mode.

### Extensions (API.csproj) 

Nuget VSCode extension: to find and install packages (for Visual Studio, it's already built-in)

Microsoft.EntityFrameworkCore.Sqlite (tick on the API.csproj to install with the project)

dotnet-ef: can't install using Nuget Gallery, have to use cmd line: 
* ```dotnet tool install --global dotnet-ef --version 5.0.1```
* Requirements: Microsoft.EntityFrameworkCore.Design from Nuget Gallery
    
AutoMapper.Extensions.Microsoft.DependencyInjection: help to map from one object to another

### Data Context

DBContext class: act as a bridge between our code and db, It use the entities to map/create tables in database and return DBSets for backend to use

If an entity need to have a db table but there is no API use of that entity (users can store photo, so there is a need to get photos of a specific user, but no need to get photo without user itself)

### Database 

File: appsettings.Development.json
* ```"ConnectionStrings": {"Default": "Data source=datingapp.db"}``` 

### Commands 

dotnet run: run the app

dotnet watch run: rerun whenever updated

dotnet new sln: create a solution that can be opened by visual studio

dotnet new webapi -o [name]: create a new API project, -o mean put them in a separated container

dotnet sln add API: add the pj to the solution

dotnet dev-certs https --trust: tell browser to trust the certificates provided by dotnet sdk
#### Debugs (VSCode)

Mac: API.dll |||| Windows: API.exe

#### Migrations

dotnet ef migrations add <NAME> --output-dir <PATH>, 
Ex: dotnet ef migrations add InitialCreate -o Data/Migrations

dotnet ef database update: create/update current db from last migration

dotnet ef migrations remove: remove the last migration

dotnet ef database drop: drop current db

### Configs 

In dev mode, prod mode will be false and app will use both appsettings and appsettings development by default

File: appsettings.Development.json
* "Microsoft": "Information" gives useful details on accessing the route

### Models/Entities

public methods: we need the Entity Framework to both get/set itself

"Id", "ID": Entity Framework will recognize it as primary key, automatically increment in db

"UserName": to separate from "Username" of ASP.NET CORE Identity

### Basic Http status code

* Ok(); 200
* Created(); 201
* NoContent(); 204
* BadRequest(); 400
* Unauthorized(); 401
* Forbid(); 403
* NotFound(); 404

### External tools/packages

* json-generator.com: generate users' information
* randomuser.me: generate users' profile pictures
* Jsontots.com: convert json object to typescript model
* Cloudinary: mananging photos

* ngx-bootstrap: valor-software.com/ngx-bootstrap/#/tabs
* NgxGallery: npmjs.com/package/@kolkov/ngx-gallery
* ng2-file-upload: 

### Possible reasons causing bugs

* When using ngModel, need to have property 'name'