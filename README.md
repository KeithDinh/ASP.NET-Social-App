# API

## Notes

* Entities: Model
* Reset the server when adding new controllers
* If sending data in body as JSON, need to create a class (a model) to parse it (match properties of JSON to the class properties)
* The Extension folder contains static classes that extends a specific class by adding static functions

## General Concepts

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

SingalR: library provides real-time functionality. It's Microsoft built-in

JSON.parse: format the string that like JSON Ex: JSON.parse(localStorage.getItem('item'))

JSON.stringify: turn a JSON into a json string

UTC Time: has Z at the end. Ex: 2020-11-11T11:38:20:32425Z

```[JsonIgnore]```: Declared on top of a Entity property. Used for processing data, but clients won't see it

## Asp Net Core Identity

IdentityUser<int>: Id, UserName, PasswordHash, PasswordSalt: these are built-in

## Extensions/Packages (API.csproj) 

Nuget VSCode extension: to find and install packages (for Visual Studio, it's already built-in)

For Nuget Package (tick on the API.csproj to install with the project)

dotnet-ef: can't install using Nuget Gallery, have to use cmd line: 
* ```dotnet tool install --global dotnet-ef --version 5.0.1```
* Requirements: Microsoft.EntityFrameworkCore.Design from Nuget Gallery
    
AutoMapper.Extensions.Microsoft.DependencyInjection: help to map from one object to another

Microsoft.AspNetCore.Authentication.JwtBearer

Microsoft.AspNetCore.Authentication.OpenIdConnect

Microsoft.AspNetCore.Identity.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Design  

Microsoft.EntityFrameworkCore.Sqlite

Swashbuckle.AspNetCore

System.IdentityModel.Tokens.Jwt     

Npgsql.EntityFrameworkCore.PostgreSQL: 5.0.1

## Data Context

DBContext class: act as a bridge between our code and db, it syncs the entities with tables (either map or create) in database and return DBSets for backend to use

```[Table("NameOfEntity")]```: If an entity need to have a db table but there is no API used of that entity (users can store photo, so there is a need to get photos of a specific user, but no need to get single photo from user itself)

## Database 

File: appsettings.Development.json
* SQLITE: ```"ConnectionStrings": {"Default": "Data source=datingapp.db"}``` 
* POSTGRES: ``` "ConnectionStrings": { "DefaultConnection": "Server=localhost; Port=5432; User Id=usr; Password=pw; Database=socialapp"},```
## Commands 

dotnet run: run the app

dotnet watch run: rerun whenever updated

dotnet new sln: create a solution that can be opened by visual studio

dotnet new webapi -o [name]: create a new API project, -o mean put them in a separated container

dotnet sln add API: add the pj to the solution

dotnet dev-certs https --trust: tell browser to trust the certificates provided by dotnet sdk

### Debugs (VSCode)

Mac: API.dll |||| Windows: API.exe

### Migrations

dotnet ef migrations add <NAME> --output-dir <PATH>: create cs codes to generate tables and constraints + snapshots
Ex: dotnet ef migrations add InitialCreate -o Data/Migrations

dotnet ef database update: make update effect to current db from last migration

dotnet ef migrations list: list all migrations

dotnet ef database update [Name of one of the migrations]: revert back to the specified migration (MUST delete the snapshot, and rerun migrations add to apply new change)

dotnet ef migrations remove: remove the last migration

dotnet ef database drop: drop current db

## External tools/packages

* json-generator.com: generate users' information
* randomuser.me: generate users' profile pictures
* Jsontots.com: convert json object to typescript model
* Cloudinary: mananging photos
* passwordsgenerator.net: set token key
<br />
* ngx-bootstrap: valor-software.com/ngx-bootstrap/#/tabs
* NgxGallery: npmjs.com/package/@kolkov/ngx-gallery
* ng2-file-upload: 
* npm install @angular/cdk
* ng add ngx-spinner
* npm install ngx-timeago
* npm install signalr

### Docker Set

Create a postgres image named "dev" and bind it to port 5432
```docker run --name dev -e POSTGRES_USER=user -e POSTGRES_PASSWORD=password -p 5432:5432 -d postgres:latest```

pgAdmin: pgadmin4-4.30-x64.exe (pw: honet)

### Heroku

#### Steps: 
* create heroku pj
* install heroku CLI
* setup new git repo on heroku
* ```heroku git:remote -a nameofpj```
* run buildpack command ```heroku buildpacks:set gitRepo```
* add resources in heroku addon: Heroku Postgres
* heroku settings: Config Vars: add CloudinarySettings from appsettings.json
* Add snippets to applicationServiceExtension
* set production: ```heroku config:set ASPNETCORE_ENVIRONMENT=Production```
* set token key: ```heroku config:set TokenKey=key```
* ```git push heroku branchName```

Debugs:
```heroku stack```: list all stacks
```heroku stack:set nameOfStack```: select stack

heroku dotnet buildpack: https://elements.heroku.com/buildpacks/jincod/dotnetcore-buildpack


## Configs 

In dev mode, prod mode will be false and app will use both appsettings and appsettings development by default

File: appsettings.Development.json
* "Microsoft": "Information" gives useful details on accessing the route

## Models/Entities

public methods: we need the Entity Framework to both get/set itself

"Id", "ID": Entity Framework will recognize it as primary key, automatically increment in db

"UserName": to separate from "Username" of ASP.NET CORE Identity

## Basic Http status code

* Ok(); 200
* Created(); 201
* NoContent(); 204
* BadRequest(); 400
* Unauthorized(); 401
* Forbid(); 403
* NotFound(); 404

## Possible reasons causing bugs

* Find / FindAsync methods are defined for DbSet<T>, but the result of Include is IQueryable<T> => can't use Include with FindAsync

* When using ngModel, need to have property 'name'

* EventEmitter is imported from '@angular/core' not 'events'

## Possible Features

* Message Broker: RabbitMQ

* Unit Test: 

