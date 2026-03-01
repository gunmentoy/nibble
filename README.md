# Nibble 🍽️

A mood-based restaurant discovery app built with ASP.NET Core Razor Pages.

## About

Nibble helps you find the perfect restaurant based on your current mood. Browse, search, and filter restaurants by name, cuisine, mood tag, and rating.

## Features

- **Mood-based filtering** — filter restaurants by mood tags (Cozy, Adventurous, Scenic, Lively, Chill)
- **Search** — find restaurants by name
- **Sorting** — sort by name or rating (ascending/descending)
- **Paging** — paginated results for easy browsing
- **Reviews** — view customer reviews on restaurant detail pages
- **Full CRUD** — create, read, update, and delete restaurants

## Tech Stack

- ASP.NET Core 10.0 Razor Pages
- Entity Framework Core + SQLite
- Bootstrap 5

## Getting Started

```bash
# Restore dependencies
dotnet restore

# Apply migrations and create the database
dotnet ef database update

# Run the app
dotnet run
```

The app seeds sample restaurant and review data on first run.

## Branch Info

- **main** — Term 3 project (unrelated)
- **cooking** — Term 4 BSYS 4000 IEP project (this branch)
