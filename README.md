# cache-app

```
dotnet new webapp -o CacheApp -au Individual -uld
```

```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
```

```
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update 
```

```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet-aspnet-codegenerator razorpage -m Firearm -dc ApplicationDbContext -udl -outDir Pages/Firearms --referenceScriptLibraries
dotnet-aspnet-codegenerator razorpage -m Caliber -dc ApplicationDbContext -udl -outDir Pages/Calibers --referenceScriptLibraries
dotnet ef migrations add CreateFirearmAndCaliberSchema
dotnet ef database update 
```

```
dotnet ef migrations add AddUserIdToFirearmAndCaliber
dotnet ef database update 
```