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