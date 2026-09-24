<div align="center">

# 🏛️ First.MVC.PL
### Enterprise 3-Tier ASP.NET Core MVC Application for Department & Human Resource Management

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Architecture](https://img.shields.io/badge/Architecture-3--Tier%20MVC-blue?style=for-the-badge&logo=diagram-project&logoColor=white)](#-system-architecture)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellowgreen?style=for-the-badge)](LICENSE)
[![Author](https://img.shields.io/badge/Author-Omar%20Alfarouk-orange?style=for-the-badge&logo=github&logoColor=white)](https://github.com/OmarAlfar0uk)

<p align="center">
  <a href="#-key-features">Key Features</a> •
  <a href="#-system-architecture">System Architecture</a> •
  <a href="#-tech-stack">Tech Stack</a> •
  <a href="#-project-structure">Project Structure</a> •
  <a href="#-getting-started">Getting Started</a> •
  <a href="#-author">Author</a>
</p>

</div>

---

## 📌 Executive Overview

**First.MVC.PL** is a classic enterprise 3-tier ASP.NET Core MVC application developed to demonstrate architectural separation of concerns. It manages company departments, employee assignments, and organizational hierarchies using a decoupled layered architecture spanning **Presentation (PL)**, **Business Logic (BLL)**, and **Data Access (DAL)**.

> [!NOTE]
> Follows the **3-Tier Enterprise Architecture Pattern** with dedicated project boundaries: **First.PL** (Razor views & controllers), **First.BLL** (business rules & services), and **First.DAL** (Entity Framework Core configurations and models).

---

## ✨ Key Features

| ⚡ Feature | 💡 Description | 🛠 Engineering Detail |
|---|---|---|
| **🏢 Department Management** | CRUD operations, creation dates, and department codes | Managed via `DepartmentServices` and `IDepartmentServices` |
| **👥 Employee & Staff Hierarchy** | Staff assignment, salary tracking, and departmental associations | Relational foreign keys configured via Fluent API |
| **📐 3-Tier Layering** | Strict physical and logical boundary between UI, logic, and data | High cohesion and low coupling across projects |
| **🎨 Responsive UI** | Razor Views styled with modern CSS and Tag Helpers | User-friendly dashboard for administrative staff |

---

## 🏛 System Architecture

```mermaid
flowchart TD
    subgraph Presentation["🖥️ Presentation Layer (First.PL)"]
        Controllers["Controllers (HomeController, DepartmentController)"]
        Views["Razor Views (.cshtml)"]
    end

    subgraph Business["⚙️ Business Logic Layer (First.BLL)"]
        Services["DepartmentServices (IDepartmentServices)"]
    end

    subgraph DataAccess["🗄️ Data Access Layer (First.DAL)"]
        Context["AppDbContext (Fluent Configurations)"]
        Entities["Entities (Department, Employee, BaseEntity)"]
        SQL[("SQL Server Database")]
    end

    Views --> Controllers
    Controllers --> Services
    Services --> Context
    Context --> Entities
    Context --> SQL
```

---

## ⚡ Tech Stack

| Category | Technology | Purpose |
|---|---|---|
| **Platform** | ![.NET 8](https://img.shields.io/badge/.NET_8-512BD4?style=flat-square&logo=dotnet&logoColor=white) ![C#](https://img.shields.io/badge/C%23_12-239120?style=flat-square&logo=csharp&logoColor=white) | ASP.NET Core MVC runtime |
| **Architecture** | ![3-Tier](https://img.shields.io/badge/Architecture-3--Tier%20Layered-blue?style=flat-square) | Presentation, BLL, and DAL project separation |
| **Data & ORM** | ![EF Core](https://img.shields.io/badge/EF_Core-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white) ![SQL Server](https://img.shields.io/badge/MS_SQL_Server-CC292B?style=flat-square&logo=microsoftsqlserver&logoColor=white) | Relational persistence and schema management |
| **Frontend** | ![Razor Views](https://img.shields.io/badge/Razor_Views-Bootstrap-purple?style=flat-square) | Server-side rendered responsive UI |

---

## 📂 Project Structure

```text
First.MVC.PL/
├── First.PL/                  # Presentation Layer: Controllers, Views, TagHelpers, Program.cs
├── First.BLL/                 # Business Logic Layer: Services & Business Validations
├── First.DAL/                 # Data Access Layer: Entities, DbContext & Configurations
└── First.sln                  # Visual Studio Solution
```

---

## 🚀 Getting Started

1. **Clone repository:**
   ```bash
   git clone https://github.com/OmarAlfar0uk/First.MVC.PL.git
   cd First.MVC.PL
   ```

2. **Launch Application:**
   ```bash
   dotnet run --project First.PL/First.PL.csproj
   ```

---

## 👨‍💻 Author

**Omar Alfarouk**  
*Full-Stack .NET & Software Engineer*  

- 🌐 **GitHub:** [@OmarAlfar0uk](https://github.com/OmarAlfar0uk)
- 💼 **LinkedIn:** [omar-alfarouk](https://www.linkedin.com/in/omar-alfarouk-252471251/)
- 📧 **Email:** [omaralfarouk646@gmail.com](mailto:omaralfarouk646@gmail.com)

---

<div align="center">
  <sub>Built with ❤️ by Omar Alfarouk. Licensed under the <a href="LICENSE">MIT License</a>.</sub>
</div>
