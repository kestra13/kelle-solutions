<p align="center">
  <img alt="logo" src="images/kellelogo.jpg" width="300">

# Kelle Solutions
Kelle Solutions is a simple Razor Pages web application built with ASP.NET Core and Entity Framework Core. Our application demonstrates basic CRUD (Create, Read, Update, Delete) functionality using a database (SQL Server).

## Synopsis
Kelle Solutions is a user-friendly, multi-tenant SaaS (Software as a Service) platform designed to streamline operations for real estate professionals. It provides an all-in-one solution for users to organize and manage their businesses effectively. Each role (agent, tenant, and admin) has tailored views and specific permissions to CRUD (Create, Read, Update, Delete) functionalities. With a scalable design, Kelle Solutions integrates seamlessly with essential tools and systems, allowing users to navigate through their dashboard, leads, properties, listings, entities, and people. While agents have limited access to most functionalities, tenants and admins have additional tools and features with tenants having advanced permissions.

<table>
  <tr>
    <th><b>Create Account Page</b></th>
    <th><b>Sign In</b></th>
  </tr>
  <tr>
    <td align="center"><img src="images/createaccount.png" alt="Create Account Page"></td>
    <td align="center"><img src="images/signin.png" alt="Sign In"></td>
  </tr>
  <tr>
    <th><b>Forgot Password</b></th>
    <th><b>Verification Code</b></th>
  </tr>
  <tr>
    <td align="center"><img src="images/forgotpassword.png" alt="Forgot Password"></td>
    <td align="center"><img src="images/verificationcode.png" alt="Verification Code"></td>
  </tr>
  <tr>
    <th><b>Change Password</b></th>
    <th><b>Current Dashboard</b></th>
  </tr>
  <tr>
    <td align="center"><img src="images/changepassword.png" alt="Change Password"></td>
    <td align="center"><img src="images/ATdashboard.png" alt="Current Dashboard"></td>
  </tr>
</table>

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
- [Timeline](#timeline)
- [Technologies Used](#technologies-used)
- [Testing](#testing)
- [Deployment](#deploy)
- [Developer Instructions](#instructions)
- [How to Contribute](#contribute)
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
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
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

| **Path**                       | **Description**                                                                                  |
|--------------------------------|--------------------------------------------------------------------------------------------------|
| `Pages/Affiliations`           | Razor Pages for reading, updating, and deleting a User's company or organization affiliation.    |
| `Pages/Entities`               | Razor Pages for creating, reading, updating, and deleting entities, which represent companies and organizations. |
| `Pages/Leads`                  | Razor Pages for creating, reading, updating, and deleting leads, which are potential tenants or clients. |
| `Pages/Listings`               | Razor Pages for creating, reading, updating, and deleting property listings, which are advertisements for houses. |
| `Pages/People`                 | Razor Pages for creating, reading, updating, and deleting tenants, or clients.                  |
| `Pages/Properties`             | Razor Pages for creating, reading, updating, and deleting properties.                           |
| `Pages/Roles`                  | Razor Pages for reading table of User roles.                                                    |
| `Pages/Shared`                 | Razor Pages for general UI/UX layout and login recognition.                                     |
| `Pages/Transactions`           | Razor Pages for documenting transactions.                                                       |
| `Models/Affiliate.cs`          | The `Affiliate` entity class, representing an agent's company or organization.                  |
| `Models/Person.cs`             | The `Person` entity class, representing tenants, or clients.                                    |
| `Models/RealEstateProperty.cs` | The `RealEstateProperty` entity class, representing a property.                                 |
| `Models/User.cs`               | The `User` entity class, representing any agent, tenant, or admin who logs in.                  |
| `Data/KelleSolutionsDbContext.cs` | The database context class for managing the database connection and querying the `Properties` and `Affiliates` model. |

<h2 id="timeline">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/timeline.png">
  <source media="(prefers-color-scheme: light)" srcset="images/timelinelight.png">
  <img alt="Example Image" src="images/timeline.png">
  </picture>
  Timeline
</h2>

### Sprint 5: Page Creation and Initial Styling
- Primary Focus: Completing page creation and updating styling for existing pages.
  - Update styling for created pages.
  - Create the following pages:
    - Tenant/Admin and Agent Asset Pages.
    - User-Specific Asset Pages.
    - Data Entry Pages.

### Sprint 6: Authentication and Permissions
- Primary Focus: Enhancing security and role management.
  - Set up Two-Factor Authentication.
  - Integrate SendGrid for account creation and password reset.
  - Create roles and their corresponding permissions.

### Sprint 7: Testing and Debugging
- Primary Focus: Ensuring reliability and identifying issues.
  - Testing of all features.
  - Debugging functionality, layout, and security issues.

### Sprint 8: Final Deployment
- Primary Focus: Wrapping up and launching the project.
  - Finalize any remaining testing and debugging.
  - Deploy the project.

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
- SQL Server / LocalDB (In development)
- Azure SQL Server Hosting (In testing)
- Bootstrap (for simple page styling)

<h2 id="testing">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/testing.png">
  <source media="(prefers-color-scheme: light)" srcset="images/testinglight.png">
  <img alt="Example Image" src="images/testing.png">
  </picture>
  Testing
</h2>

This section will include:
- Unit testing for critical functionalities (e.g. CRUD operations).
- Integration testing for database and authentication flows.
- Load testing to ensure application performance under concurrent usage.
- User acceptance testing to verify role-based dashboards and features.

<h2 id="deploy">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/deploy.png">
  <source media="(prefers-color-scheme: light)" srcset="images/deploylight.png">
  <img alt="Example Image" src="images/deploy.png">
  </picture>
  Deploy
</h2>

This section will outline:
- Publishing the web application to Azure App Services.
- Testing deployment on the live environment for accuracy and reliability.

<h2 id="instructions">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/instructions.png">
  <source media="(prefers-color-scheme: light)" srcset="images/instructionslight.png">
  <img alt="Example Image" src="images/instructions.png">
  </picture>
  Developer Instructions
</h2>

1. Prepare changes to be staged
```bash
git add .
```
2. Commit your changes
```bash
git commit -m 'Add my feature'
```
3. Push to the branch
```bash
git push origin main
```
4. Create a new Pull Request
```bash
git pull origin main
```

<h2 id="contribute">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/contribute.png">
  <source media="(prefers-color-scheme: light)" srcset="images/contributelight.png">
  <img alt="Example Image" src="images/contribute.png">
  </picture>
  How to Contribute
</h2>

If you'd like to contribute to the project:

1. Fork the repository (through GitHub)
2. Create a feature branch
```bash
git checkout -b feature/my-feature
```
3. Commit your changes
```bash
git commit -m 'Add my feature'
```
4. Push to the branch
```bash
git push origin feature/my-feature
```
5. Create a new Pull Request
```bash
git pull origin main
```

<h2 id="license">
  <picture>
  <source media="(prefers-color-scheme: dark)" srcset="images/license.png">
  <source media="(prefers-color-scheme: light)" srcset="images/licenselight.png">
  <img alt="Example Image" src="images/license.png">
  </picture>
  License
</h2>

All rights are observed. This project is not open source.
