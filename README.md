<p align="center">
  <img alt="logo" src="images/kellelogo.jpg" width="300">

# Razor Pages ASP.NET Core with Entity Framework Core

This project is a simple Razor Pages web application built with ASP.NET Core and Entity Framework Core. The application demonstrates basic CRUD (Create, Read, Update, Delete) functionality using a database (SQL Server).

<h2>
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/TOCicon.png">
  <source media="(prefers-color-scheme: light)" srcset="images/TOCiconlight.png">
  <img alt="Example Image" src="images/TOCicon.png">
  </picture>
  Table of Contents
</h2>

- [Team Scrumbags Members](#team-scrumbags-members)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [How to Contribute](#how-to-contribute)
- [License](#license)

<h2 id="team-scrumbags-members">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/membersicon.png">
  <source media="(prefers-color-scheme: light)" srcset="images/membersiconlight.png">
  <img alt="Example Image" src="images/membersicon.png">
  </picture>
  Team Scrumbags Members
</h2>

| Members               |
|-----------------------|
| Nancy Zhu             |
| Steven Cao            |
| Brandon Kmiec         |
| Evan Brizendine       |
| Jalen Grant Hall      |
| Kestine Tran          |
| Kyle Mucha            |
| Sergio Rodriguez [Team Lead]|

<h2 id="features">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/features.png">
  <source media="(prefers-color-scheme: light)" srcset="images/featureslight.png">
  <img alt="Example Image" src="images/features.png">
  </picture>
  Features
</h2>

- Razor Pages with ASP.NET Core
- Entity Framework Core for data access
- SQL Server database for persistence
- Dependency Injection for `DbContext`
- CRUD operations for managing student data


<h2 id="prerequisites">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/prerequisites.png">
  <source media="(prefers-color-scheme: light)" srcset="images/prerequisiteslight.png">
  <img alt="Example Image" src="images/TOCiconlight.png">
  </picture>
  Prerequisites
</h2>

Before running the application, ensure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb)
- A text editor or an IDE like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

<h2 id="getting-started">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/gettingstarted.png">
  <source media="(prefers-color-scheme: light)" srcset="images/gettingstartedlight.png">
  <img alt="Example Image" src="images/gettingstarted.png">
  </picture>
  Getting Started
</h2>

Follow these steps to get the application up and running:

### 1. Clone the Repository

```bash
git clone https://github.com/kestra13/kelle-solutions.git
cd kelle-solutions
```

### 2. Restore and Build the Project
```
dotnet tool install --global dotnet-ef
dotnet restore
dotnet build
```

### 3. Install Dependencies (if necessary!)

Install the required NuGet packages if they are not installed:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 4. Set Up the Database Connection

Update the `appsettings.json` file with your database connection settings. Here is the recommended setup:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

### 5. Apply Migrations and Create the Database

Use Enitity Framework Core to apply migrations and create the database schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 6. Run the Application

Use the following command to run the application locally:

```bash
dotnet run
```

The application will start on `https://localhost:5072` or `http://localhost:5000`. Upon running the application, the terminal should list the address!

![alt text](images/dotnetrunout.JPG)

<h2 id="project-structure">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/structure.png">
  <source media="(prefers-color-scheme: light)" srcset="images/structurelight.png">
  <img alt="Example Image" src="images/structure.png">
  </picture>
  Project Structure
</h2>

- `Pages/Students`: Razor Pages for creating, reading, updating, and deleting students.
- `Models/Student.cs`: The `Student` entity class.
- `Data/SchoolContext.cs`: The database context class for managing the database connection and querying the `Student` model.

<h2 id="technologies-used">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/technologiesused.png">
  <source media="(prefers-color-scheme: light)" srcset="images/technologiesusedlight.png">
  <img alt="Example Image" src="images/technologiesused.png">
  </picture>
  Technologies Used
</h2>

- ASP.NET Core Razor Pages
- Entity Framework Core
- SQL Server / LocalDB
- Bootstrap (for simple page styling)

<h2 id="testing">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/testing.png">
  <source media="(prefers-color-scheme: light)" srcset="images/testinglight.png">
  <img alt="Example Image" src="images/testing.png">
  </picture>
  Testing
</h2>

<h2 id="deploy">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/deploy.png">
  <source media="(prefers-color-scheme: light)" srcset="images/deploylight.png">
  <img alt="Example Image" src="images/deploy.png">
  </picture>
  Deploy
</h2>

<h2 id="instructions">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/instructions.png">
  <source media="(prefers-color-scheme: light)" srcset="images/instructionslight.png">
  <img alt="Example Image" src="images/instructions.png">
  </picture>
  Developer Instructions
</h2>

## How to Contribute

If you'd like to contribute to the project:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/my-feature`)
3. Commit your changes (`git commit -m 'Add my feature'`)
4. Push to the branch (`git push origin feature/my-feature`)
5. Create a new Pull Request

## License
