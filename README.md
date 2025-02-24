# lead-management-api
---

## Environment Setup

### Prerequisites

Ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Database Configuration

1. Update the connection string in the `appsettings.json` file located in the `API` layer:

```json
"ConnectionStrings": {
"DefaultConnection": "Server=localhost;Database=master;User Id=sa;Password=admin;TrustServerCertificate=True;"
}
```

## Apply migrations to create the database schema:
```cmd
cd src/Infrastructure
dotnet ef database update
```


## Data Generation Templates
### To generate data, use the JSON templates below:


### For Category:
```json
{
"Code": "string",
"Description": "string"
}
```

### For Customer:
```json
{
"FirstName": "string",
"Suburb": "string"
}
```

### For AdditionalContact:
```json
{
"FullName": "string",
"PhoneNumber": "string",
"Email": "string",
"CustomerId": 0
}
```

### For Lead:
```json
{
"Description": "string",
"Price": 0,
"Status": 0,
"CategoryId": 0,
"CustomerId": 0
}
```
