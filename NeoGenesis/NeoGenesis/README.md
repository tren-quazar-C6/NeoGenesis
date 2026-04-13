# NeoGenesis Park — Management System

A console-based dinosaur management system built with **C# / .NET 10** and **Entity Framework Core**, connected to a **MySQL** database. Allows park staff to register, update, delete, and query dinosaurs across the park.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Language | C# 13 / .NET 10 |
| ORM | Entity Framework Core 9 |
| Database | MySQL 8 |
| MySQL Connector | Pomelo.EntityFrameworkCore.MySql 9 |
| Configuration | Microsoft.Extensions.Configuration |
| Interface | Interactive Console (CLI) |

---

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL 8 server (local or remote)
- A MySQL database named `neogenesis`

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/NeoGenesis.git
cd NeoGenesis
```

### 2. Set up configuration

Copy the example config file and fill in your credentials:

```bash
cp appsettings.example.json appsettings.json
```

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MySql": "Server=YOUR_SERVER;Database=neogenesis;User=YOUR_USER;Password=YOUR_PASSWORD;"
  }
}
```

> `appsettings.json` is listed in `.gitignore` and will never be committed.

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run --project NeoGenesis/NeoGenesis.csproj
```

---

## Project Structure

```
NeoGenesis/
├── appsettings.example.json        # Safe config template (commit this)
├── appsettings.json                # Real credentials (gitignored)
├── NeoGenesis.sln
└── NeoGenesis/
    ├── Program.cs                  # Entry point and main menu loop
    ├── NeoGenesis.csproj
    ├── Shared/
    │   ├── Entities/
    │   │   └── Dinosaurs.cs        # Dinosaur domain model
    │   └── Helpers.cs              # Console rendering utilities
    ├── Infrastructure/
    │   └── Data/
    │       ├── MySqlDbContext.cs    # EF Core DbContext
    │       └── DesignTimeDbContextFactory.cs
    ├── Migrations/                 # EF Core auto-generated migrations
    └── Modules/
        ├── Create/
        │   ├── CreateHandler.cs    # User input orchestration
        │   ├── CreateService.cs    # DB persistence
        │   └── CreateValidator.cs  # Field validation
        ├── Update/
        │   ├── UpdateHandler.cs
        │   ├── UpdateService.cs
        │   └── UpdateValidator.cs
        ├── Delete/
        │   ├── DeleteHandler.cs
        │   └── DeleteService.cs
        └── Query/
            ├── QueryMenu.cs        # Interactive query menu
            ├── QueryService.cs     # All DB queries
            └── Queries.cs          # In-memory LINQ helpers
```

---

## Features

### Main Menu

```
╔══════════════════════════════════════╗
║        NEOGENESIS PARK — MENU        ║
╚══════════════════════════════════════╝
1. Register Dinosaur
2. Update Dinosaur
3. Delete Dinosaur
4. Consult Dinosaurs
5. Exit
```

### Register Dinosaur
- Required fields: Name, Species, Username (unique), Register Code (unique)
- Optional fields: Age, Type, Zone, Sector, Track Number, Address
- Validates uniqueness of `Username` and `RegisterCode` before saving

### Update Dinosaur
- Search by ID
- Update any individual field including password (with confirmation)
- Uniqueness re-validated for `Username` and `RegisterCode` on change

### Delete Dinosaur
- Search by ID or Register Code
- Shows full dinosaur data before confirming deletion

### Query Dinosaurs (15 options)

| # | Query | Description |
|---|---|---|
| 1 | List all | All dinosaurs in the system |
| 2 | By ID | Single dinosaur by numeric ID |
| 3 | By Register Code | Single dinosaur by unique code |
| 4 | Filter by Zone | All dinosaurs in a park zone |
| 5 | Filter by Sector | All dinosaurs in a sector |
| 6 | Filter by Age | Dinosaurs older than a given age |
| 7 | Filter by Type | Herbivores or Carnivores |
| 8 | Name + Code report | Simplified report view |
| 9 | Count total | Total number of registered dinosaurs |
| 10 | Count by Zone | Dinosaur count in a specific zone |
| 11 | Count by Sector | Dinosaur count in a specific sector |
| 12 | Without Track Number | Dinosaurs missing tracking device |
| 13 | Without Address | Dinosaurs missing location data |
| 14 | By creation date | Ordered chronologically |
| 15 | Order by Species | Ordered alphabetically by species |

---

## Environment Variables (Production)

For production environments, set credentials via environment variables instead of a file. These override `appsettings.json` automatically:

```bash
# Linux / macOS
export ConnectionStrings__MySql="Server=...;Database=neogenesis;User=...;Password=...;"

# Windows
set ConnectionStrings__MySql=Server=...;Database=neogenesis;User=...;Password=...;

# Docker
docker run -e "ConnectionStrings__MySql=Server=...;" neogenesis-app
```

> The double underscore `__` maps to the nested JSON key `ConnectionStrings:MySql`.

---

## Dinosaur Model

| Field | Type | Required | Description |
|---|---|---|---|
| `Id` | int | Auto | Primary key |
| `DinoName` | string | ✅ | Dinosaur's name |
| `DinoSpecies` | string | ✅ | Species (e.g. T-Rex) |
| `Username` | string | ✅ | Unique system identifier |
| `RegisterCode` | string | ✅ | Unique registration code |
| `Age` | int? | ❌ | Age in years |
| `Type` | string? | ❌ | `Herbivore` or `Carnivore` |
| `Zone` | string? | ❌ | Park zone |
| `Sector` | string? | ❌ | Park sector |
| `Address` | string? | ❌ | Physical location |
| `TrackNumber` | string? | ❌ | GPS/tracking device number |
| `Password` | string? | ❌ | System access password |
| `CreatedAt` | DateTime | Auto | Registration timestamp |
| `UpdatedAt` | DateTime | Auto | Last update timestamp |

---

## Security Notes

- Database credentials are never hardcoded — loaded from `appsettings.json` or environment variables
- `appsettings.json` is excluded from version control via `.gitignore`
- Only `appsettings.example.json` (with placeholder values) is committed to the repository

---

## License

This project was developed for educational purposes.