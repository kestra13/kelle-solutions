<p align="center">
  <img alt="logo" src="images/kellelogo.jpg" width="300">


# Razor Pages ASP.NET Core with Entity Framework Core

This project is a simple Razor Pages web application built with ASP.NET Core and Entity Framework Core. The application demonstrates basic CRUD (Create, Read, Update, Delete) functionality using a database (SQL Server).

## Team Scrumbags Members
| Name                  | Role       |
|-----------------------|------------|
| Nancy Zhu             | Member     |
| Steven Cao            | Member     |
| Brandon Kmiec         | Member     |
| Evan Brizendine       | Member     |
| Jalen Grant Hall      | Member     |
| Kestine Tran          | Member     |
| Kyle Mucha            | Member     |
| Sergio Rodriguez      | Team Lead  |


## Features

- Razor Pages with ASP.NET Core
- Entity Framework Core for data access
- SQL Server database for persistence
- Dependency Injection for `DbContext`
- CRUD operations for managing student data

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb)
- A text editor or an IDE like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## Getting Started

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

## 3. Install Dependencies (if necessary!)

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

## Project Structure

- `Pages/Students`: Razor Pages for creating, reading, updating, and deleting students.
- `Models/Student.cs`: The `Student` entity class.
- `Data/SchoolContext.cs`: The database context class for managing the database connection and querying the `Student` model.

## Technologies Used

- ASP.NET Core Razor Pages
- Entity Framework Core
- SQL Server / LocalDB
- Bootstrap (for simple page styling)

## How to Contribute

If you'd like to contribute to the project:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/my-feature`)
3. Commit your changes (`git commit -m 'Add my feature'`)
4. Push to the branch (`git push origin feature/my-feature`)
5. Create a new Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

