### Add new migration

```sh
dotnet ef --startup-project ../SMR.Tracking.DesignTime migrations add CloudDbMigrationInit --context CloudDbContext
```

### Create database

```sh
dotnet ef --startup-project ../SMR.Tracking.DesignTime database update --context CloudDbContext
```

### Remove migrations

```sh
dotnet ef --startup-project ../SMR.Tracking.DesignTime migrations remove --context CloudDbContext
```
